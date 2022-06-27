using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace TestProject2.UI
{
    class HomePage
    {
        
        public const string Url = "http://automationpractice.com/";

        public static IWebLocator txt_busqueda => L("La caja de texto de DuckDuckGo",By.Id("search_form_input_homepage"));

        public static IWebLocator btn_busqueda => L("El botón de búsqueda de DuckDuckGo",By.Id("search_button_homepage"));


        public static IWebLocator MNU_women = L("el menú 'Women'",By.XPath("//header/div[3]/div[1]/div[1]/div[6]/ul[1]/li[1]/a[1]"));

        public static IWebLocator TXT_busqueda = L("la barra de búsqueda",By.Id("search_query_top"));

        //Sección "My Account"
        public static IWebLocator LBL_myOrders = L("el link ''Mu Orders",By.XPath("//a[@title='My orders']"));

        //Sección "Contact us" y "Sign In"

        public static IWebLocator BTN_sigIn = L("el botón 'Iniciar sesión'",By.XPath("//header/div[2]/div[1]/div[1]/nav[1]/div[1]/a[1]"));

        public static IWebLocator UL_TablaResultados = L("la tabla de resultados de búsqueda", By.XPath("//body/div[@id='page']/div[2]/div[1]/div[3]/div[2]/ul[@class='product_list grid row']/li"));

    }



}

