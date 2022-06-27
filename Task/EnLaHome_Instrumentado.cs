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
    class EnLaHome_Instrumentado : ITask
    {
        //Esta forma de hacer tareas genera una instancia de si misma y la ejecuta como el actor.
        //Cualquier código no relacionado a Screenplay puede ir ejecutado en el método PerformAs.
        //Pero se recomienda hacer esto solo en casos puntuales.

        public string MiProducto { get; }
   

        private EnLaHome_Instrumentado(string producto) => MiProducto = producto;

        public static EnLaHome_Instrumentado Buscar(string producto) =>
          new EnLaHome_Instrumentado(producto);

        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(SendKeys.To(HomePage.txt_busqueda, MiProducto));
            actor.AttemptsTo(Click.On(HomePage.btn_busqueda));

        }

    }
}
