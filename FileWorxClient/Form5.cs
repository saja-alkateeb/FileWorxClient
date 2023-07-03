using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorxClient
{
    public partial class newPhotosForm :Form
    {
        private string photoFolderPath;
        public newPhotosForm()
        {
            InitializeComponent();
            Path.Combine("@\"c:\\saja\\Photos");
        }

        private void newPhotosForm_Load(object sender, EventArgs e)
        {

        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            richTextBox1.Clear();
            this.Hide();
            mainForm mainform = new mainForm();
            mainform.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            string pictureLocation = txtLocation.Text;
            string body = richTextBox1.Text;
            DateTime creationDate=DateTime.Now;
            Photos photo=new Photos (title, description, body, pictureLocation, creationDate);
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(pictureLocation) || string.IsNullOrEmpty(body))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (title.Length > 255 || description.Length > 255 || body.Length > 10000)
            {
                //Haytham note:Detail the error(specify the valid length for each field)
                MessageBox.Show("Please enter valid length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string fileName = Guid.NewGuid().ToString();

                string filePath = Path.Combine(photoFolderPath, $"{fileName}.txt");

                char separator = '#';

                string data = $"{title}{separator}{creationDate}{separator}{description}{separator}{pictureLocation}{separator}{body}";

                Directory.CreateDirectory(photoFolderPath);

                File.WriteAllText(filePath, data);

                MessageBox.Show("Photos created and saved successfully!");
                txtTitle.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtLocation.Text = string.Empty;
                richTextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the photo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                try
                {
                    openFileDialog.Filter = "Image Files (.png;.jpg;*.jpeg;*.gif|*.png;*.jpg;*.jpeg;*.gif|All Files (.)|*.*";
                    openFileDialog.FilterIndex = 1;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFilePath = openFileDialog.FileName;

                        txtLocation.Text = selectedFilePath;

                        pictureBox1.Image = new System.Drawing.Bitmap(selectedFilePath);
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while uploading the photo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public class Photos
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Body { get; set; }
            public string PictureLocation { get; set; }
            public DateTime CreationDate { get; set; }
            public Photos(string title, string description, string body, string pictureLocation, DateTime creationDate)
            {
                this.Title = title;
                this.Description = description;
                this.Body = body;
                this.PictureLocation = pictureLocation;
                this.CreationDate = creationDate;

            }

        }

        private void Controltab1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
