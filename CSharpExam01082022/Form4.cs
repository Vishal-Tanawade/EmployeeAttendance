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
    public partial class Form4 : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=INPUN2-L4JFZLG3;Initial Catalog=CSharpExam01082022; Integrated Security=True");
        public MDIParent1 pp;
        public Form4(MDIParent1 p)
        {
            InitializeComponent();
            pp = p;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int eid = MDIParent1.empid1;
            string newpwd = textBox1.Text;
            string newpwd2 = textBox2.Text;
            if (newpwd == newpwd2)
            {
                try
                {
                    string qq = "update Employee set password=@newpwd where empid= @eid ";
                    SqlCommand cmd = new SqlCommand(qq, con);
                    con.Open();
                    cmd.Parameters.Add("@eid", SqlDbType.Int).Value = eid;
                    cmd.Parameters.Add("@newpwd", SqlDbType.VarChar).Value = newpwd;
                    int ii = cmd.ExecuteNonQuery();
                    con.Close();
                    if (ii > 0)
                    {
                        MessageBox.Show("Password Changed");
                        //pp.disableButton();
                        
                        MDIParent1 m = new MDIParent1();
                        m.Show();
                    }
                    else
                    {
                        MessageBox.Show("Some Error");
                    }
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
              
            }
            else
            {
                MessageBox.Show("please enter Correct password");
                textBox2.Clear();
                textBox2.Focus();
            }
        }
    }
}
