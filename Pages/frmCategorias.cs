using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProjetoProgramacaoVisual.Pages
{
    public partial class frmCategorias : Form
    {
        MySqlDataReader dr;
        MySqlDataAdapter da;
        
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSL Mode=none;");
            string comandoSQL = "INSERT INTO categorias (nome,descricao) VALUES ('" + txtNome.Text + "','" + txtDescricao.Text + "')";
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();
            comando.ExecuteNonQuery();

            MessageBox.Show("DADOS SALVOS");

            comando.Dispose();
            conexao.Close();
            txtNome.Text = "";
            txtDescricao.Text = "";
            dataGridView1.DataSource = "";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "UPDATE categorias SET nome='" + txtNome.Text + "',descricao='" + txtDescricao.Text + "' WHERE id='" + txtId.Text + "'";
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();
            comando.ExecuteNonQuery();

            MessageBox.Show("DADOS ATUALIZADOS");

            comando.Dispose();
            conexao.Close();
            txtId.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            dataGridView1.DataSource = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "DELETE FROM categorias WHERE id='" + txtId.Text + "'";
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();
            comando.ExecuteNonQuery();

            MessageBox.Show("DADOS DELETADOS");

            comando.Dispose();
            conexao.Close();
            txtId.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            dataGridView1.DataSource = "";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "SELECT * FROM categorias WHERE id='" + txtId.Text + "'";
            MySqlCommand comando = new MySqlCommand(comandoSQL, conexao);

            conexao.Open();
            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                txtNome.Text = Convert.ToString(dr["nome"]);
                txtDescricao.Text = Convert.ToString(dr["descricao"]);
            }

            MessageBox.Show("DADOS SELECIONADOS");

            comando.Dispose();
            conexao.Close();
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            MySqlConnection conexao = new MySqlConnection("server=localhost;uid=root;pwd='';database=projetovisual;SSLMode=none;");
            string comandoSQL = "SELECT id,nome,descricao FROM categorias";

            da = new MySqlDataAdapter(comandoSQL, conexao);

            DataTable dataTable = new DataTable();

            da.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            MessageBox.Show("DADOS SELECIONADOS");

            conexao.Close();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                btnConsultar.Enabled = false;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            else
            {
                btnConsultar.Enabled = true;
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
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
