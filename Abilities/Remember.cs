using Boa.Constrictor.Screenplay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Bankingly.Abilities
{
    public class Remember : IAbility
    {
        private Hashtable tabla ;
        #region Constructors

        /// <summary>
        /// Constructor.
        /// (Use the static methods for public construction.)
        /// </summary>
        /// Crea una tabla Hash para recordar los valores necesarios que pueden ser fruto de sus interacciones
        private Remember()
        {
            tabla = new Hashtable();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Retorna el valor de un elemento guardado
        /// </summary>
        public dynamic getElement(string nombre)
        {
            return get(nombre);
        }

        public dynamic recall(string nombre)
        {
            return get(nombre);
        }



        public dynamic get(string nombre)
        {
            return tabla[nombre];
        }

        /// <summary>
        /// El valor de un elemento guardado
        /// </summary>
        /// <param name="nombre">El nombre del elemento.</param>
        /// <param name="elemento">El elemento a recordad.</param>
        /// <returns></returns>
        public void takeNotesOf(string nombre, dynamic elemento)
        {
            if (tabla.ContainsKey(nombre)){
                tabla.Remove(nombre);
            }
            tabla.Add(nombre, elemento);
        }

        public static Remember theValueAs(dynamic valorOElemento, string nombre) => new Remember();
        public static Remember theNecesaryElements() => new Remember();

        #endregion

        #region Methods

        /// <summary>
        /// Returns a description of this Ability.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"puede recordar los elementos que crea necesario para utilizarlos luego";

        #endregion
    }
}

