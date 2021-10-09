using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoProgramacaoVisual
{
    public partial class Login : Form
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string ssl;

        public Login()
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtNomeUsuarioEntrar.Text;
            string pass = txtSenhaEntrar.Text;

            if (IsLogin(user, pass))
            {
                MessageBox.Show($"Bem vindo {user}!");
                Home HomeForm = new Home();
                HomeForm.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show($"Usuário {user} não existe ou senha incorreta");
            }
        }

        public bool IsLogin(string user, string pass)
        {
            string query = $"SELECT * FROM users WHERE username='{user}' AND password='{pass}';";

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
            }catch(Exception ex)
            {
                conn.Close();
                return false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registrar RegisterForm = new Registrar();
            RegisterForm.ShowDialog();
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
    }
}
