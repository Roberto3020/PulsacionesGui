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
    public partial class FrmConsultarPersona : Form
    {
      
        public FrmConsultarPersona()
        {
            InitializeComponent();
        
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            var personaService = new PersonaService().Consultar();
            if (!personaService.Error)
            {
                dataGridView1.DataSource = personaService.Personas;
            }
        }
    }
}
