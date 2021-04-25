using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PersonaService
    {
        PersonaRepository personaRepository = new PersonaRepository();
        public String Guardar(Persona persona)
        {
            personaRepository.Guardar(persona);
            try
            {
                if (personaRepository.BuscarxIdentificacion(persona.Identificacion) != null)
                {
                    personaRepository.Guardar(persona);
                    return "Se guardo los datos exitosamente";
                }

                return "No es posible guardar a la persona, la identificacion " + persona.Identificacion +
                    " Ya se encuentra registrada";

            }
            catch (Exception e)
            {


                return "Se presento el siguiente error" + e.Message;
            }
        }

        public String Eliminar(String identificacion)
        {
            try
            {
                if (personaRepository.BuscarxIdentificacion(identificacion) != null)
                {
                    personaRepository.Eliminar(identificacion);
                    return "Se elimino correctamente";
                }
                return "La persona que desea elminar no se encuentra regustrada";
            }
            catch (Exception e)
            {

                return $"Se presento el sguiente error {e.Message}";
            }
        }

        public String Modificar(Persona personaNueva, String identificacion)
        {
            try
            {
                if (personaRepository.BuscarxIdentificacion(identificacion) != null)
                {
                    personaRepository.Modificar(personaNueva, identificacion);
                    return "Se modifico la informacion correctamente";
                }
                return "La persona que desea modificar no se encuentra regustrada";
            }
            catch (Exception e)
            {

                return $"Se presento el sguiente error {e.Message}";

            }
        }
        public ConsultaResponse Consultar()
        {
            try
            {
                return new ConsultaResponse(personaRepository.Consultar());
            }
            catch (Exception e)
            {

                return new ConsultaResponse("Se presento el siguiente error" + e.Message);
            }
        }
        public ConsultaResponse ConsultaMayorDeEdad()
        {
            try
            {
                return new ConsultaResponse(personaRepository.ConsultarMayorDeEdad());
            }
            catch (Exception e)
            {

                return new ConsultaResponse("Se presento el siguiente error" + e.Message);
            }
        }

        public PersonaResponse BuscarxIdentificacion(string identificacion)
        {
            PersonaResponse personaResponse;
            try
            {
               Persona persona=  personaRepository.BuscarxIdentificacion(identificacion) ;
                if (persona != null)  {
                    return personaResponse = new PersonaResponse(persona);
                }
                else
                {
                    return personaResponse = new PersonaResponse("La Persona buscada no se encuentra Registrada");
                }
            }
            catch (Exception e)
            {

                return personaResponse = new PersonaResponse("Error de Aplicacion: " + e.Message);

            }
        }


    }

    public class ConsultaResponse
    {
        public List<Persona> Personas { get; set; }
        public String Mensaje { get; set; }
        public bool Error { get; set; }

        public ConsultaResponse(List<Persona> persona)
        {
            Personas = persona;
            Error = false;
        }

        public ConsultaResponse(String mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class PersonaResponse
    {
        public Persona Persona { get; set; }
        public string Message { get; set; }
        public bool PersonaEncontrada { get; set; }

        public PersonaResponse(Persona persona)
        {
            Persona = new Persona();
            Persona = persona;
            PersonaEncontrada = true;
        }
        public PersonaResponse(string message)
        {
            Message = message;
            PersonaEncontrada = false;
        }



    }
}
