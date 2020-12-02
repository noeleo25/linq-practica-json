using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LQPractica2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ej 1: Deserialize
            //Parte 1
            var archivo = @"C:\Users\noemi\source\repos\LQPractica2\empleados.json";
            var empleados = ObtenerEmpleados(archivo);
            //Parte 2
            var nombre = empleados.Where(e => e.Edad <= 25)
                .Select(e => e.Nombre).FirstOrDefault();
            Console.WriteLine(nombre);
            #endregion
            #region Ej 2: LINQ to JSON
            //Parte 1
            JObject obj = JObject.Parse(@"{
              'nombre': 'Jonh Doe',
              'nivel': 'Junior',
              'edad': 25,
              'lenguajes': [ '.NET', 'PHP' ]
            }");
            //Parte 2
            string nivel = (string)obj["nivel"];
            Console.WriteLine(nivel);
            int edad = (int)obj["edad"];
            Console.WriteLine(edad);
            //Parte 3
            IList<string> lenguajes = obj["lenguajes"].Select(t => (string)t).ToList();
            foreach(var l in lenguajes)
            {
                Console.WriteLine(l);
            }

            #endregion
        }
        static List<Empleado> ObtenerEmpleados(string ruta) //Ej 1
        {
            List<Empleado> listaE = new List<Empleado>();
            using (StreamReader r = new StreamReader(ruta))
            {
                string json = r.ReadToEnd();
                listaE = JsonConvert.DeserializeObject<List<Empleado>>(json);
            }
            return listaE;
        }
    }
}
