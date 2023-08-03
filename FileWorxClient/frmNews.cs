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
        string LastModifier;
        private clsNews clsNews;
        DBConnNET4.clsDBConnection dBConn = new clsDBConnection();
        public frmNews()
        {
            InitializeComponent();
        }
        public frmNews(clsNews news)
        {
            InitializeComponent();
            clsNews = news;
            txtTitle.Text = clsNews.Name;
            txtDescription.Text = clsNews.Description;
            cmboCategory.Text= clsNews.Category;
            rtbBody.Text = clsNews.Body;
        }
        public frmNews(string lastModifier)
        {
            InitializeComponent();
            this.LastModifier = lastModifier;
            SqlConnection connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EmptyFields();
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            //************Bug**************
            //Click on Save btn in News frm while the Category field is empty->return NULL
            //if (cmboCategory.SelectedItem.ToString() == null)
            //{
            //    MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            string category = cmboCategory.SelectedItem.ToString();
            string body = rtbBody.Text;
            DateTime creationDate = DateTime.Now;
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) ||string.IsNullOrEmpty(category) || string.IsNullOrEmpty(body))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (title.Length > 255 || description.Length > 255 || body.Length > 10000)
            {
                MessageBox.Show("Please enter valid length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                clsNews db = new clsNews();
                db.ID = Guid.NewGuid().ToString();
                db.Name = title;
                db.Description = description;
                db.Body = body;
                db.CreationDate = creationDate;
                db.Creator = LastModifier;
                db.Category = category;
                clsClass classDB = new clsClass();
                classDB.ID = 1;
                db.ClassID = classDB.ID;
                db.Insert();
                EmptyFields();
                this.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the news: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmNews_Load(object sender, EventArgs e)
        {
            btnSave.BringToFront();
            this.MinimumSize = new System.Drawing.Size(450, 450);
        }
        public void EmptyFields()
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            cmboCategory.Text = string.Empty;
            rtbBody.Clear();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            clsNews.Name = txtTitle.Text;
            clsNews.Description = txtDescription.Text;
            clsNews.Category = cmboCategory.Text;
            clsNews.Body = rtbBody.Text;
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit this object?", "Edit Object", MessageBoxButtons.YesNo);
            if(dialogResult==DialogResult.Yes)
            DialogResult = DialogResult.OK;
            Close();
        }

        private void frmNews_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner is frmFILEWORX fileworxForm)
            {
                fileworxForm.OnNewObjectAdded(EventArgs.Empty);
            }
        }
    }
}
    

