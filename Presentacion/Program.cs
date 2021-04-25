using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {

            String nombre, identificacion;
            int edad;
            string sexo;
            double pulsacion = 0;

            Console.WriteLine("Digite su nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese su identificacion: ");
            identificacion = Console.ReadLine();
            Console.WriteLine("Digiste su sexo F/M: ");
            sexo = Console.ReadLine();
            Console.WriteLine("Ingrese su edad: ");
            edad = int.Parse(Console.ReadLine());

            Persona persona = new Persona()
            {
                Nombre = nombre,
                Identificacion = identificacion,
                Sexo = sexo,
                Edad = edad,
            };

            persona.CalcularPulsacion();
            Console.WriteLine("Su pulsacion es: " + persona.Pulsacion);

            PersonaService personaService = new PersonaService();
            Console.WriteLine(personaService.Guardar(persona));
            Console.WriteLine("//Consulta de Persona//");
            ConsultaResponse response = personaService.Consultar();
            if (!response.Error)
            {
                foreach (var item in response.Personas)
                {
                    Console.WriteLine(item.ToString());
                }

            }
            else
            {
                Console.WriteLine(response.Mensaje);
            }
            Console.WriteLine("Ingrese la identificacion que desea eliminar: ");
            identificacion = Console.ReadLine();
            Console.WriteLine(personaService.Eliminar(identificacion));
            Console.WriteLine("Ingrese la identificacion que desea modificar");
            identificacion = Console.ReadLine();
            Console.WriteLine(personaService.Modificar(persona, identificacion));


            Console.ReadKey();
        }
    }
}
