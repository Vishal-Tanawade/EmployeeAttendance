using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpExam01082022
{
    public partial class Form3 : Form
    {

        public int empid12;
        public SqlConnection con = new SqlConnection(@"Data Source=INPUN2-L4JFZLG3;Initial Catalog=CSharpExam01082022; Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            empid12 = MDIParent1.empid1;
            string s = "Select * from Attendance where outtime is NULL and empid=@empid12";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(s, con);
            sqlCommand.Parameters.Add("@empid12", SqlDbType.Int).Value = empid12;
            SqlDataReader r = sqlCommand.ExecuteReader();
            if (r.Read())
            {
                button1.Enabled = false;
            }
            else
            {
                button2.Enabled=false;
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int jj = 0;
            try
            {
                empid12 = MDIParent1.empid1;
                string s = "Select * from Attendance where outtime is NULL and empid=@empid12";
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(s, con);
                sqlCommand.Parameters.Add("@empid12", SqlDbType.Int).Value = empid12;
                SqlDataReader r = sqlCommand.ExecuteReader();
                if (r.Read())
                {
                    MessageBox.Show("Please Punch Out first");
                }
                else
                {
                    r.Close();

                    DateTime todaysdate = DateTime.Today;
                    string t = DateTime.Now.ToString("h:mm:ss tt");
                    string q = "insert into Attendance(intime,date,empid) values(@t,@todaysdate,@empid12)";

                    sqlCommand = new SqlCommand(q, con);
                    sqlCommand.Parameters.Add("@empid12", SqlDbType.Int).Value = empid12;
                    sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = t;
                    sqlCommand.Parameters.Add("@todaysdate", SqlDbType.Date).Value = todaysdate;
                    jj = sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                con.Close();
            }
            if (jj > 0)
            {
                MessageBox.Show("Punched In");
                this.Close();

            }
            else
            {
                MessageBox.Show("Error");
            }
        }


    

        private void button2_Click(object sender, EventArgs e)
        {   
            
            empid12 = MDIParent1.empid1;
            string s = "Select * from Attendance where outtime is NULL and empid=@empid12";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(s, con);
            sqlCommand.Parameters.Add("@empid12", SqlDbType.Int).Value = empid12;
            SqlDataReader r = sqlCommand.ExecuteReader();
            if (r.Read())
            {
                int id1 = (int)r[0];
                string tt = DateTime.Now.ToString("h:mm:ss tt");
                string sss = "Update Attendance set outtime=@tt where id=@id ";
                r.Close();
                sqlCommand = new SqlCommand(sss, con);
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id1;
                sqlCommand.Parameters.Add("@tt", SqlDbType.VarChar).Value = tt;
                int jjjj = sqlCommand.ExecuteNonQuery();
                if (jjjj > 0)
                {
                    MessageBox.Show("Punched out");
                    button1.Enabled = true;
                    button2.Enabled = false;
                    this.Close();
                } else
                    MessageBox.Show("Errror");


            }
            else
            {
                MessageBox.Show("Please Punch in first");
            }
            con.Close();
        }
    }
}
