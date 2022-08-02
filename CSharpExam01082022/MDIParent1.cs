using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpExam01082022
{
    public partial class MDIParent1 : Form
    {
        public static int empid1 = -1;
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }





        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void viewAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (empid1 == -1)
            {
                MessageBox.Show("Plesae Login first");
            }
            else
            {
                Form2 form2 = new Form2();
                form2.Show();

            }


        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            viewAttendanceToolStripMenuItem.Enabled = false;
            punchToolStripMenuItem.Enabled = false;
            logoutToolStripMenuItem.Enabled = false;
            changePasswordToolStripMenuItem.Enabled = false;


        }

        private void fileMenu_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this);
            form1.Show();

        }

        private void punchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (empid1 == -1)
            {
                MessageBox.Show("Plesae Login first");
            }
            else
            {
                Form3 f = new Form3();
                f.Show();

            }


        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empid1 = -1;
            viewAttendanceToolStripMenuItem.Enabled = false;
            punchToolStripMenuItem.Enabled = false;
            logoutToolStripMenuItem.Enabled = false;
            changePasswordToolStripMenuItem.Enabled = false;
            fileMenu.Enabled = true;
            MessageBox.Show("logged out");

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (empid1 == -1)
            {
                MessageBox.Show("Plesae Login first");
            }
            else
            {
                Form4 form4 = new Form4(this);
                form4.Show();
            }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
       
        public void enableButtons()
        {
            viewAttendanceToolStripMenuItem.Enabled = true;
            punchToolStripMenuItem.Enabled = true;
            logoutToolStripMenuItem.Enabled = true;
            changePasswordToolStripMenuItem.Enabled = true;
            fileMenu.Enabled = false;
        }
        public void disableButton()
        {
            empid1 = -1;
            viewAttendanceToolStripMenuItem.Enabled = false;
            punchToolStripMenuItem.Enabled = false;
            logoutToolStripMenuItem.Enabled = false;
            changePasswordToolStripMenuItem.Enabled = false;
            fileMenu.Enabled = true;
        }
    }
}
