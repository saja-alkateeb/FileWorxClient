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
using FileWorxServer;
using System.CodeDom;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace FileWorxClient
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
       
        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            clsUser clsUser = new clsUser();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (clsUser.IsLoginValid(username, password))
            {
                clsUser = new clsUser
                {
                    ID = clsUser.GetUser(password),
                    //Name = clsUser.GetFullName(password),
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text,
                    LastModifier = txtUsername.Text,
                    IsAdmin = CheckUserAdminStatus(username,password)
                };
                this.Hide();
                frmFILEWORX homeForm = new frmFILEWORX(clsUser);
                homeForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        private bool CheckUserAdminStatus(string username,string password)
        {
            return (username == "root"&&password=="root");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter))
            {
                return;
            }
            e.SuppressKeyPress = true;
            btnLogin_Click(sender, e);
        }
    }

}