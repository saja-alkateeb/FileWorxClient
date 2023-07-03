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
        string dataPath = @"c:\saja\AdminInfo.txt";
        string usersFolderPath = @"c:\saja\Admin.txt";
        public loginForm()
        {
            InitializeComponent();
        }

        private void LogInbutton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            Admin admin = new Admin(username, password);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) )
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
            if (!File.Exists(dataPath))
                return false;

            string[] lines = File.ReadAllLines(dataPath);
            string[] user = File.ReadAllLines(usersFolderPath);
         //Admin
                foreach (string line in lines)
                {
                    string[] parts = line.Split('#');
                    string storedUsername = parts[0].Trim();
                    string storedPassword = parts[1].Trim();
                    if (storedUsername == "Saja" && storedPassword == "2000")
                        return true;
                }
         //Normal Users
         
            if (Directory.Exists(usersFolderPath))
            {
                string[] userFiles = Directory.GetFiles(usersFolderPath, "*.txt");
                foreach (string filePath in userFiles)
                {
                    string serializedUser = File.ReadAllText(filePath);
                    string[] userAttributes = serializedUser.Split('#');
                    string username = userAttributes[1];
                    string password = userAttributes[2];
                    if(Username== username&& Password == password)
                        return true;


                }
            }
         
         
                return false;
            
            
        }
        public class Admin
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public Admin()
            {
                    
            }
            public Admin(string userName,string password)
            {
                this.UserName = userName;
                this.Password = password;
                    
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           //change the name of button to (showButton)
            if(txtPassword.PasswordChar == '*')
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
    }
}
