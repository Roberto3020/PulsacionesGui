using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Persona
    {
        public Persona()
        {

        }
        public Persona(String nombre, String identificacion, int edad, string sexo, double pulsacion)
        {
            Nombre = nombre;
            Identificacion = identificacion;
            Edad = edad;
            Sexo = sexo;
        }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public double Pulsacion { get; set; }

        public void CalcularPulsacion()
        {
            if (Sexo.Equals("F"))
            {
                Pulsacion = (220 - Edad) / 10;
            }
            else if (Sexo.Equals("M"))
            {
                Pulsacion = (210 - Edad) / 10;
            }
            else
            {
                Pulsacion = 0;
            }
        }

        public override string ToString()
        {
            return $"Identifiacion: {Identificacion} Nombre: {Nombre} Edad: {Edad} Sexo: {Sexo} Pulsacion: {Pulsacion}";
        }
    }
}
