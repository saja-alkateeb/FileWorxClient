using DBConnNET4;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using FileWorxServer;
namespace FileWorxClient
{
    public partial class frmPhoto : Form
    {
        private string photoPathCopy;
        public string PhotoID { get; set; }
        private clsPhoto clsPhoto;
        public frmPhoto()
        {
            InitializeComponent();
        }
        public frmPhoto(clsPhoto photo)
        {
            InitializeComponent();
            clsPhoto = photo;
            PhotoID = photo.ID;
            FillFields();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            string pictureLocation = txtLocation.Text;
            string body = rtbBody.Text;
            DateTime creationDate = DateTime.Now;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(pictureLocation) || string.IsNullOrEmpty(body))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                clsPhoto photoDB = new clsPhoto();
                if (!string.IsNullOrEmpty(PhotoID))
                {

                    photoDB.ID = PhotoID;
                    short ReadStatus = photoDB.Read();
                    if (ReadStatus != 0)
                    {
                        MessageBox.Show("Read operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    photoDB.ID = Guid.NewGuid().ToString();
                }
                photoDB.Name = title;
                photoDB.Description = description;
                photoDB.Body = body;
                photoDB.CreationDate = creationDate;
                photoDB.PhotoPath = pictureLocation;
                photoDB.PhotoPathCopy = photoPathCopy;
                clsClass classDB = new clsClass();
                photoDB.ClassID = (int)ClassIds.Photo;

                if (!string.IsNullOrEmpty(PhotoID))
                {
                    short updateStatus = photoDB.Update();
                    if (updateStatus != 0)
                    {
                        MessageBox.Show("Update operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    short InsertStatus = photoDB.Insert();
                    if (InsertStatus != 0)
                    {
                        MessageBox.Show("Insert operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                EmptyFields();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating/editing the photo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EmptyFields();
            this.Close();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
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
                        string copiedFileName = Path.Combine("ImageCopies", Guid.NewGuid().ToString() + Path.GetExtension(selectedFilePath));
                        string destinationPath = Path.Combine(Application.StartupPath, copiedFileName);
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                        File.Copy(selectedFilePath, destinationPath);
                        txtLocation.Text = selectedFilePath;
                        picPhotos.Image = new System.Drawing.Bitmap(selectedFilePath);
                        photoPathCopy = destinationPath;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while uploading the photo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void EmptyFields()
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtLocation.Text = string.Empty;
            rtbBody.Clear();
        }
        public void FillFields()
        {
            txtTitle.Text = clsPhoto.Name;
            txtDescription.Text = clsPhoto.Description;
            txtLocation.Text = clsPhoto.PhotoPath;
            rtbBody.Text = clsPhoto.Body;
            picPhotos.Image = new System.Drawing.Bitmap(txtLocation.Text);
        }
    }
}
