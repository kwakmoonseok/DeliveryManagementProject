using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DeliveryManagement_Client
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlconn = null;
        private string constr = "SERVER = 127.0.0.1, 1433; DATABASE = WinFormProject;" + "UID = sa; PASSWORD = 1234";
        public Form1()
        {
            InitializeComponent();

            try
            {
                sqlconn = new SqlConnection(constr);
                sqlconn.Open();

                MessageBox.Show("DB 연결 성공");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            FormClosing += new FormClosingEventHandler(closing);
        }

        private void closing(Object sender, FormClosingEventArgs e)
        {
            if (sqlconn != null)
            {
                sqlconn.Close();
            }

            Application.Exit();
        }

         private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 open = new Form2();
            open.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 open = new Form3();
            open.ShowDialog();
     
        }
    }
}
