using Bemol.Channel.Model;
using Bemol.Channel.Model.Entities;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuario objUsuario = new Usuario();
            objUsuario.Nome = txtNome.Text;

            BemolDigitalContext objContext = new BemolDigitalContext();
            objContext.Usuarios.Add(objUsuario);
            objContext.SaveChanges();
            MessageBox.Show("Sucesso");
        }
    }
}
