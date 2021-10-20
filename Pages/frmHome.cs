using ProjetoProgramacaoVisual.Pages;
using System;
using System.Windows.Forms;

namespace ProjetoProgramacaoVisual
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnCadastrarProd_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Produtos = new frmProdutos();
            Produtos.Closed += (s, args) => this.Show();
            Produtos.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Login = new Login();
            Login.Closed += (s, args) => this.Close();
            Login.Show();
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Sobre = new frmSobre();
            Sobre.Closed += (s, args) => this.Show();
            Sobre.Show();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Comprar = new frmComprar();
            Comprar.Closed += (s, args) => this.Show();
            Comprar.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Categorias = new frmCategorias();
            Categorias.Closed += (s, args) => this.Show();
            Categorias.Show();
        }
    }
}
