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
            frmProdutos frm = new frmProdutos();
            frm.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            frmSobre sobre = new frmSobre();
            sobre.Show();
            this.Close();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            frmComprar comprar = new frmComprar();
            comprar.Show();
            this.Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmCategorias clientes = new frmCategorias();
            clientes.Show();
            this.Close();
        }
    }
}
