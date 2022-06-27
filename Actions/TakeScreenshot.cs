namespace Bankingly.TestAutomation.Interactions
{
    using static NUnit.Framework.TestContext;
    using OpenQA.Selenium.Support.Extensions;
    using Boa.Constrictor.Screenplay;
    using Boa.Constrictor.WebDriver;
    using Boa.Constrictor.Utilities;
    using Boa.Constrictor.Logging;
    using SixLabors.ImageSharp;
    using WDSE.ScreenshotMaker;
    using WDSE.Decorators;
    using OpenQA.Selenium;
    using System.IO;
    using System;
    using WDSE;
    using NUnit.Framework;
    using System.Text.RegularExpressions;

    class TakeScreenshot : ITask
    {
        #region Constants Fields
        /// <summary>
        /// The default screenshot image format.
        /// </summary>
        public const ScreenshotImageFormat DefaultImageFormat = ScreenshotImageFormat.Png;
        private string v;

        public TakeScreenshot(string OutputDirectory, string fileName)
        {
            this.OutputDirectory = OutputDirectory;
            FileName = fileName;
        }
        #endregion

        #region Properties

        /// <summary>
        /// El nombre de la imagen.
        /// No incluir el directorio o la extensión !
        /// </summary>
        private string FileName { get; set; }

        /// <summary>
        /// Formato de la imagen
        /// </summary>
        private ScreenshotImageFormat Format { get; set; }

        /// <summary>
        /// La dirección del directorio en donde será almacenada la imagen
        /// </summary>
        private string OutputDirectory { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor privado.
        /// Usa los valores por defecto para el formato y prefijo
        /// (Usar metodos estaticos para un construcción publica)
        /// </summary>
        /// <param name="outputDirectory">La dirección al directorio en donde será almacenada la imagen de la captura de pantalla.</param>
        /// <param name="fileName">El nombre del archivo (sin la extensión).</param>
        private TakeScreenshot FromCurrentPage( string outputDirectory, string fileName )
        {
            TakeScreenshot NewScreenshot = new TakeScreenshot(outputDirectory, fileName)
            {
                FileName = fileName
            };
           
            return NewScreenshot;
        }
        #endregion

        #region Builder Methods

        /// <summary>
        /// Toma una captura de pantalla de la pagina actual
        /// </summary>
        /// <param name="outputDirectory">La dirección al directorio en donde será almacenada la imagen</param>
        /// <param name="fileName">El nombre de la imagen(sin la extensión).</param>
        /// <returns></returns>
        public static TakeScreenshot AndSaveItTo ( string outputDirectory, string fileName = null ) =>
            new TakeScreenshot( outputDirectory, fileName );

        /// <summary>
        /// Toma una captura de pantalla de la pagina actual.
        /// </summary>
        /// <param name="fileName">Nombre de la imagen(sin la extensión).</param>
        /// <returns></returns>
        public static TakeScreenshot SavedInFolderWithTestNameInDefaultPath ( string fileName = null ) =>
            new TakeScreenshot( string.Concat ( ProjectSettings.ScreenshotsPath, CurrentContext.Test.MethodName ), fileName );
        #endregion

        #region Methods

        /// <summary>
        /// Tomar una captura de pantalla y guardala en un archivo en la <i>outputDir</i> del directorio.
        /// Crear el directorio si todavía no existe.    
        /// Retorna la dirección hacía el directorio de la captura de pantalla.
        /// El nombre del archivo va a incluir el timestamp y el nombre del hilo si no se especifica un nombre explicitamente
        /// </summary>
        /// <param name="actor">El actor</param>
        /// 
        /// <returns></returns>
        public void  PerformAs( IActor actor)
        {
            string path = string.Empty;
            string fileName = this.FileName;

            var webdriver = actor.Using<BrowseTheWeb>().WebDriver;
            // Capturar y guardar la captura de pantalla
            // Usar el VerticalCombineDecorator para capturar la pagina entera
            var vcs = new VerticalCombineDecorator(new ScreenshotMaker());

            byte[] screen = null;
            try {

            
            //var screen = driver.TakeScreenshot(vcs);
            screen = webdriver.TakeScreenshot().AsByteArray;

            if ( string.IsNullOrWhiteSpace ( fileName ) )
            {
                // Usar el nombre definido con el timestamp
                fileName = Names.ConcatUniqueName ( "Screenshot" );
                actor.Logger.Info ( $"Set the screenshot file name to '{ fileName }'" );
            }
            else if ( Path.GetExtension ( fileName ) != "" )
            {
                // Remover cualquier extensión agregada al nombre del archivo
                actor.Logger.Warning ( $"Screenshot file name '{ fileName }' should not be given an extension" );
                actor.Logger.Warning ( "Removing the extension from the name" );
                fileName = Path.GetFileNameWithoutExtension ( fileName );
            }

            if ( !Directory.Exists ( OutputDirectory ) )
            {
                // Crear el directorio de salida si es que no existe
                actor.Logger.Debug ( $"Creating screenshot directory '{ OutputDirectory }'" );
                Directory.CreateDirectory( OutputDirectory );
            }
            }
            catch (Exception){ throw; }

            try
            {
                if (!(screen is null)) { 
                path = Path.Combine(OutputDirectory, $"{ fileName }.{ Format.ToString().ToLower() }");

                //Convertir un byte array a una imagen
                using (var image = Image.Load(screen))
                {
                    image.Save(path);
                }

                //Este método incrusta un screenshot codificado en base64 dentro del HTML
                //Esto puede provocar que el reporte pese demasiado
                //actor.Logger.LogArtifact(ArtifactTypes.Screenshots, path);

                //Este método toma rutas relativas con ayuda de regex, generando reportes mas livianos
                string picture = string.Format(
                                    @"<img style=""width: auto; max-width: 700px; max-height: 600px; object-fit: cover"" data-featherlight=""image"" 
                                    src=""{0}"" href=""{0}"">",
                                    Regex.Replace(path, ".+?(?=/Screenshot)", "."));

                actor.Logger.Info(picture);
                }
            }
            catch (Exception e)
            {
                actor.Logger.Fatal(e.Message);
            }
 
        }

  

        /// <summary>
        /// Obtener un único hashcode para esta interacción
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode () =>
            HashCode.Combine( GetType (), FileName, Format, OutputDirectory );

        /// <summary>
        /// Retorna una descripción de la interacción
        /// </summary>
        /// <returns></returns>
        public override string ToString () => $"take a screenshot from Current page on browser.";

        #endregion
    }
}
