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
    }
}
