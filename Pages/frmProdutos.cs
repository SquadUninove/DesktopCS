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
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string ssl;

        public frmProdutos()
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
