using Bemol.Channel.View;
using System;
using System.Drawing;
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

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            UsuarioView mdiChildForm = new UsuarioView();
            mdiChildForm.MdiParent = this;
            mdiChildForm.Text = "Cadastro de Usuário";
            mdiChildForm.Show();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Deseja Finalizar a Sessão ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
