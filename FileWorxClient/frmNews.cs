using DBConnNET4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using DBConnNET4;
using FileWorxServer;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DBConnNET4.clsDBConnection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FileWorxClient
{
    public partial class frmNews :Form
    {
        private clsNews clsNews;
        public string NewsId { get; set; }
        public frmNews()
        {
            InitializeComponent();
        }
        public frmNews(clsNews news)
        {
            InitializeComponent();
            clsNews = news;
            NewsId = news.ID;
            FillFields();
        }
        public frmNews(string lastModifier)
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            string category = cmboCategory.SelectedItem.ToString();
            string body = rtbBody.Text;
            DateTime creationDate = DateTime.Now;
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(body))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                clsNews newsDB = new clsNews();
                if (!string.IsNullOrEmpty(NewsId))
                {
                    newsDB.ID = NewsId;
                    short readStatus = newsDB.Read();
                    if (readStatus != 0)
                    {
                        MessageBox.Show("Read operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    newsDB.ID = Guid.NewGuid().ToString();
                }
                newsDB.Name = title;
                newsDB.Description = description;
                newsDB.Body = body;
                newsDB.CreationDate = creationDate;
                newsDB.Category = category;
                clsClass classDB = new clsClass();
                newsDB.ClassID = (int)ClassIds.News;
                if (!string.IsNullOrEmpty(NewsId))
                {
                    short updateStatus = newsDB.Update();
                    if (updateStatus != 0)
                    {
                        MessageBox.Show("Update operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    short insertStatus = newsDB.Insert();
                    if (insertStatus != 0)
                    {
                        MessageBox.Show("Insert operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating/editing the news: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EmptyFields()
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cmboCategory.Text = string.Empty;
            rtbBody.Clear();
        }
        private void FillFields()
        {
            txtTitle.Text = clsNews.Name;
            txtDescription.Text = clsNews.Description;
            cmboCategory.Text = clsNews.Category;
            rtbBody.Text = clsNews.Body;
        }
    }
}
    

