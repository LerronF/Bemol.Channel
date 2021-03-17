using Bemol.Channel.Controller;
using Bemol.Channel.Controller.BuscaCEP;
using Bemol.Channel.Model;
using Bemol.Channel.Model.Entities;
using Bemol.Channel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.Entity;
using System.Linq;

namespace Bemol.Channel.View
{
    public partial class UsuarioView : Form
    {
        Bitmap imagem;
        byte[] imagemData, imagemDataNew;
        string FotoUsuario;
        int tamanho;
        bool editar;

        public UsuarioView()
        {
            InitializeComponent();
        }

        private void UsuarioView_Load(object sender, EventArgs e)
        {
            chkValida.Checked = true;
            editar = false;

            using (var contexto = new BemolDigitalContext())
            {
                var obj = contexto.Usuarios.ToList();

                if (obj.Count > 0)
                {
                    editar = true;

                    txtID.Text = obj[0].Id.ToString();
                    txtNome.Text = obj[0].Nome;
                    txtCPF.Text = obj[0].CPF;
                    maskTel.Text = obj[0].Telefone;
                    maskCEP.Text = obj[0].CEP;
                    txtLogradouro.Text = obj[0].Logradouro;
                    txtBairro.Text = obj[0].Bairro;
                    txtCidade.Text = obj[0].Cidade;
                    txtUF.Text = obj[0].UF;

                    try
                    {
                        MemoryStream stream = new MemoryStream(obj[0].Foto);
                        picFotoUsuario.Image = Image.FromStream(stream);
                        imagemDataNew = obj[0].Foto;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuario objUsuario = new Usuario();

            if (editar)
            {
                objUsuario.Id = Convert.ToInt32(txtID.Text);
            }

            objUsuario.Nome = txtNome.Text.Trim();
            objUsuario.CPF = txtCPF.Text;
            objUsuario.Logradouro = txtLogradouro.Text;
            objUsuario.Bairro = txtBairro.Text;
            objUsuario.Cidade = txtCidade.Text;
            objUsuario.UF = txtUF.Text;
            objUsuario.CEP = maskCEP.Text;
            objUsuario.Telefone = maskTel.Text;

            FileStream fs;

            if (@FotoUsuario != null)
            {
                fs = new FileStream(@FotoUsuario, FileMode.Open, FileAccess.Read);
                tamanho = (int)fs.Length;
                imagemData = new byte[fs.Length];

                fs.Read(imagemData, 0, tamanho);

                fs.Close();

                objUsuario.Foto = imagemData;
            }
            else if (picFotoUsuario.Image != null)
            {
                objUsuario.Foto = imagemDataNew;
            }

            if (editar)
            {
                BemolDigitalContext objContext = new BemolDigitalContext();
                objContext.Entry(objUsuario).State = EntityState.Modified;
                objContext.SaveChanges();
                MessageBox.Show("Alteração realizada com sucesso !", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BemolDigitalContext objContext = new BemolDigitalContext();
                objContext.Usuarios.Add(objUsuario);
                objContext.SaveChanges();
                MessageBox.Show("Cadastro realizado com sucesso !", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

        private void picFotoUsuario_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FotoUsuario = openFileDialog.FileName;
                imagem = new Bitmap(FotoUsuario);

                picFotoUsuario.Image = (Image)imagem;
            }
        }

        private void picFotoUsuario_DoubleClick(object sender, EventArgs e)
        {
            picFotoUsuario.Image = null;
        }
    }
}