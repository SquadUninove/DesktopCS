using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace ProjetoProgramacaoVisual.Pages
{
    public partial class frmComprar : Form
    {
        MySqlDataReader dr;
        MySqlDataAdapter da;
        public frmComprar()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "SELECT * FROM produtos";

            da = new MySqlDataAdapter(comandoSQL, conexao);

            DataTable dataTable = new DataTable();

            da.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            MessageBox.Show("DADOS SELECIONADOS");

            conexao.Close();
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "SELECT * FROM produtos WHERE id='" + txtId.Text + "'";
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();
            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                lblTotal.Text = Convert.ToString(dr["valor"])+",00";
            }

            MessageBox.Show("DADOS SELECIONADOS");

            comando.Dispose();
            conexao.Close();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "UPDATE produtos SET quantidade = quantidade - 1 WHERE id='" + txtId.Text + "'";
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();
            comando.ExecuteNonQuery();

            MessageBox.Show("Produto comprado");

            comando.Dispose();
            conexao.Close();
            lblTotal.Text = "";
            txtId.Text = "";
            dataGridView1.DataSource = "";
            rdbCartao.Checked = false;
            rdbDinheiro.Checked = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Compra cancelada");
            lblTotal.Text = "";
            txtId.Text = "";
            dataGridView1.DataSource = "";
            rdbCartao.Checked = false;
            rdbDinheiro.Checked = false;
        }
    }
}
