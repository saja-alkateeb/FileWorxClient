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
using System.Security.Cryptography.X509Certificates;

namespace FileWorxClient
{
   
    public partial class newUserForm:Form
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public newUserForm()
        {
            InitializeComponent();
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            txtFullName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string usersFolderPath = Path.Combine(desktopPath, "Users");
            Directory.CreateDirectory(usersFolderPath);
            string fullName = txtFullName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string lastModifier = Environment.UserName;
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (fullName.Length > 255 || username.Length > 255 || password.Length > 255)
            {
                //Haytham note:Detail the error(specify the valid length for each field)
                MessageBox.Show("Please enter valid length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string fileName = Guid.NewGuid().ToString();

                string filePath = Path.Combine(usersFolderPath, $"{fileName}.txt");
                char separator = '#';
                string data = $"{fullName}{separator}{username}{separator}{password}{separator}{lastModifier}";
               // Directory.CreateDirectory(usersFolderPath);
                File.WriteAllText(filePath, data);
                MessageBox.Show("User created and saved successfully!");
                txtFullName.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void newUserForm_Load(object sender, EventArgs e)
        {

        }
      
    }
}
