using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProjetoProgramacaoVisual
{
    public partial class Registrar : Form
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string ssl;

        public Registrar()
        {
            server = "localhost";
            uid = "root";
            password = "";
            database = "tut";
            ssl = "None";


            string connString;
            connString = $"datasource={server};username={uid};password={password};database={database};SSL Mode={ssl};";

            conn = new MySqlConnection(connString);

            InitializeComponent();
        }

        private void btnRegistrarSe_Click(object sender, EventArgs e)
        {
            string user = txtNomeUsuario.Text;
            string pass = txtSenha.Text;


            if (RegisterFunc(user, pass))
            {
                this.Close();
                MessageBox.Show($"Usuário {user} cadastrado");
            }
            else
            {
                MessageBox.Show($"Usuário não cadastrado");
            }
        }

        public bool RegisterFunc(string user, string pass)
        {
            string query = $"INSERT INTO users(id,username,password) VALUES('','{user}','{pass}');";

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
