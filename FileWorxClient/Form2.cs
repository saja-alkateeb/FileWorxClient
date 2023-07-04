using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static FileWorxClient.loginForm;
using static FileWorxClient.newUserForm;
using static FileWorxClient.newNewsForm;
using static FileWorxClient.Form6;

namespace FileWorxClient
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            var form3 = new newUserForm();
            form3.Show();



        }

        private void newsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            var form4 = new newNewsForm();
            form4.Show();
        }

        private void loginAsNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var form1 = new loginForm();
            form1.Show();
        }

        private void photoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var form6 = new Form6();
            form6.Show();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void newsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string newsFolderPath = "C:\\saja\\News";
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Creation Date");
            dt.Columns.Add("Description");
            if (Directory.Exists(newsFolderPath))
                {
                    string[] newsFiles = Directory.GetFiles(newsFolderPath, "*.txt");

                    foreach (string filePath in newsFiles)
                    {
                        string serializedNews = File.ReadAllText(filePath);
                        string[] newsAttributes = serializedNews.Split('#');
                        string title = newsAttributes[0];
                        DateTime creationDate = DateTime.Parse(newsAttributes[1]);
                        string description = newsAttributes[2];
                     
                        dt.Rows.Add(new object[] { newsAttributes[0], newsAttributes[1], newsAttributes[2] });
                        dataGridView1.DataSource = dt;
                    }

                }
            
        }

        private void photosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Creation Date");
            dt.Columns.Add("Description");
            string photosFolderPath = "C:\\saja\\Photos";
            if (Directory.Exists(photosFolderPath))
            {
                string[] photosFiles = Directory.GetFiles(photosFolderPath, "*.txt");
                foreach (string filePath in photosFiles)
                {
                    string serializedPhotos = File.ReadAllText(filePath);
                    string[] photosAttributes = serializedPhotos.Split('#');
                    string title = photosAttributes[0];
                    DateTime creationDate = DateTime.Parse(photosAttributes[1]);
                    string description = photosAttributes[2];
                    dt.Rows.Add(new object[] { photosAttributes[0], photosAttributes[1], photosAttributes[2] });
                    dataGridView1.DataSource = dt;

                }
            }
            comboBox1.Enabled = false;
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Admin's permission
            Admin admin2 = new Admin();
            if (admin2.UserName == "Saja" && admin2.Password == "2000")
            {
                string usersFolderPath = "C:\\saja\\Users";
                if (Directory.Exists(usersFolderPath))
                {
                    string[] userFiles = Directory.GetFiles(usersFolderPath, "*.txt");
                    foreach (string filePath in userFiles)
                    {
                        string serializedUser = File.ReadAllText(filePath);
                        string[] userAttributes = serializedUser.Split('#');
                        string fullName = userAttributes[0];
                        string username = userAttributes[1];
                        string password = userAttributes[2];
                        string lastModifier = userAttributes[3];
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Full Name");
                        dt.Columns.Add("Username");
                        dt.Columns.Add("Password");
                        dt.Columns.Add("last Modifier");
                        dt.Rows.Add(new object[] { userAttributes[0], userAttributes[1], userAttributes[2], userAttributes[3] });
                        dataGridView1.DataSource = dt;
                    }
                }
                txtTitle.Enabled = false;
                txtDate.Enabled = false;
                comboBox1.Enabled = false;
            }
            //normal user
            else
            {
                usersToolStripMenuItem.Enabled = false;
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    }