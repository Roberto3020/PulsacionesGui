using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiPulsaciones
{
    public partial class FrmRegistroPersona : Form
    {
        private PersonaService personaService;
        public FrmRegistroPersona()
        {
            personaService = new PersonaService();
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();

        }

        private void Guardar()
        {
            try
            {
                Persona persona = new Persona()
                {
                    Identificacion = txtIdentificacion.Text,
                    Nombre = txtNombre.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Sexo = cbxSexo.Text,
                    //Pulsacion = double.Parse(txtPulsacion.Text)
                };
                persona.CalcularPulsacion();
                txtPulsacion.Text = persona.Pulsacion.ToString();
                var mensaje = personaService.Guardar(persona);
                MessageBox.Show(mensaje, "Mensaje guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Datos imcompletos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtEdad.Text = "";
            cbxSexo.Text = "";
            txtPulsacion.Text = "";
        }

        private void FrmRegistroPersona_Load(object sender, EventArgs e)
        {

        }
    }
}
