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
    public partial class Form2 : Form
    {
        public int empid12;
        public DataSet ds = new DataSet();
        public SqlConnection con = new SqlConnection(@"Data Source=INPUN2-L4JFZLG3;Initial Catalog=CSharpExam01082022; Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                empid12 = MDIParent1.empid1;

                string s = "select name from Employee where empid=@empid12";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.Add("@empid12", SqlDbType.Int).Value = empid12;
                SqlDataReader rrr = cmd.ExecuteReader();
                rrr.Read();
                string empname1 = rrr[0].ToString();
                rrr.Close();
                textBox1.Text = empname1;
                string q = "Select id, date, intime,outtime from Attendance where empid=@empid12";
                SqlDataAdapter da = new SqlDataAdapter("Select id, date, intime,outtime from Attendance where empid=" + empid12, con);

                ds.Clear();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ee)
            {
                MessageBox.Show("Some Technical Error Occured");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
