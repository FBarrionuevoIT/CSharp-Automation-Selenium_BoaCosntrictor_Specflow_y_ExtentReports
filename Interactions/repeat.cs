using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bankingly.Interactions
{
    public class repeat : ITask
    {
        private string Url { get; set; }

        private ITask[] tareas;
        int intentos;
        private bool condicion;
        private int veces;
        private IQuestion<Boolean> pregunta;

        public repeat()
        {

        }

        public repeat thisActions(ITask[] tareas)
        {
            this.tareas = tareas;
            return this;
        }

        public repeat ifIsTrue(Boolean condicion)
        {
            this.condicion = condicion;
            return this;
        }

        public repeat ifIsTrue(IQuestion<Boolean> pregunta)
        {
            this.pregunta = pregunta;
            return this;
        }

        public repeat Ntimes(int veces)
        {
            this.veces = veces;
            return this;
        }

        //3- Carga los valores y los ejecuta como acciones del actor.
        public void PerformAs(IActor actor)
        {

            //Extrae el webdriver del actor
            var driver = actor.Using<BrowseTheWeb>().WebDriver;

            for (int i = 0; i < veces; i++)
            {
                if (condicion == true || pregunta.RequestAs(actor) == true)
                {
                    actor.AttemptsTo(RunTasks.InOrder(tareas));
                }

            }

        }
    }
}
