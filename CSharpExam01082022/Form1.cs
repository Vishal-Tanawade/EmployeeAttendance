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
    public partial class Form1 : Form
    {
        public string username, pwd;
        public int empid = -1;

        public SqlConnection con = new SqlConnection(@"Data Source=INPUN2-L4JFZLG3;Initial Catalog=CSharpExam01082022; Integrated Security=True");
       public MDIParent1 mdi1;
        public Form1(MDIParent1 m)
        {   
            InitializeComponent();
            mdi1=m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                username = textBox1.Text;
                pwd = textBox2.Text;
                string query = "Select empid from Employee where uname=@username and password=@pwd";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@pwd", SqlDbType.VarChar).Value = pwd;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.Read())
                {

                    MessageBox.Show("Login Successful");
                    empid = (int)sqlDataReader[0];
                    MDIParent1.empid1 = empid;

                   
                mdi1.enableButtons();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }

            }
            catch(Exception e1)
            {
                MessageBox.Show("Some Technical Error Occured..!");

            }
            finally { con.Close(); }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
