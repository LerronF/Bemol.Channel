using Bemol.Channel.Model;
using Bemol.Channel.Model.Entities;
using Bemol.Channel.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
            timer.Start();

            lblNome.Visible = false;
            lblCPF.Visible = false;
            lblFone.Visible = false;
            lblCEP.Visible = false;
            lblLogradouro.Visible = false;
            lblBairro.Visible = false;
            lblCidade.Visible = false;
            lblUF.Visible = false;

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
            if (MessageBox.Show("Deseja Finalizar a Sessão ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            using (var contexto = new BemolDigitalContext())
            {
                var obj = contexto.Usuarios.ToList();

                if (obj.Count > 0)
                {
                    lblNome.Visible = true;
                    lblCPF.Visible = true;
                    lblFone.Visible = true;
                    lblCEP.Visible = true;
                    lblLogradouro.Visible = true;
                    lblBairro.Visible = true;
                    lblCidade.Visible = true;
                    lblUF.Visible = true;

                    lblNome.Text = "Usuário: " + obj[0].Nome.Trim();
                    lblCPF.Text = "CPF: " + obj[0].CPF;
                    lblFone.Text = "Telefone: " + obj[0].Telefone;
                    lblCEP.Text = "CEP: " + obj[0].CEP;
                    lblLogradouro.Text = "Logradouro: " + obj[0].Logradouro;
                    lblBairro.Text = "Bairro: " + obj[0].Bairro;
                    lblCidade.Text = "Cidade: " + obj[0].Cidade;
                    lblUF.Text = "UF: " + obj[0].UF;

                    try
                    {
                        MemoryStream stream = new MemoryStream(obj[0].Foto);
                        pictureBox.Image = Image.FromStream(stream);
                    }
                    catch (Exception)
                    {
                    }

                    //timer.Stop();
                }                
            }
        }
    }
}
