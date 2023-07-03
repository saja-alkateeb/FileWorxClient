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
          //Handle Exception
            var form3 = new newUserForm();
            form3.Show();



        }

        private void newsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Handle Exception
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
            //Handle Exception
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
                    richTextBox1.AppendText($"Title: {title}{Environment.NewLine}Creation Date: {creationDate}{Environment.NewLine}Description: {description}{Environment.NewLine}---------------------------------{Environment.NewLine}");

                }
            }
        }

        private void photosToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                    richTextBox1.AppendText($"Title: {title}{Environment.NewLine}Creation Date: {creationDate}{Environment.NewLine}Description: {description}{Environment.NewLine}---------------------------------{Environment.NewLine}");

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
                        richTextBox1.AppendText($"Full Name: {fullName}{Environment.NewLine}Username: {username}{Environment.NewLine}Password: {password}{Environment.NewLine}Last Modifier: {lastModifier}{Environment.NewLine}---------------------------------{Environment.NewLine}");
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