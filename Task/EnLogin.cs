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
    class EnLogin
    {
        internal static ITask iniciarSesionCon(String usuario, String contraseña)
        {

            return RunTasks.InOrder(
                   SendKeys.To(LoginPage.Txt_Usuario,usuario),
                   SendKeys.To(LoginPage.Txt_Contraseña,contraseña),
                    Click.On(LoginPage.BTN_Ingresar));
        }
    }
}
