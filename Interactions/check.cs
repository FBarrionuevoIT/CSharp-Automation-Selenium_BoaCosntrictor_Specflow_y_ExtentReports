using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using System;

namespace Bankingly.Interactions.New
{
    public class check : ITask
    {
        private IQuestion<bool> question;
        private IsEqualTo<bool> matcher;
        private bool condition;
        private ITask[] TaskToDo;

        public check(bool condition)
        {
            this.condition = condition;
        }

        public check(IQuestion<bool> question, IsEqualTo<bool> matcher)
        {
            this.question = question;
            this.matcher = matcher;
        }

        public check()
        {
        }


        //1-Argumentos
        public static check whether(IQuestion<bool> question, IsEqualTo<bool> matcher)
        {
            check temp = new check();
            temp.question = question;
            temp.matcher = matcher;
            return temp;
        }

        public static check whether(bool condition)
        {
            check temp = new check();
            temp.condition = condition;
            return temp;
        }

        public check AndIfSo(params ITask[] TaskToDo)
        {
            this.TaskToDo = TaskToDo;
            return this;
        }

        public void PerformAs(IActor actor)
        {
            bool finalCOndition = false;
            //Des-comentar solo con propositos de debug en las preguntas enviadas
            if(!(question is null)) { 
                Console.WriteLine("La comparación da: " + (actor.AskingFor(question)
                         .CompareTo(matcher.Expected) >= 0));
                Console.WriteLine("La pregunta: " + actor.AskingFor(question).ToString());
                Console.WriteLine("El comparador: " + matcher.Expected);
                Console.WriteLine("El comparación invertida: " + matcher.Evaluate(actor.AskingFor(question)));
                finalCOndition = actor.AskingFor(question).CompareTo(matcher.Expected) >= 0;
            }
            finalCOndition = (finalCOndition || condition);

            //if (actor.AskingFor(question).Equals(matcher.Expected) || condition == true)
            if (finalCOndition)
                {
                    actor.AttemptsTo(TaskToDo);
                //actor.AttemptsTo(Wait2.during(5).seconds());
            }
        } 
    }
}