using DBConnNET4;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace FileWorxClient
{
    public partial class frmPhoto : Form
    {
        string LastModeiifier;
        private string photoPathCopy;
        private clsPhoto clsPhoto;
        DBConnNET4.clsDBConnection dBConn = new clsDBConnection();

        public frmPhoto()
        {

            InitializeComponent();
        }
        public frmPhoto(clsPhoto photo)
        {
            InitializeComponent();
            clsPhoto = photo;
            txtTitle.Text = clsPhoto.Name;
            txtDescription.Text = clsPhoto.Description;
            txtLocation.Text = clsPhoto.PhotoPath;
            picPhotos.Image = new System.Drawing.Bitmap(txtLocation.Text);
            rtbBody.Text = clsPhoto.Body;
        }
        public frmPhoto(string lastModifier)
        {
            InitializeComponent();
            this.LastModeiifier = lastModifier;
            //dBConn.ErrLogFile = "DBOCONN_LOG_FILE_NAME.log";//
            //dBConn.FetchSize = 10000;
            SqlConnection connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();


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
            if (title.Length > 255 || description.Length > 255 || body.Length > 10000)
            {
                MessageBox.Show("Please enter valid length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                clsPhoto photoDB = new clsPhoto();
                photoDB.ID = Guid.NewGuid().ToString();
                photoDB.Name = title;
                photoDB.Description = description;
                photoDB.Creator = LastModeiifier;
                photoDB.Body = body;
                photoDB.CreationDate = creationDate;
                photoDB.PhotoPath = pictureLocation;
                photoDB.PhotoPathCopy = photoPathCopy;
                clsClass classDB = new clsClass();
                classDB.ID = 2;
                photoDB.ClassID = classDB.ID;
                photoDB.Insert();
                EmptyFields();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the photo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void frmPhoto_Load(object sender, EventArgs e)
        {
            btnSave.BringToFront();
            this.MinimumSize = new System.Drawing.Size(450, 450);
        }
        public void EmptyFields()
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtLocation.Text = string.Empty;
            rtbBody.Clear();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            clsPhoto.Name = txtTitle.Text;
            clsPhoto.Description = txtDescription.Text;
            clsPhoto.PhotoPath = txtLocation.Text;
            clsPhoto.Body = rtbBody.Text;
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit this object?", "Edit Object", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                DialogResult = DialogResult.OK;
            Close();
        }

        private void frmPhoto_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner is frmFILEWORX fileworxForm)
            {
                fileworxForm.OnNewObjectAdded(EventArgs.Empty);
            }
        }

        private void rtbBody_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
