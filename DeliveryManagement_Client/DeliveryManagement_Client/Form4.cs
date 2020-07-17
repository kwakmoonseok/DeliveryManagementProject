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
    public partial class Form4 : Form
    {
        string tempID;
        SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;
        private SqlConnection sqlconn = null;
        private string constr = "SERVER = 127.0.0.1, 1433; DATABASE = WinFormProject;" + "UID = sa; PASSWORD = 1234";


        public Form4()
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
                cmd.CommandText = "SELECT * FROM CustInfor";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                if (textBox1.Text == "")
                    MessageBox.Show("이름을 입력해주세요");

                else if (textBox2.Text == "")
                {
                    MessageBox.Show("ID를 입력해주세요");
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("전화번호를 입력해주세요");
                }

                else
                {

                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO CustInfor (CustId, CustName, PhoneNum) VALUES ('" + textBox2.Text + "', '" + textBox1.Text + "', '" + textBox7.Text + "')";

                    conn.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM CustInfor";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;


                    conn.Close();

                }
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // 여기서부터 수정
        {
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            tempID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                if (textBox4.Text == "") {
                    MessageBox.Show("이름을 입력해주세요");
                }

                else if (textBox8.Text == "")
                {
                    MessageBox.Show("전화번호를 입력해주세요");
                }

                else
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE CustInfor SET CustName = '" + textBox4.Text + "', PhoneNum = '" + textBox8.Text + "' WHERE CustId = '" + tempID + "';";

                    conn.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM CustInfor";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;

                    conn.Close();
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                if (textBox6.Text == "")
                    MessageBox.Show("이름을 입력해주세요");

                else if (textBox5.Text == "")
                {
                    MessageBox.Show("ID를 입력해주세요");
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("전화번호를 입력해주세요");
                }

                else
                {

                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM CustInfor WHERE CustId = '" + textBox5.Text + "'AND CustName = '" + textBox6.Text + "' AND PhoneNum = '" + textBox9.Text + "';";

                    conn.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }


                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM CustInfor";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;


                    conn.Close();

                }

            }
        }
    }
}
