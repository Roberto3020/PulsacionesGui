using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PersonaRepository
    {
            String ruta = @"Persona.txt";
            public void Guardar(Persona persona)
            {
                FileStream file = new FileStream(ruta, FileMode.Append);
                StreamWriter escritor = new StreamWriter(file);
                escritor.WriteLine(persona.Nombre + ";" + persona.Identificacion + ";" + persona.Edad + ";" + persona.Sexo + ";" +
                    persona.Pulsacion);
                escritor.Close();
                file.Close();

            }

            public void Eliminar(String identificacion)
            {
                List<Persona> personas = Consultar();
                FileStream file = new FileStream(ruta, FileMode.Create);
                file.Close();
                foreach (var item in personas)
                {
                    if (!item.Identificacion.Equals(identificacion))
                    {
                        Guardar(item);
                    }
                }

            }
            public List<Persona> Consultar()
            {
                List<Persona> personas = new List<Persona>();

                FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
                StreamReader reader = new StreamReader(file);
                String linea = " ";
                while ((linea = reader.ReadLine()) != null)
                {
                    Persona persona = MapaerPersona(linea);
                    personas.Add(persona);
                }
                file.Close();
                reader.Close();
                return personas;
            }

            private static Persona MapaerPersona(string linea)
            {
                String[] datosPersona = linea.Split(';');
                Persona persona = new Persona();
                persona.Nombre = datosPersona[0];
                persona.Identificacion = datosPersona[1];
                persona.Edad = int.Parse(datosPersona[2]);
                persona.Sexo = datosPersona[3];
                persona.Pulsacion = double.Parse(datosPersona[4]);
                return persona;
            }

            public Persona BuscarxIdentificacion(string identificacion)
            {
                Persona persona = new Persona();
                List<Persona> personas = Consultar();
                foreach (var item in Consultar())
                {
                    if (item.Identificacion.Equals(identificacion))
                    {
                        return item;
                    }
                }

                return null;
            }
            public void Modificar(Persona personaNueva, String identificacion)
            {
                List<Persona> personas = Consultar();
                FileStream file = new FileStream(ruta, FileMode.Create);
                file.Close();
                foreach (var item in personas)
                {
                    if (!item.Identificacion.Equals(identificacion))
                    {
                        Guardar(item);
                    }
                    else
                    {
                        Guardar(personaNueva);
                    }
                }
            }

            public List<Persona> ConsultarMayorDeEdad()
            {
                List<Persona> personas = new List<Persona>();
                return personas;
            }

        public List<Persona> ConsultarxHombre() 
        {
            List<Persona> personas = Consultar();
            IEnumerable<Persona> personaHombre =
                from persona in personas where persona.Sexo.Equals("M") select persona;

            return personaHombre.ToList();
        }
        }
    }

