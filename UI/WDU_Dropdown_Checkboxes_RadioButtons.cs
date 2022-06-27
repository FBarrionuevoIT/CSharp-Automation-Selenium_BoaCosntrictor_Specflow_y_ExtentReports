using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace TestProject2.UI
{
    public static class WDU_Dropdown_Checkboxes_RadioButtons
    {
        //Esta forma también es mas abreviada pero sirve igual, quizás se entienda menos.
        //public static IWebLocator ResultLinks => L("Página de resultados de DuckDuckGo", By.ClassName("result__a"));

        //Dropdown Menu(s)
        public static IWebLocator DRD_desplegable1 = L("El menú desplegable 1", By.XPath("//select[@id='dropdowm-menu-1']"));
        public static IWebLocator DRD_desplegable2 = L("El menú desplegable 2", By.XPath("//select[@id='dropdowm-menu-2']"));
        public static IWebLocator DRD_desplegable3 = L("El menú desplegable 3", By.XPath("//select[@id='dropdowm-menu-3']"));

        //Checkboxe(s)
        /// <summary>
        /// Selecciona uno de los checkboxes en fila del sitio web
        /// </summary>
        /// <param name="fila"> El número de la fila donde se encuentra el checkbox</param>
        public static IWebLocator Checkbox_Nro(int fila) {
            return WebLocator.L("El checkbox Nro "+fila , By.XPath("//div[3]/div[@class=\"thumbnail\"]/div[1]/label["+ fila +"]/input[1]"));
        }

        //Radio Button(s)
        public static IWebLocator RadioButton_Nro(int fila)
        {
            return WebLocator.L("El Radiobutton u opción Nro " + fila, By.XPath(" //form[@id='radio-buttons']/input[" + fila + "]"));
        }

        //Selected & Disabled
        public static IWebLocator Rad_SinChequear = L("La opción 'Lettuce'", By.XPath("//form[@id='radio-buttons-selected-disabled']/input[1]"));
        public static IWebLocator Rad_Deshabilitado = L("La opción 'Cabbage'", By.XPath("//form[@id='radio-buttons-selected-disabled']/input[2]"));
        public static IWebLocator Rad_Chequeado = L("La opción 'Pumpkin'", By.XPath("//form[@id='radio-buttons-selected-disabled']/input[3]"));

        
        public static IWebLocator Rad_SelFrutas = L("La opción 'Pumpkin'", By.XPath("//select[@id='fruit-selects']"));
        
    }
}
