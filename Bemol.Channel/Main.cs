using Bemol.Channel.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bemol.Channel
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is MdiClient)
                {
                    control.BackColor = Color.White;
                    break;
                }
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            UsuarioView mdiChildForm = new UsuarioView();
            mdiChildForm.MdiParent = this;
            mdiChildForm.Text = "Formulário MDI Filho";
            mdiChildForm.Show();
        }
    }
}
