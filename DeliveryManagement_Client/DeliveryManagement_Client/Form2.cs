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
    public partial class Form2 : Form
    {
        private SqlConnection sqlconn = null;
        private string constr = "SERVER = 127.0.0.1, 1433; DATABASE = WinFormProject;" + "UID = sa; PASSWORD = 1234";
        public Form2()
        {
            InitializeComponent();

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
            int lockernum = 1;
            bool itemExist = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT ItemName, Passwd FROM LockerInfor WHERE LockerNum = " + lockernum;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    if (!string.IsNullOrWhiteSpace(reader.ToString()))
                    {
                        MessageBox.Show("이미 택배함 안에 물건이 존재합니다.");
                        itemExist = true;
                    }
                }

                conn.Close();

                if (!itemExist)
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                        MessageBox.Show("물건 이름을 입력해주세요.");
                    if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show("비밀번호를 입력해주세요.");
                    else
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                        command.ExecuteNonQuery();

                        MessageBox.Show("물건이 성공적으로 보관되었습니다.");
                    }
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int lockernum = 2;
            bool itemExist = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT ItemName, Passwd FROM LockerInfor WHERE LockerNum = " + lockernum;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    if (!string.IsNullOrWhiteSpace(reader.ToString()))
                    {
                        MessageBox.Show("이미 택배함 안에 물건이 존재합니다.");
                        itemExist = true;
                    }
                }

                conn.Close();

                if (!itemExist)
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                        MessageBox.Show("물건 이름을 입력해주세요.");
                    if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show("비밀번호를 입력해주세요.");
                    else
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                        command.ExecuteNonQuery();

                        MessageBox.Show("물건이 성공적으로 보관되었습니다.");
                    }
                    conn.Close();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int lockernum = 3;
            bool itemExist = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT ItemName, Passwd FROM LockerInfor WHERE LockerNum = " + lockernum;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    if (!string.IsNullOrWhiteSpace(reader.ToString()))
                    {
                        MessageBox.Show("이미 택배함 안에 물건이 존재합니다.");
                        itemExist = true;
                    }
                }

                conn.Close();

                if (!itemExist)
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                        MessageBox.Show("물건 이름을 입력해주세요.");
                    if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show("비밀번호를 입력해주세요.");
                    else
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                        command.ExecuteNonQuery();

                        MessageBox.Show("물건이 성공적으로 보관되었습니다.");
                    }
                    conn.Close();
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int lockernum = 4;
            bool itemExist = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT ItemName, Passwd FROM LockerInfor WHERE LockerNum = " + lockernum;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    if (!string.IsNullOrWhiteSpace(reader.ToString()))
                    {
                        MessageBox.Show("이미 택배함 안에 물건이 존재합니다.");
                        itemExist = true;
                    }
                }

                conn.Close();

                if (!itemExist)
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                        MessageBox.Show("물건 이름을 입력해주세요.");
                    if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show("비밀번호를 입력해주세요.");
                    else
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                        command.ExecuteNonQuery();

                        MessageBox.Show("물건이 성공적으로 보관되었습니다.");
                    }
                    conn.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int lockernum = 5;
            bool itemExist = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT ItemName, Passwd FROM LockerInfor WHERE LockerNum = " + lockernum;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    if (!string.IsNullOrWhiteSpace(reader.ToString()))
                    {
                        MessageBox.Show("이미 택배함 안에 물건이 존재합니다.");
                        itemExist = true;
                    }
                }

                conn.Close();

                if (!itemExist)
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                        MessageBox.Show("물건 이름을 입력해주세요.");
                    if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show("비밀번호를 입력해주세요.");
                    else
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                        command.ExecuteNonQuery();

                        MessageBox.Show("물건이 성공적으로 보관되었습니다.");
                    }
                    conn.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int lockernum = 6;
            bool itemExist = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT ItemName, Passwd FROM LockerInfor WHERE LockerNum = " + lockernum;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    if (!string.IsNullOrWhiteSpace(reader.ToString()))
                    {
                        MessageBox.Show("이미 택배함 안에 물건이 존재합니다.");
                        itemExist = true;
                    }
                }

                conn.Close();

                if (!itemExist)
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                        MessageBox.Show("물건 이름을 입력해주세요.");
                    if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show("비밀번호를 입력해주세요.");
                    else
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                        command.ExecuteNonQuery();

                        MessageBox.Show("물건이 성공적으로 보관되었습니다.");
                    }
                    conn.Close();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int lockernum = 7;
            bool itemExist = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT ItemName, Passwd FROM LockerInfor WHERE LockerNum = " + lockernum;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    if (!string.IsNullOrWhiteSpace(reader.ToString()))
                    {
                        MessageBox.Show("이미 택배함 안에 물건이 존재합니다.");
                        itemExist = true;
                    }
                }

                conn.Close();

                if (!itemExist)
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                        MessageBox.Show("물건 이름을 입력해주세요.");
                    if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show("비밀번호를 입력해주세요.");
                    else
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                        command.ExecuteNonQuery();

                        MessageBox.Show("물건이 성공적으로 보관되었습니다.");
                    }
                    conn.Close();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int lockernum = 8;
            bool itemExist = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT ItemName, Passwd FROM LockerInfor WHERE LockerNum = " + lockernum;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    if (!string.IsNullOrWhiteSpace(reader.ToString()))
                    {
                        MessageBox.Show("이미 택배함 안에 물건이 존재합니다.");
                        itemExist = true;
                    }
                }

                conn.Close();

                if (!itemExist)
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                        MessageBox.Show("물건 이름을 입력해주세요.");
                    if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show("비밀번호를 입력해주세요.");
                    else
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                        command.ExecuteNonQuery();

                        MessageBox.Show("물건이 성공적으로 보관되었습니다.");
                    }
                    conn.Close();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int lockernum = 9;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();

                SqlCommand command = new SqlCommand();

                if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                    MessageBox.Show("물건 이름을 입력해주세요.");
                if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                    MessageBox.Show("비밀번호를 입력해주세요.");
                else
                {
                    command.Connection = conn;
                    command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }bool itemExist = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT ItemName, Passwd FROM LockerInfor WHERE LockerNum = " + lockernum;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    if (!string.IsNullOrWhiteSpace(reader.ToString()))
                    {
                        MessageBox.Show("이미 택배함 안에 물건이 존재합니다.");
                        itemExist = true;
                    }
                }

                conn.Close();

                if (!itemExist)
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                        MessageBox.Show("물건 이름을 입력해주세요.");
                    if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show("비밀번호를 입력해주세요.");
                    else
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                        command.ExecuteNonQuery();

                        MessageBox.Show("물건이 성공적으로 보관되었습니다.");
                    }
                    conn.Close();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int lockernum = 10;
            bool itemExist = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                
                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT ItemName, Passwd FROM LockerInfor WHERE LockerNum = " + lockernum;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()){
                    if (!string.IsNullOrWhiteSpace(reader.ToString()))
                    {
                        MessageBox.Show("이미 택배함 안에 물건이 존재합니다.");
                        itemExist = true;
                    }
                }

                conn.Close();

                if (!itemExist)
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) && string.IsNullOrEmpty(textBox2.Text))
                        MessageBox.Show("물건 이름을 입력해주세요.");
                    if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        MessageBox.Show("비밀번호를 입력해주세요.");
                    else
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "UPDATE LockerInfor SET ItemName = '" + textBox2.Text + "', Passwd = '" + textBox1.Text + "', StoredTime = '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "' WHERE LockerNum = " + lockernum;
                        command.ExecuteNonQuery();

                        MessageBox.Show("물건이 성공적으로 보관되었습니다.");
                    }
                    conn.Close();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
