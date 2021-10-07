using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoProgramacaoVisual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DBConnection()
        {
            string ConnectString = "datasource = localhost; username = root; password=; database = testforcs; SSL Mode=None;";
            MySqlConnection DBConnect = new MySqlConnection(ConnectString);
            try
            {
                DBConnect.Open();
                MessageBox.Show("Ok, conectado");
            }catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DBConnection();
        }
    }
}
