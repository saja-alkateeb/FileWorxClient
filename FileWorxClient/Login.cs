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
using System.Windows.Controls;
using System.CodeDom;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.NetworkInformation;
using static FileWorxClient.newNewsForm;


namespace FileWorxClient
{
    /* Before submission ,make sure that you did this :
      1-Handle Exception
      2-Comments
      3-Naming(Pascal case,Camel case)
      4-Consistancy,easy to use
      5-Complexity
      6 -Access modifier(public,private,protected,internal)
      7-Clean Code
      8-Good Design 
      9-Correct Functionality
      10-Error message
     */

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
            if (IsLoginValid(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                mainForm mainForm = new mainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void button1_Click(object sender, EventArgs e)
        {
            //change the name of button to (showButton)
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //change the name of button to (hideButton)
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*';
            }

        }

        private void loginForm_Load(object sender, EventArgs e)
        {
        }
    
    }
}
