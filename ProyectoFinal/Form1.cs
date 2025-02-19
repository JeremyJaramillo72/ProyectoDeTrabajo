using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    
    public partial class bntPerfil : Form
    {
        Diseño Redondear = new Diseño();
        ToolTip toolTip = new ToolTip();
        public bntPerfil()
        {
            InitializeComponent();
      
           
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Redondear.RedondearPaneles(plPerfil, e);
        }



        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.pnCentral.Controls.Count > 0)
                this.pnCentral.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnCentral.Controls.Add(fh);
            this.pnCentral.Tag = fh;
            fh.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            Redondear.AplicarBordeRedondo(PbxFotoPerfil);
            toolTip.SetToolTip(btnPerfil, "Ver tu perfil");
            toolTip.SetToolTip(btnMensajes, "Mensajes");
            toolTip.SetToolTip(btnRed, "Red de contactos");
           
            toolTip.SetToolTip(btnMenu, "Abrir menú");
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmPerfil());
        }

        private void btnEmpleo_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmEmpleo());
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmConexion());
        }

        private void btnMensajes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FrmMensajeria());
        }
    }
}
