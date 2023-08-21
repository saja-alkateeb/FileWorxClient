using DBConnNET4;
using System;
using System.Windows.Controls;
using System.Windows.Forms;
using FileWorxServer;
namespace FileWorxClient
{
    public partial class frmUser : Form
    {
        private clsUser clsUser;
        DBConnNET4.clsDBConnection dBConn = new clsDBConnection();
        private string passwordBox;
        public frmUser()
        {
            InitializeComponent();
        }
        public frmUser(clsUser user)
        {
            InitializeComponent();
            clsUser = user;
            txtUsername.Text = user.UserName;
            txtFullName.Text = user.Name;
            passwordBox = user.Password;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            EmptyFields();
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPass.Text;
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password == confirmPassword)
            {
                try
                {
                    clsUser userDB = new clsUser();
                    userDB.ID = Guid.NewGuid().ToString();
                    userDB.Password = password;
                    userDB.UserName = username;
                    userDB.Name = fullName;
                    userDB.CreationDate = DateTime.Now;
                    userDB.Creator = "root";
                    clsClass classDB = new clsClass();
                    userDB.ClassID = (int)ClassIds.User;
                    short insertStatus = userDB.Insert();
                    if (insertStatus != 0)
                    {
                        MessageBox.Show("Insert operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    EmptyFields();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while creating the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The Password confirmation does not match ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }
        private void frmUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner is frmUsersInfo userForm)
            {
                userForm.OnNewObjectAdded(EventArgs.Empty);
            }
        }
        public void EmptyFields()
        {
            txtFullName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text =string.Empty;
            txtConfirmPass.Text = string.Empty;
        }

        private void btnShow2_Click(object sender, EventArgs e)
        {
            if (txtConfirmPass.PasswordChar == '*')
            {
                btnHide2.BringToFront();
                txtConfirmPass.PasswordChar = '\0';
            }
        }
        private void btnHide2_Click(object sender, EventArgs e)
        {
            if (txtConfirmPass.PasswordChar == '\0')
            {
                btnShow2.BringToFront();
                txtConfirmPass.PasswordChar = '*';
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            clsUser.Name = txtFullName.Text;
            clsUser.UserName = txtUsername.Text;
            if (chBxChangePassword.CheckState== CheckState.Checked)
            {
                txtPassword.Text = passwordBox;
                txtPassword.ReadOnly = false;
                txtConfirmPass.ReadOnly = false;
                clsUser.Password = txtPassword.Text;
                
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit this object?", "Edit Object", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                DialogResult = DialogResult.OK;
            Close();
        }
    }
}
