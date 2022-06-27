using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interactions
{
    class WaitThere : ITask
    {
        private string Url { get; set; }
        private int _tiempoEnSegundos;
        private int _tiempoEnMinutos;
        private int _tiempoEnHoras;
        private int _valorTemp;

        private DateTime fechaObjetivo;
        private DateTime fechaActual;
        private WaitThere(int tiempoEnSegundos) =>
            this._tiempoEnSegundos = tiempoEnSegundos;

        public WaitThere()
        {
        }

        public static WaitThere wait()
        {
            return new WaitThere();
        }

        public WaitThere and(int Numerotiempo)
        {
            _valorTemp = Numerotiempo;
            return this;
        }
        public WaitThere during2(int Numerotiempo)
        {
            _valorTemp = Numerotiempo;
            return this;
        }

        //1- Recibe el valor
        public static WaitThere during(int Numerotiempo)
        {
            WaitThere temp = new WaitThere();
            temp._valorTemp = Numerotiempo;
            return temp; 
        }

        //2- Lo guarda como un indicador de tiempo y devuelve la instancia
        public WaitThere seconds()
        {
            this._tiempoEnSegundos = this._valorTemp;
            return new WaitThere(this._tiempoEnSegundos);
        }

        //2- Lo guarda como un indicador de tiempo y devuelve la instancia
        public WaitThere minutes()
        {
            _tiempoEnMinutos = _valorTemp;
            return new WaitThere(this._tiempoEnSegundos);
        }

        //3- Carga los valores y los ejecuta como acciones del actor.
        public void PerformAs(IActor actor)
        {
            _tiempoEnHoras = _tiempoEnHoras>0 ? _tiempoEnHoras : 0;
            _tiempoEnMinutos = _tiempoEnMinutos > 0 ? _tiempoEnMinutos : 0;
            _tiempoEnSegundos = _tiempoEnSegundos > 0 ? _tiempoEnSegundos : 0;

            //Extrae el webdriver del actor
            var driver = actor.Using<BrowseTheWeb>().WebDriver;

            //Ejecuta ordenes usando métodos propios de selenium más específicos
            var delay = new TimeSpan(0, _tiempoEnHoras, _tiempoEnMinutos, _tiempoEnSegundos, 0);
            var FechaActual = DateTime.Now;
            //Console.WriteLine("La resta de las fechas es: " + (DateTime.Now - FechaActual));
            //Console.WriteLine("El delay es:" + delay);
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, _tiempoEnSegundos + 1, 0));
            wait.Until(webDriver => (DateTime.Now - FechaActual) > delay);
        }
    }
}
