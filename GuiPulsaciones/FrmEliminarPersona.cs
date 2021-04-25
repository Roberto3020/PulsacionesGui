using Datos;
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
    public partial class FrmEliminarPersona : Form
    {
        DataTable dataTable = new DataTable();
        PersonaService service = new PersonaService();
        Persona persona = new Persona();
        public FrmEliminarPersona()
        {
            InitializeComponent();
            dataTable.Columns.Add("Cedula");
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Edad");
            dataTable.Columns.Add("Sexo");
            dataTable.Columns.Add("Pulsaciones");

            datagripEliminar.DataSource = dataTable;
            datagripEliminar.DataSource = service.Consultar().Personas;
            datagripEliminar.Refresh();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            persona.Identificacion = txtIdentificacion.Text;
            PersonaResponse response = service.BuscarxIdentificacion(txtIdentificacion.Text);
            if (response.PersonaEncontrada)
            {
                dataTable.Rows.Add(response.Persona.Identificacion, response.Persona.Nombre, response.Persona.Edad,
                    response.Persona.Sexo, response.Persona.Pulsacion);
                datagripEliminar.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No existe el usuario registrado");
            }
            txtIdentificacion.Text = "";
        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {
                }
    }
}
