using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BoaCosntrictorYSpecflowConExtentReports.Steps
{
    [Binding]
    public class Base 
    {
        public static IActor fer;
        public static IWebDriver driver;
        public static ChromeOptions options = new();
        public static StringWriter stringWriter;

        [BeforeScenario(Order = 1)]
        public static void setUp()
        {

            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            //1- Le indicamos donde van a ser reflejadas las acciones de nuestro actor.
            fer = new Actor(name: "Fer", logger: new ConsoleLogger());


            //2-Damos la habilidad de navegar en la web a nuestro actor en el setup si este no la tiene.
            if (fer.HasAbilityTo<BrowseTheWeb>() == false)
            {
                Console.WriteLine("Fer tiene esa habilidad?" + fer.HasAbilityTo<BrowseTheWeb>());
                fer.Can(BrowseTheWeb.With((driver = new ChromeDriver())));
            }

            fer.AttemptsTo(MaximizeWindow.ForBrowser());

            options.AddArgument(@"--incognito");
            options.AddArgument(@"--start-maximized");
            WebDriverWait wait = new WebDriverWait(fer.Using<BrowseTheWeb>().WebDriver, TimeSpan.FromSeconds(30));
        }


        [AfterScenario]
        public static void TearDown()
        {
            
            fer.AttemptsTo(QuitWebDriver.ForBrowser());
        }

    }


}
