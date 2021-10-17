using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProjetoProgramacaoVisual
{
    public partial class Registrar : Form
    {
        private MySqlConnection conn;
        public Registrar()
        { 
            string connString;
            connString = $"datasource=localhost;username=root;password=;database=projetovisual;SSL Mode=None;";
            conn = new MySqlConnection(connString);

            InitializeComponent();
        }

        private void btnRegistrarSe_Click(object sender, EventArgs e)
        {
            string nome = txtNomeUsuario.Text;
            string email = txtEmail.Text;
            string telefone = txtTelefone.Text;
            string senha = txtSenha.Text;
            string confirmarSenha = txtConfSenha.Text;

            if(confirmarSenha == senha)
            {
                if (RegisterFunc(nome, email, telefone, senha))
                {
                    this.Close();
                    MessageBox.Show($"Usuário {nome} cadastrado");
                }
                else
                {
                    MessageBox.Show($"Usuário não cadastrado");
                }
            }
            else
            {
                MessageBox.Show($"Confirmar senha e senha diferentes");
            }

        }

        public bool RegisterFunc(string nome, string email, string telefone, string senha)
        {
            string query = $"INSERT INTO logincadastro(id,nome,email,telefone,senha) VALUES('','{nome}','{email}','{telefone}','{senha}');";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception )
                    {
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception )
            {
                conn.Clone();
                return false;
            }
        }

        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Conexão falhada");
                        break;
                    case 1045:
                        MessageBox.Show("Usuario ou senha incoretos");
                        break;
                }
                return false;
            }
        }
    }
}
