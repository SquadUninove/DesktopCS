﻿using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoProgramacaoVisual
{
    public partial class Login : Form
    {
        private MySqlConnection conn;

        public Login()
        {
            string connString;
            connString = $"datasource=localhost;username=root;password=;database=projetovisual;SSL Mode=None;";
            conn = new MySqlConnection(connString);

            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nome = txtNomeUsuarioEntrar.Text;
            string senha = txtSenhaEntrar.Text;

            if(txtNomeUsuarioEntrar.Text == "" || txtSenhaEntrar.Text == "")
            {
                MessageBox.Show("Usuário ou senha não digitados");
            }
            else
            {
                if (IsLogin(nome, senha))
                {
                    MessageBox.Show($"Bem vindo {nome}!");
                    this.Hide();
                    var Home = new Home();
                    Home.Closed += (s, args) => this.Close();
                    Home.Show();
                }
                else
                {
                    MessageBox.Show($"Usuário não existe ou senha incorreta");
                }
            }

        }

        public bool IsLogin(string nome, string senha)
        {
            string query = $"SELECT * FROM logincadastro WHERE nome='{nome}' AND senha='{senha}';";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }catch(Exception)
            {
                conn.Close();
                return false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Registrar = new Registrar();
            Registrar.Closed += (s, args) => this.Show();
            Registrar.Show();
        }

        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }catch(MySqlException ex)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
