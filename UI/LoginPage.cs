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
    class LoginPage
    {
        
        public static IWebLocator Txt_Usuario = L("el elemento 'Email'",By.Id("email"));
        
        public static IWebLocator Txt_Contraseña = L("el elemento 'Contraseña'",By.Id("passwd"));
        
        public static IWebLocator BTN_Ingresar = L("el elemento 'BTN_Ingresar'",By.Id("SubmitLogin"));

    }



}

