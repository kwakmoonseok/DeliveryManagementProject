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

namespace DeliveryManagement
{
    public partial class Form5 : Form
    {

        SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;
        private SqlConnection sqlconn = null;
        private string constr = "SERVER = 127.0.0.1, 1433; DATABASE = WinFormProject;" + "UID = sa; PASSWORD = 1234";

 
        public Form5()
        {
            InitializeComponent();

            cmd = new SqlCommand();

            try
            {
                sqlconn = new SqlConnection(constr);
                sqlconn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                cmd.Connection = conn;
                cmd.CommandText = "select ReceiverInfor.ReceiptNum, CustInfor.*, LockerInfor.LockerNum, LockerInfor.StoredTime, LockerInfor.ItemName, ReceiverInfor.ReceiptTime from CustInfor, LockerInfor, ReceiverInfor where ReceiverInfor.Custid = CustInfor.CustId AND ReceiverInfor.LockerNum = LockerInfor.LockerNum";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
