using Bemol.Channel.Controller;
using Bemol.Channel.Controller.BuscaCEP;
using Bemol.Channel.Model;
using Bemol.Channel.Model.Entities;
using System;
using System.Windows.Forms;

namespace Bemol.Channel.View
{
    public partial class UsuarioView : Form
    {

        public UsuarioView()
        {
            InitializeComponent();
        }

        private void UsuarioView_Load(object sender, EventArgs e)
        {
            chkValida.Checked = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuario objUsuario = new Usuario();
            objUsuario.Nome = txtNome.Text.Trim();
            objUsuario.CPF = txtCPF.Text;
            objUsuario.Logradouro = txtLogradouro.Text;
            objUsuario.Bairro = txtBairro.Text;
            objUsuario.Cidade = txtCidade.Text;
            objUsuario.UF = txtUF.Text;
            objUsuario.CEP = maskCEP.Text;
            objUsuario.Telefone = txtTelefone.Text;

            BemolDigitalContext objContext = new BemolDigitalContext();
            objContext.Usuarios.Add(objUsuario);
            objContext.SaveChanges();
            MessageBox.Show("Cadastro realizado com sucesso !", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Finalizar Cadastro ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtCPF_Leave(object sender, EventArgs e)
        {
            if (chkValida.Checked)
            {
                var valida = MetodosComuns.CheckCPF(txtCPF.Text);

                if (valida)
                {
                    txtCPF.Text = MetodosComuns.CPFFormat(txtCPF.Text.Trim());
                }
                else
                {
                    txtCPF.Text = "";
                    txtCPF.Focus();
                    MessageBox.Show("CPF inválido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void maskCEP_Leave(object sender, EventArgs e)
        {
            BuscaCepRequest requestCep;

            try
            {
                requestCep = new BuscaCepRequest();

                var response = requestCep.Pesquisar(maskCEP.Text);

                maskCEP.Text = response.Cep;
                txtLogradouro.Text = response.Logradouro;
                txtBairro.Text = response.Bairro;
                txtCidade.Text = response.Cidade;
                txtUF.Text = response.Uf;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.ToString().Contains("400 (Bad Request)"))
                {
                    MessageBox.Show(this, "CEP inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    maskCEP.Clear();
                    maskCEP.Focus();

                }
            }
        }
    }
}