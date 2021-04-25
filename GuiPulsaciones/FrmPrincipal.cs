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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        

        private void pictureMenu_Click(object sender, EventArgs e)
        {
            if (panelMenuVertical.Width == 250)
            {
                panelMenuVertical.Width = 60;
            }
            else
            {
                panelMenuVertical.Width = 250;
            }
        }

        private void AbrirFromPanel(object fromHijo) 
        {

            int cont = this.panelContendedor.Controls.Count;
            if (this.panelContendedor.Controls.Count > 0)
            {
                for (int i = 0; i < cont; i++)
                {
                    this.panelContendedor.Controls.RemoveAt(0);
                }



                Form fh = fromHijo as Form;
                fh.TopLevel = false;

                fh.Dock = DockStyle.Fill;
                this.panelContendedor.Controls.Add(fh);
                this.panelContendedor.Tag = fh;
                fh.Show();
            }
            }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
         new FrmRegistroPersona().Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            new FrmConsultarPersona().Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            new FrmEliminarPersona().Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
         

        }

        private void panelContendedor_Paint(object sender, PaintEventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }
    }
}
