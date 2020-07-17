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
    public partial class Form3 : Form
    {
        private SqlConnection sqlconn = null;
        private string constr = "SERVER = 127.0.0.1, 1433; DATABASE = WinFormProject;" + "UID = sa; PASSWORD = 1234";

        public Form3()
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
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            int lockernum = 1;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                bool succeedToFindUser = false;
                bool succeedToCheckPasswd = false;

                int receiptCount = 0;

                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT * FROM LockerInfor WHERE LockerNum = " + lockernum + "; SELECT * FROM CustInfor;";

                conn.Open();

                SqlDataReader userCheckreader = command.ExecuteReader();

                if (userCheckreader.Read())
                {
                    string lockerPasswd = userCheckreader["Passwd"].ToString().Trim();

                    if (userCheckreader.NextResult()){
                        List<string> userIdList = new List<string>();
                        List<string> userNameList = new List<string>();
                        while (userCheckreader.Read())
                        {
                            userIdList.Add(userCheckreader["CustId"].ToString().Trim());
                            userNameList.Add(userCheckreader["CustName"].ToString().Trim());
                        }
                        for (int i = 0; i < userIdList.Count; i++){
                            if (textBox2.Text.Trim().Equals(lockerPasswd) && textBox1.Text.Trim().Equals(userIdList[i]))
                            {
                                MessageBox.Show(userNameList[i] + "님께서 물건을 수령하셨습니다.");
                                conn.Close();

                                if (succeedToFindUser && succeedToCheckPasswd)
                                {
                                    conn.Open();
                                    command.CommandText = "SELECT count(*) from ReceiverInfor;";
                                    receiptCount = Convert.ToInt16(command.ExecuteScalar()) + 1;
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "INSERT INTO ReceiverInfor VALUES (" + receiptCount + ", '" + userIdList[i] + "', " + lockernum + ", '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "');";
                                    command.ExecuteNonQuery();
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "UPDATE LockerInfor SET ItemName = NULL, Passwd = NULL, StoredTime = NULL WHERE LockerNum = " + lockernum + ";";
                                    command.ExecuteNonQuery();
                                }

                                

                                if (textBox2.Text.Trim().Equals(lockerPasswd))
                                {
                                    succeedToFindUser = true;
                                    succeedToCheckPasswd = false;
                                }
                                if (textBox1.Text.Trim().Equals(userIdList[i]))
                                    succeedToCheckPasswd = true;

                                
                                
                            }       
                        }
                        if (string.IsNullOrEmpty(lockerPasswd))
                            MessageBox.Show("택배함 안에 물건이 없습니다.");
                        else
                        {
                            if (!succeedToFindUser)
                                MessageBox.Show("그런 ID를 가진 유저를 찾을 수 없습니다.");
                            if (!succeedToCheckPasswd)
                                MessageBox.Show("비밀번호가 일치하지 않습니다,");
                        }
                    }
                }
                conn.Close();
            }  
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int lockernum = 2;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                bool succeedToFindUser = false;
                bool succeedToCheckPasswd = false;

                int receiptCount = 0;

                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT * FROM LockerInfor WHERE LockerNum = " + lockernum + "; SELECT * FROM CustInfor;";

                conn.Open();

                SqlDataReader userCheckreader = command.ExecuteReader();

                if (userCheckreader.Read())
                {
                    string lockerPasswd = userCheckreader["Passwd"].ToString().Trim();

                    if (userCheckreader.NextResult()){
                        List<string> userIdList = new List<string>();
                        List<string> userNameList = new List<string>();
                        while (userCheckreader.Read())
                        {
                            userIdList.Add(userCheckreader["CustId"].ToString().Trim());
                            userNameList.Add(userCheckreader["CustName"].ToString().Trim());
                        }
                        for (int i = 0; i < userIdList.Count; i++){
                            if (textBox2.Text.Trim().Equals(lockerPasswd) && textBox1.Text.Trim().Equals(userIdList[i]))
                            {
                                MessageBox.Show(userNameList[i] + "님께서 물건을 수령하셨습니다.");
                                conn.Close();

                                if (succeedToFindUser && succeedToCheckPasswd)
                                {
                                    conn.Open();
                                    command.CommandText = "SELECT count(*) from ReceiverInfor;";
                                    receiptCount = Convert.ToInt16(command.ExecuteScalar()) + 1;
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "INSERT INTO ReceiverInfor VALUES (" + receiptCount + ", '" + userIdList[i] + "', " + lockernum + ", '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "');";
                                    command.ExecuteNonQuery();
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "UPDATE LockerInfor SET ItemName = NULL, Passwd = NULL, StoredTime = NULL WHERE LockerNum = " + lockernum + ";";
                                    command.ExecuteNonQuery();
                                }

                                

                                if (textBox2.Text.Trim().Equals(lockerPasswd))
                                {
                                    succeedToFindUser = true;
                                    succeedToCheckPasswd = false;
                                }
                                if (textBox1.Text.Trim().Equals(userIdList[i]))
                                    succeedToCheckPasswd = true;

                                
                                
                            }       
                        }
                        if (string.IsNullOrEmpty(lockerPasswd))
                            MessageBox.Show("택배함 안에 물건이 없습니다.");
                        else
                        {
                            if (!succeedToFindUser)
                                MessageBox.Show("그런 ID를 가진 유저를 찾을 수 없습니다.");
                            if (!succeedToCheckPasswd)
                                MessageBox.Show("비밀번호가 일치하지 않습니다,");
                        }
                    }
                }
                conn.Close();
            }  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int lockernum = 3;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                bool succeedToFindUser = false;
                bool succeedToCheckPasswd = false;

                int receiptCount = 0;

                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT * FROM LockerInfor WHERE LockerNum = " + lockernum + "; SELECT * FROM CustInfor;";

                conn.Open();

                SqlDataReader userCheckreader = command.ExecuteReader();

                if (userCheckreader.Read())
                {
                    string lockerPasswd = userCheckreader["Passwd"].ToString().Trim();

                    if (userCheckreader.NextResult()){
                        List<string> userIdList = new List<string>();
                        List<string> userNameList = new List<string>();
                        while (userCheckreader.Read())
                        {
                            userIdList.Add(userCheckreader["CustId"].ToString().Trim());
                            userNameList.Add(userCheckreader["CustName"].ToString().Trim());
                        }
                        for (int i = 0; i < userIdList.Count; i++){
                            if (textBox2.Text.Trim().Equals(lockerPasswd) && textBox1.Text.Trim().Equals(userIdList[i]))
                            {
                                MessageBox.Show(userNameList[i] + "님께서 물건을 수령하셨습니다.");
                                conn.Close();

                                if (succeedToFindUser && succeedToCheckPasswd)
                                {
                                    conn.Open();
                                    command.CommandText = "SELECT count(*) from ReceiverInfor;";
                                    receiptCount = Convert.ToInt16(command.ExecuteScalar()) + 1;
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "INSERT INTO ReceiverInfor VALUES (" + receiptCount + ", '" + userIdList[i] + "', " + lockernum + ", '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "');";
                                    command.ExecuteNonQuery();
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "UPDATE LockerInfor SET ItemName = NULL, Passwd = NULL, StoredTime = NULL WHERE LockerNum = " + lockernum + ";";
                                    command.ExecuteNonQuery();
                                }

                                

                                if (textBox2.Text.Trim().Equals(lockerPasswd))
                                {
                                    succeedToFindUser = true;
                                    succeedToCheckPasswd = false;
                                }
                                if (textBox1.Text.Trim().Equals(userIdList[i]))
                                    succeedToCheckPasswd = true;

                                
                                
                            }       
                        }
                        if (string.IsNullOrEmpty(lockerPasswd))
                            MessageBox.Show("택배함 안에 물건이 없습니다.");
                        else
                        {
                            if (!succeedToFindUser)
                                MessageBox.Show("그런 ID를 가진 유저를 찾을 수 없습니다.");
                            if (!succeedToCheckPasswd)
                                MessageBox.Show("비밀번호가 일치하지 않습니다,");
                        }
                    }
                }
                conn.Close();
            }  
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            int lockernum = 4;
           using (SqlConnection conn = new SqlConnection(constr))
            {
                bool succeedToFindUser = false;
                bool succeedToCheckPasswd = false;

                int receiptCount = 0;

                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT * FROM LockerInfor WHERE LockerNum = " + lockernum + "; SELECT * FROM CustInfor;";

                conn.Open();

                SqlDataReader userCheckreader = command.ExecuteReader();

                if (userCheckreader.Read())
                {
                    string lockerPasswd = userCheckreader["Passwd"].ToString().Trim();

                    if (userCheckreader.NextResult()){
                        List<string> userIdList = new List<string>();
                        List<string> userNameList = new List<string>();
                        while (userCheckreader.Read())
                        {
                            userIdList.Add(userCheckreader["CustId"].ToString().Trim());
                            userNameList.Add(userCheckreader["CustName"].ToString().Trim());
                        }
                        for (int i = 0; i < userIdList.Count; i++){
                            if (textBox2.Text.Trim().Equals(lockerPasswd) && textBox1.Text.Trim().Equals(userIdList[i]))
                            {
                                MessageBox.Show(userNameList[i] + "님께서 물건을 수령하셨습니다.");
                                conn.Close();

                                if (succeedToFindUser && succeedToCheckPasswd)
                                {
                                    conn.Open();
                                    command.CommandText = "SELECT count(*) from ReceiverInfor;";
                                    receiptCount = Convert.ToInt16(command.ExecuteScalar()) + 1;
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "INSERT INTO ReceiverInfor VALUES (" + receiptCount + ", '" + userIdList[i] + "', " + lockernum + ", '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "');";
                                    command.ExecuteNonQuery();
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "UPDATE LockerInfor SET ItemName = NULL, Passwd = NULL, StoredTime = NULL WHERE LockerNum = " + lockernum + ";";
                                    command.ExecuteNonQuery();
                                }

                                

                                if (textBox2.Text.Trim().Equals(lockerPasswd))
                                {
                                    succeedToFindUser = true;
                                    succeedToCheckPasswd = false;
                                }
                                if (textBox1.Text.Trim().Equals(userIdList[i]))
                                    succeedToCheckPasswd = true;

                                
                                
                            }       
                        }
                        if (string.IsNullOrEmpty(lockerPasswd))
                            MessageBox.Show("택배함 안에 물건이 없습니다.");
                        else
                        {
                            if (!succeedToFindUser)
                                MessageBox.Show("그런 ID를 가진 유저를 찾을 수 없습니다.");
                            if (!succeedToCheckPasswd)
                                MessageBox.Show("비밀번호가 일치하지 않습니다,");
                        }
                    }
                }
                conn.Close();
            }  
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int lockernum = 5;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                bool succeedToFindUser = false;
                bool succeedToCheckPasswd = false;

                int receiptCount = 0;

                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT * FROM LockerInfor WHERE LockerNum = " + lockernum + "; SELECT * FROM CustInfor;";

                conn.Open();

                SqlDataReader userCheckreader = command.ExecuteReader();

                if (userCheckreader.Read())
                {
                    string lockerPasswd = userCheckreader["Passwd"].ToString().Trim();

                    if (userCheckreader.NextResult()){
                        List<string> userIdList = new List<string>();
                        List<string> userNameList = new List<string>();
                        while (userCheckreader.Read())
                        {
                            userIdList.Add(userCheckreader["CustId"].ToString().Trim());
                            userNameList.Add(userCheckreader["CustName"].ToString().Trim());
                        }
                        for (int i = 0; i < userIdList.Count; i++){
                            if (textBox2.Text.Trim().Equals(lockerPasswd) && textBox1.Text.Trim().Equals(userIdList[i]))
                            {
                                MessageBox.Show(userNameList[i] + "님께서 물건을 수령하셨습니다.");
                                conn.Close();

                                if (succeedToFindUser && succeedToCheckPasswd)
                                {
                                    conn.Open();
                                    command.CommandText = "SELECT count(*) from ReceiverInfor;";
                                    receiptCount = Convert.ToInt16(command.ExecuteScalar()) + 1;
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "INSERT INTO ReceiverInfor VALUES (" + receiptCount + ", '" + userIdList[i] + "', " + lockernum + ", '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "');";
                                    command.ExecuteNonQuery();
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "UPDATE LockerInfor SET ItemName = NULL, Passwd = NULL, StoredTime = NULL WHERE LockerNum = " + lockernum + ";";
                                    command.ExecuteNonQuery();
                                }

                                

                                if (textBox2.Text.Trim().Equals(lockerPasswd))
                                {
                                    succeedToFindUser = true;
                                    succeedToCheckPasswd = false;
                                }
                                if (textBox1.Text.Trim().Equals(userIdList[i]))
                                    succeedToCheckPasswd = true;

                                
                                
                            }       
                        }
                        if (string.IsNullOrEmpty(lockerPasswd))
                            MessageBox.Show("택배함 안에 물건이 없습니다.");
                        else
                        {
                            if (!succeedToFindUser)
                                MessageBox.Show("그런 ID를 가진 유저를 찾을 수 없습니다.");
                            if (!succeedToCheckPasswd)
                                MessageBox.Show("비밀번호가 일치하지 않습니다,");
                        }
                    }
                }
                conn.Close();
            }  
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int lockernum = 6;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                bool succeedToFindUser = false;
                bool succeedToCheckPasswd = false;

                int receiptCount = 0;

                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT * FROM LockerInfor WHERE LockerNum = " + lockernum + "; SELECT * FROM CustInfor;";

                conn.Open();

                SqlDataReader userCheckreader = command.ExecuteReader();

                if (userCheckreader.Read())
                {
                    string lockerPasswd = userCheckreader["Passwd"].ToString().Trim();

                    if (userCheckreader.NextResult()){
                        List<string> userIdList = new List<string>();
                        List<string> userNameList = new List<string>();
                        while (userCheckreader.Read())
                        {
                            userIdList.Add(userCheckreader["CustId"].ToString().Trim());
                            userNameList.Add(userCheckreader["CustName"].ToString().Trim());
                        }
                        for (int i = 0; i < userIdList.Count; i++){
                            if (textBox2.Text.Trim().Equals(lockerPasswd) && textBox1.Text.Trim().Equals(userIdList[i]))
                            {
                                MessageBox.Show(userNameList[i] + "님께서 물건을 수령하셨습니다.");
                                conn.Close();

                                if (succeedToFindUser && succeedToCheckPasswd)
                                {
                                    conn.Open();
                                    command.CommandText = "SELECT count(*) from ReceiverInfor;";
                                    receiptCount = Convert.ToInt16(command.ExecuteScalar()) + 1;
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "INSERT INTO ReceiverInfor VALUES (" + receiptCount + ", '" + userIdList[i] + "', " + lockernum + ", '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "');";
                                    command.ExecuteNonQuery();
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "UPDATE LockerInfor SET ItemName = NULL, Passwd = NULL, StoredTime = NULL WHERE LockerNum = " + lockernum + ";";
                                    command.ExecuteNonQuery();
                                }

                                

                                if (textBox2.Text.Trim().Equals(lockerPasswd))
                                {
                                    succeedToFindUser = true;
                                    succeedToCheckPasswd = false;
                                }
                                if (textBox1.Text.Trim().Equals(userIdList[i]))
                                    succeedToCheckPasswd = true;

                                
                                
                            }       
                        }
                        if (string.IsNullOrEmpty(lockerPasswd))
                            MessageBox.Show("택배함 안에 물건이 없습니다.");
                        else
                        {
                            if (!succeedToFindUser)
                                MessageBox.Show("그런 ID를 가진 유저를 찾을 수 없습니다.");
                            if (!succeedToCheckPasswd)
                                MessageBox.Show("비밀번호가 일치하지 않습니다,");
                        }
                    }
                }
                conn.Close();
            }  
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            int lockernum = 7;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                bool succeedToFindUser = false;
                bool succeedToCheckPasswd = false;

                int receiptCount = 0;

                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT * FROM LockerInfor WHERE LockerNum = " + lockernum + "; SELECT * FROM CustInfor;";

                conn.Open();

                SqlDataReader userCheckreader = command.ExecuteReader();

                if (userCheckreader.Read())
                {
                    string lockerPasswd = userCheckreader["Passwd"].ToString().Trim();

                    if (userCheckreader.NextResult()){
                        List<string> userIdList = new List<string>();
                        List<string> userNameList = new List<string>();
                        while (userCheckreader.Read())
                        {
                            userIdList.Add(userCheckreader["CustId"].ToString().Trim());
                            userNameList.Add(userCheckreader["CustName"].ToString().Trim());
                        }
                        for (int i = 0; i < userIdList.Count; i++){
                            if (textBox2.Text.Trim().Equals(lockerPasswd) && textBox1.Text.Trim().Equals(userIdList[i]))
                            {
                                MessageBox.Show(userNameList[i] + "님께서 물건을 수령하셨습니다.");
                                conn.Close();

                                if (succeedToFindUser && succeedToCheckPasswd)
                                {
                                    conn.Open();
                                    command.CommandText = "SELECT count(*) from ReceiverInfor;";
                                    receiptCount = Convert.ToInt16(command.ExecuteScalar()) + 1;
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "INSERT INTO ReceiverInfor VALUES (" + receiptCount + ", '" + userIdList[i] + "', " + lockernum + ", '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "');";
                                    command.ExecuteNonQuery();
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "UPDATE LockerInfor SET ItemName = NULL, Passwd = NULL, StoredTime = NULL WHERE LockerNum = " + lockernum + ";";
                                    command.ExecuteNonQuery();
                                }

                                

                                if (textBox2.Text.Trim().Equals(lockerPasswd))
                                {
                                    succeedToFindUser = true;
                                    succeedToCheckPasswd = false;
                                }
                                if (textBox1.Text.Trim().Equals(userIdList[i]))
                                    succeedToCheckPasswd = true;

                                
                                
                            }       
                        }
                        if (string.IsNullOrEmpty(lockerPasswd))
                            MessageBox.Show("택배함 안에 물건이 없습니다.");
                        else
                        {
                            if (!succeedToFindUser)
                                MessageBox.Show("그런 ID를 가진 유저를 찾을 수 없습니다.");
                            if (!succeedToCheckPasswd)
                                MessageBox.Show("비밀번호가 일치하지 않습니다,");
                        }
                    }
                }
                conn.Close();
            }  
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            int lockernum = 8;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                bool succeedToFindUser = false;
                bool succeedToCheckPasswd = false;

                int receiptCount = 0;

                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT * FROM LockerInfor WHERE LockerNum = " + lockernum + "; SELECT * FROM CustInfor;";

                conn.Open();

                SqlDataReader userCheckreader = command.ExecuteReader();

                if (userCheckreader.Read())
                {
                    string lockerPasswd = userCheckreader["Passwd"].ToString().Trim();

                    if (userCheckreader.NextResult()){
                        List<string> userIdList = new List<string>();
                        List<string> userNameList = new List<string>();
                        while (userCheckreader.Read())
                        {
                            userIdList.Add(userCheckreader["CustId"].ToString().Trim());
                            userNameList.Add(userCheckreader["CustName"].ToString().Trim());
                        }
                        for (int i = 0; i < userIdList.Count; i++){
                            if (textBox2.Text.Trim().Equals(lockerPasswd) && textBox1.Text.Trim().Equals(userIdList[i]))
                            {
                                MessageBox.Show(userNameList[i] + "님께서 물건을 수령하셨습니다.");
                                conn.Close();

                                if (succeedToFindUser && succeedToCheckPasswd)
                                {
                                    conn.Open();
                                    command.CommandText = "SELECT count(*) from ReceiverInfor;";
                                    receiptCount = Convert.ToInt16(command.ExecuteScalar()) + 1;
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "INSERT INTO ReceiverInfor VALUES (" + receiptCount + ", '" + userIdList[i] + "', " + lockernum + ", '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "');";
                                    command.ExecuteNonQuery();
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "UPDATE LockerInfor SET ItemName = NULL, Passwd = NULL, StoredTime = NULL WHERE LockerNum = " + lockernum + ";";
                                    command.ExecuteNonQuery();
                                }

                                

                                if (textBox2.Text.Trim().Equals(lockerPasswd))
                                {
                                    succeedToFindUser = true;
                                    succeedToCheckPasswd = false;
                                }
                                if (textBox1.Text.Trim().Equals(userIdList[i]))
                                    succeedToCheckPasswd = true;

                                
                                
                            }       
                        }
                        if (string.IsNullOrEmpty(lockerPasswd))
                            MessageBox.Show("택배함 안에 물건이 없습니다.");
                        else
                        {
                            if (!succeedToFindUser)
                                MessageBox.Show("그런 ID를 가진 유저를 찾을 수 없습니다.");
                            if (!succeedToCheckPasswd)
                                MessageBox.Show("비밀번호가 일치하지 않습니다,");
                        }
                    }
                }
                conn.Close();
            }  
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            int lockernum = 9;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                bool succeedToFindUser = false;
                bool succeedToCheckPasswd = false;

                int receiptCount = 0;

                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT * FROM LockerInfor WHERE LockerNum = " + lockernum + "; SELECT * FROM CustInfor;";

                conn.Open();

                SqlDataReader userCheckreader = command.ExecuteReader();

                if (userCheckreader.Read())
                {
                    string lockerPasswd = userCheckreader["Passwd"].ToString().Trim();

                    if (userCheckreader.NextResult()){
                        List<string> userIdList = new List<string>();
                        List<string> userNameList = new List<string>();
                        while (userCheckreader.Read())
                        {
                            userIdList.Add(userCheckreader["CustId"].ToString().Trim());
                            userNameList.Add(userCheckreader["CustName"].ToString().Trim());
                        }
                        for (int i = 0; i < userIdList.Count; i++){
                            if (textBox2.Text.Trim().Equals(lockerPasswd) && textBox1.Text.Trim().Equals(userIdList[i]))
                            {
                                MessageBox.Show(userNameList[i] + "님께서 물건을 수령하셨습니다.");
                                conn.Close();

                                if (succeedToFindUser && succeedToCheckPasswd)
                                {
                                    conn.Open();
                                    command.CommandText = "SELECT count(*) from ReceiverInfor;";
                                    receiptCount = Convert.ToInt16(command.ExecuteScalar()) + 1;
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "INSERT INTO ReceiverInfor VALUES (" + receiptCount + ", '" + userIdList[i] + "', " + lockernum + ", '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "');";
                                    command.ExecuteNonQuery();
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "UPDATE LockerInfor SET ItemName = NULL, Passwd = NULL, StoredTime = NULL WHERE LockerNum = " + lockernum + ";";
                                    command.ExecuteNonQuery();
                                }

                                

                                if (textBox2.Text.Trim().Equals(lockerPasswd))
                                {
                                    succeedToFindUser = true;
                                    succeedToCheckPasswd = false;
                                }
                                if (textBox1.Text.Trim().Equals(userIdList[i]))
                                    succeedToCheckPasswd = true;

                                
                                
                            }       
                        }
                        if (string.IsNullOrEmpty(lockerPasswd))
                            MessageBox.Show("택배함 안에 물건이 없습니다.");
                        else
                        {
                            if (!succeedToFindUser)
                                MessageBox.Show("그런 ID를 가진 유저를 찾을 수 없습니다.");
                            if (!succeedToCheckPasswd)
                                MessageBox.Show("비밀번호가 일치하지 않습니다,");
                        }
                    }
                }
                conn.Close();
            }  
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            int lockernum = 10;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                bool succeedToFindUser = false;
                bool succeedToCheckPasswd = false;

                int receiptCount = 0;

                SqlCommand command = new SqlCommand();

                command.Connection = conn;
                command.CommandText = "SELECT * FROM LockerInfor WHERE LockerNum = " + lockernum + "; SELECT * FROM CustInfor;";

                conn.Open();

                SqlDataReader userCheckreader = command.ExecuteReader();

                if (userCheckreader.Read())
                {
                    string lockerPasswd = userCheckreader["Passwd"].ToString().Trim();

                    if (userCheckreader.NextResult()){
                        List<string> userIdList = new List<string>();
                        List<string> userNameList = new List<string>();
                        while (userCheckreader.Read())
                        {
                            userIdList.Add(userCheckreader["CustId"].ToString().Trim());
                            userNameList.Add(userCheckreader["CustName"].ToString().Trim());
                        }
                        for (int i = 0; i < userIdList.Count; i++){
                            if (textBox2.Text.Trim().Equals(lockerPasswd) && textBox1.Text.Trim().Equals(userIdList[i]))
                            {
                                MessageBox.Show(userNameList[i] + "님께서 물건을 수령하셨습니다.");
                                conn.Close();

                                if (succeedToFindUser && succeedToCheckPasswd)
                                {
                                    conn.Open();
                                    command.CommandText = "SELECT count(*) from ReceiverInfor;";
                                    receiptCount = Convert.ToInt16(command.ExecuteScalar()) + 1;
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "INSERT INTO ReceiverInfor VALUES (" + receiptCount + ", '" + userIdList[i] + "', " + lockernum + ", '" + string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) + "');";
                                    command.ExecuteNonQuery();
                                    conn.Close();

                                    conn.Open();
                                    command.CommandText = "UPDATE LockerInfor SET ItemName = NULL, Passwd = NULL, StoredTime = NULL WHERE LockerNum = " + lockernum + ";";
                                    command.ExecuteNonQuery();
                                }

                                

                                if (textBox2.Text.Trim().Equals(lockerPasswd))
                                {
                                    succeedToFindUser = true;
                                    succeedToCheckPasswd = false;
                                }
                                if (textBox1.Text.Trim().Equals(userIdList[i]))
                                    succeedToCheckPasswd = true;

                                
                                
                            }       
                        }
                        if (string.IsNullOrEmpty(lockerPasswd))
                            MessageBox.Show("택배함 안에 물건이 없습니다.");
                        else
                        {
                            if (!succeedToFindUser)
                                MessageBox.Show("그런 ID를 가진 유저를 찾을 수 없습니다.");
                            if (!succeedToCheckPasswd)
                                MessageBox.Show("비밀번호가 일치하지 않습니다,");
                        }
                    }
                }
                conn.Close();
            }  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
