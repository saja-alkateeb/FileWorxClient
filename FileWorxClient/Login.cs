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
using System.Windows.Controls;
using System.CodeDom;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.NetworkInformation;

namespace FileWorxClient
{
    public partial class loginForm : Form
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string usersFolderPath;
        public loginForm()
        {
           usersFolderPath = Path.Combine(desktopPath, "Users");
           InitializeComponent();
        }
        private void LogInbutton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtUsername.Text == "root" && txtPassword.Text == "root")
            {
                this.Hide();
                var form = new ListUsers();
                form.Show();
            }
            else if (IsLoginValid(username, password))
            {
                this.Hide();
                var mainForm = new Home2();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.Please Sign Up.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsLoginValid(string Username, string Password)
        {
            string usernames = txtUsername.Text;
            string passwords = txtPassword.Text;
            if (Directory.Exists(usersFolderPath))
            {
                string[] userFiles = Directory.GetFiles(usersFolderPath, "*.txt");
                foreach (string filePath in userFiles)
                {
                    string serializedUser = File.ReadAllText(filePath);
                    string[] userAttributes = serializedUser.Split(new[] { "#%%%#" }, StringSplitOptions.None);
                    if (userAttributes[1] == usernames && userAttributes[2] == passwords)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //change the name of button to (hideButton)
            if (txtPassword.PasswordChar == '\0')
            {
                button3.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //change the name of button to (showButton)
            if (txtPassword.PasswordChar == '*')
            {
                button2.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            var user = new newUserForm();
            user.Show();
        }
    }
}
