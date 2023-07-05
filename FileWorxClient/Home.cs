﻿using System;
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
using static FileWorxClient.CreatePhotos;

namespace FileWorxClient
{
    public partial class mainForm : Form
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
            var form6 = new CreatePhotos();
            form6.Show();
        }

        //private void mainForm_Load(object sender, EventArgs e)
        //{
        //    WindowState = FormWindowState.Maximized;
        //    dataGridView1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
        //}

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
           string newsFolderPath = Path.Combine(desktopPath, "News");
            Directory.CreateDirectory(newsFolderPath);
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
                    string[] newsAttributes = serializedNews.Split(new[] { "#%%%#" }, StringSplitOptions.None);
                    string title = newsAttributes[0];
                    DateTime creationDate = DateTime.Parse(newsAttributes[1]);
                    string description = newsAttributes[2];
                    dt.Rows.Add(new object[] { title, creationDate, description });
                    dataGridView1.DataSource = dt;
                   
                }
                
                    
                


                }
            


        }

        private void photosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string photosFolderPath = Path.Combine(desktopPath, "Photos");
            Directory.CreateDirectory(photosFolderPath);
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Creation Date");
            dt.Columns.Add("Description");
            if (Directory.Exists(photosFolderPath))
            {
                string[] photosFiles = Directory.GetFiles(photosFolderPath, "*.txt");
                foreach (string filePath in photosFiles)
                {
                    string serializedPhotos = File.ReadAllText(filePath);
                    string[] photosAttributes = serializedPhotos.Split(new[] { "#%%%#" }, StringSplitOptions.None);
                    string title = photosAttributes[0];
                    DateTime creationDate = DateTime.Parse(photosAttributes[1]);
                    string description = photosAttributes[2];
                    dt.Rows.Add(new object[] {title,creationDate,description});
                    dataGridView1.DataSource = dt;
                }
            }
            comboBox1.Enabled = false;
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var user = new ListUsers();
            user.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //delete to remove the object from the system.
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(selectedRowIndex);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewElementStates select = DataGridViewElementStates.Selected;
            if(select == DataGridViewElementStates.Selected)
            {
                
            }*/
            /* if (dataGridView1.SelectedRows.Count > 0)
             {
                 DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                 string title = selectedRow.Cells["Title"].Value.ToString();
                 string description = selectedRow.Cells["Description"].Value.ToString();


             }*/
            string newsFolderPath = Path.Combine(desktopPath, "News");
            Directory.CreateDirectory(newsFolderPath);
            DataGridViewElementStates select = DataGridViewElementStates.Selected;
            bool Isselect = Convert.ToBoolean(DataGridViewElementStates.Selected);
            string[] newsFiles = Directory.GetFiles(newsFolderPath, "*.txt");
                foreach (string filePath in newsFiles)
                {
                    foreach (DataGridViewRow rows in dataGridView1.Rows)
                    {
                        string serializedNews = File.ReadAllText(filePath);
                    string[] newsAttributes = serializedNews.Split('#');
                    if (Isselect)
                    {
                        richTextBox1.Text = newsAttributes[4];
                    }
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
        }
    