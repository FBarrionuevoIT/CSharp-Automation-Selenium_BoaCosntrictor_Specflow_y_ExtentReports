using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.UI;

namespace BoaCosntrictorYSpecflowConExtentReports.Task
{
    class EnLaHome 
    {
        internal static ITask buscar(String  producto)
        {
                return RunTasks.InOrder(
                    ScrollToElement.At(HomePage.MNU_women),
                    Click.On(HomePage.MNU_women),
                    SendKeys.To(HomePage.TXT_busqueda, producto).ThenHitEnter(),
                    ScrollToElement.At(HomePage.MNU_women)
                    //,Wait.Until(Text.Of(HomePage.MNU_women),IsEqualTo.Value("")).ForUpTo(8)
                    // Wait.Until(Text.Of(HomePage.MNU_women), ContainsSubstring.Text(""))
                    );
            
        }


    }
}
