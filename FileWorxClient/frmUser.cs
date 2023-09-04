using DBConnNET4;
using System;
using Nest;
using System.Windows.Controls;
using System.Windows.Forms;
using FileWorxServer;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using System.Threading.Tasks;

namespace FileWorxClient
{
    public partial class frmUser : Form
    {
        private clsUser clsUser;
        public string UserID { get; set; }
        private string passwordBox;
        public frmUser()
        {
            InitializeComponent();
        }
        public frmUser(clsUser user)
        {
            InitializeComponent();
            clsUser = user;
            UserID = user.ID;
            txtUsername.Text = user.UserName;
            txtFullName.Text = user.Name;
            passwordBox = user.Password;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            EmptyFields();
            this.Close();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPass.Text;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("The Password confirmation does not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                clsUser userDB = new clsUser();
                if (!string.IsNullOrEmpty(UserID))
                {
                    userDB.Password = null;
                    if (!chkEnableEditPassword.Checked)
                    {
                        userDB.Password = passwordBox;
                    }
                    userDB.ID = UserID;
                    short readStatus = userDB.Read();
                    if (readStatus != 0)
                    {
                        MessageBox.Show("Read operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else

                {
                    userDB.ID = Guid.NewGuid().ToString();
                }

                userDB.UserName = username;
                userDB.Name = fullName;
                userDB.CreationDate = DateTime.Now;
                userDB.Creator = "root";
                clsClass classDB = new clsClass();
                userDB.ClassID = (int)ClassIds.User;

                if (!string.IsNullOrEmpty(UserID))
                {
                    userDB.Password = null;
                    short updateStatus = userDB.Update();
                    await userDB.UpdateUserInElasticsearchAsync(userDB);
                    if (updateStatus != 0)
                    {
                        MessageBox.Show("Update operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    txtPassword.ReadOnly = !chkEnableEditPassword.Checked;
                    txtConfirmPass.ReadOnly = !chkEnableEditPassword.Checked;
                    userDB.Password = password;
                    short insertStatus = userDB.Insert();
                    if (insertStatus != 0)
                    {
                        MessageBox.Show("Insert operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var userES = new clsUser
                    {
                        ID = userDB.ID,
                        Name = fullName,
                        UserName = username,
                        CreationDate = DateTime.Now,
                        ClassID = (int)ClassIds.User,
                        Creator = "root"
                    };
                    clsUser clsUser = new clsUser();
                   await clsUser.InsertUserInElasticsearchAsync(userES);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating/editing the user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DialogResult = DialogResult.OK;
            this.Close();
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
        private void EmptyFields()
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

        private void frmUser_Load(object sender, EventArgs e)
        {

        }

        private void chkEnableEditPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool enableEdit = chkEnableEditPassword.Checked;
            txtPassword.ReadOnly = !enableEdit;
            txtConfirmPass.ReadOnly = !enableEdit;
        }
    }
}
