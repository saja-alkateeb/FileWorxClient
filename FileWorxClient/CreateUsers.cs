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
            string confirmPassword = txtConfirmPass.Text;
            string lastModifier = fullName;
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)|| string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (fullName.Length > 255 || username.Length > 255 || password.Length > 255||confirmPassword.Length > 255)
            {
                MessageBox.Show("Please enter valid length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //confirm password
                try
                {
                    string fileName = Guid.NewGuid().ToString();
                    string filePath = Path.Combine(usersFolderPath, $"{fileName}.txt");
                    string separator = "#%%%#";
                    string data = $"{fullName}{separator}{username}{separator}{password}{separator}{lastModifier}{separator}{fileName}";
                    File.WriteAllText(filePath, data);
                    MessageBox.Show("User created and saved successfully!");
                    txtFullName.Text = string.Empty;
                    txtUsername.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtConfirmPass.Text = string.Empty;
                    this.Close();
                    Home2 mainForm = new Home2();
                    mainForm.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while creating the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }

        private void newUserForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            //Show button
            if (txtPassword.PasswordChar == '*')
            {
                showButton.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            //Hide Button
            if (txtPassword.PasswordChar == '\0')
            {
                hideButton.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
