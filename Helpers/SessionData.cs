using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Helpers
{
    static class SessionData
    {
        
        public static dynamic DaTosDePrueba(string Ambiente = "QA")
        {
            dynamic obj;
            string path = "../../../Resources/DaTosDePrueba.json";
            //string propiedad = "App";
            var jsonText = File.ReadAllText(path);
            obj = JObject.Parse(jsonText);
            return obj;

            /* esto deberia poder manejarse como:
            SessionData("Ambiente").Credenciales.Personas[0].username
            SessionData("Ambiente").Credenciales.Personas[0].password
            SessionData("Ambiente").Credenciales.Personas[1].username
            SessionData("Ambiente").Credenciales.Personas[1].password
            
            
             */

        }

        public static string ConfigAmbiente()
        {
            dynamic obj;
            string path = "../../../Resources/Ambiente.json";
            //string propiedad = "App";
            var jsonText = File.ReadAllText(path);
            obj = JObject.Parse(jsonText);
            return obj.ambiente.ToString();
        }

    }


}
