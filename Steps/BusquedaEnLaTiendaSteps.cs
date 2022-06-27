using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using BoaCosntrictorYSpecflowConExtentReports.Task;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TestProject2.UI;
using FluentAssertions;

namespace BoaCosntrictorYSpecflowConExtentReports.Steps
{
    [Binding]
    public class BusquedaEnLaTiendaSteps : Base
    {
  
        

        [Given(@"el usuario ingresa al sitio")]
        public void GivenElUsuarioIngresaAlSitio()
        {
            fer.AttemptsTo(Navigate.ToUrl(HomePage.Url));
        }
        
        [When(@"el usuario inicia sesion con el usuario ""(.*)"", la contraseña ""(.*)"" y voy al buscador en el apartado Women")]
        public void WhenElUsuarioIniciaSesionConElUsuarioLaContrasenaYVoyAlBuscadorEnElApartadoWomen(string usuario, string contraseña)
        {
            fer.AttemptsTo(Click.On(HomePage.BTN_sigIn));
            fer.AttemptsTo(EnLogin.iniciarSesionCon(usuario, contraseña));
        }
        
        [When(@"el usuario realiza la busqueda de ""(.*)""")]
        public void WhenElUsuarioRealizaLaBusquedaDe(string producto)
        {
            fer.AttemptsTo(EnLaHome.buscar(producto));
        }
        
        [Then(@"La cantidad de productos mostrados deberia ser mayor o igual que (.*)")]
        public void ThenLaCantidadDeProductosMostradosDeberiaSer(int p0)
        {
            var CoincidenciasDeBúsqueda = fer.Using<BrowseTheWeb>().WebDriver.FindElements(HomePage.UL_TablaResultados.Query);
            
            CoincidenciasDeBúsqueda.Count.Should().BeGreaterThanOrEqualTo(p0);
            //ScenarioContext.Current.Pending();
        }
    }
}
