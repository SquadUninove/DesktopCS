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
    public partial class frmProdutos : Form
    {
        MySqlDataReader dr;
        MySqlDataAdapter da;
        public frmProdutos()
        { 
            InitializeComponent();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "SELECT id,nome,descricao,valor,quantidade FROM produtos";

            da = new MySqlDataAdapter(comandoSQL, conexao);

            DataTable dataTable = new DataTable();

            da.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            MessageBox.Show("DADOS SELECIONADOS");

            conexao.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
                btnInserir.Enabled = true;
                MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSL Mode=none;");
                string comandoSQL = "INSERT INTO produtos (nome,descricao,valor,quantidade) VALUES ('" + txtNome.Text + "','" + txtDescricao.Text + "','" + txtValor.Text + "','" + txtQuantidade.Text + "')";
                MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

                conexao.Open();
                comando.ExecuteNonQuery();

                MessageBox.Show("DADOS SALVOS");

                comando.Dispose();
                conexao.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "UPDATE produtos SET nome='" + txtNome.Text + "',descricao='" + txtDescricao.Text + "',valor='" + txtValor.Text + "',quantidade='" + txtQuantidade.Text + "' WHERE id='" + txtId.Text + "'";
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();
            comando.ExecuteNonQuery();

            MessageBox.Show("DADOS ATUALIZADOS");

            comando.Dispose();
            conexao.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "DELETE FROM produtos WHERE id='" + txtId.Text + "'";
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();
            comando.ExecuteNonQuery();

            MessageBox.Show("DADOS DELETADOS");

            comando.Dispose();
            conexao.Close();
        }

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "SELECT * FROM produtos WHERE id='" + txtId.Text + "'";
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();
            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                txtNome.Text = Convert.ToString(dr["nome"]);
                txtDescricao.Text = Convert.ToString(dr["descricao"]);
                txtValor.Text = Convert.ToString(dr["valor"]);
                txtQuantidade.Text = Convert.ToString(dr["quantidade"]);
            }

            MessageBox.Show("DADOS SELECIONADOS");

            comando.Dispose();
            conexao.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if(txtNome.Text == "")
            {
                btnInserir.Enabled = false;
            }
            else
            {
                btnInserir.Enabled = true;
            }
        }
    }
}
