using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using BoaCosntrictorYSpecflowConExtentReports.Steps;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TestProject2.UI;
using FluentAssertions;
using NUnit.Framework;
using Interactions;

namespace BoaCosntrictorYSpecflowConExtentReports.resources.features
{
    [Binding]
    public class BuscadorDeProductosSteps : Base
    {


        [Given(@"el usuario ingresa al sitio de WebDriverUniversity")]
        public void GivenElUsuarioIngresaAlSitioDeWebDriverUniversity()
        {
            fer.AttemptsTo(Navigate.ToUrl("https://webdriveruniversity.com/Dropdown-Checkboxes-RadioButtons/index.html"));
            fer.AttemptsTo(WaitThere.during(2).seconds());
        }
        
        [When(@"el usuario hace click en el primer checkbox sin chequear\.")]
        public  void WhenElUsuarioHaceClickEnElPrimerCheckboxSinChequear_()
        {
            fer.AttemptsTo(Click.On(WDU_Dropdown_Checkboxes_RadioButtons.Checkbox_Nro(1)));
            fer.AttemptsTo(WaitThere.during(2).seconds());
        }
        
        [Then(@"el estado del primer checkbox deberia ser true")]
        public  void ThenElEstadoDelPrimerCheckboxDeberiaSerTrue()
        {
            //Console.WriteLine(fer.AsksFor(HtmlAttribute.Of(WDU_Dropdown_Checkboxes_RadioButtons.Checkbox_Nro(1), "checked") ));
            //Usando la consola de NUnit:
            TestContext.Out.WriteLine(fer.AsksFor(HtmlAttribute.Of(WDU_Dropdown_Checkboxes_RadioButtons.Checkbox_Nro(1), "checked") ));
            fer.AttemptsTo(WaitThere.during(2).seconds());
            fer.AsksFor(HtmlAttribute.Of(WDU_Dropdown_Checkboxes_RadioButtons.Checkbox_Nro(1), "checked")).Should().Be("true");
        }
    }
}
