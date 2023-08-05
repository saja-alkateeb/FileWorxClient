using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace FileWorxClient
{
    public partial class frmUsersInfo : Form
    {
        public string ID { get; set; }
        string separator = Constants.Separator;

        public frmUsersInfo()
        {
            InitializeComponent();
        }
        private void frmUsersInfo_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(450, 450);
            PopulateListView();
        }
        private void lstViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstViewUsers.FullRowSelect = true;
        }
        public void PopulateListView()
        {
            try
            {
                clsUser User = new clsUser();
                clsUserQuery UserQuery = new clsUserQuery();
                UserQuery.QClasses = ClassIds.User;
                UserQuery.Run();
                List<clsUser> userList = UserQuery.UserList;
                foreach (clsUser user in userList)
                {
                    ListViewItem item = new ListViewItem(user.Name);
                    item.SubItems.Add(user.UserName);
                    item.Tag = user.ID;
                    lstViewUsers.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while populating the users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                lstViewUsers.FullRowSelect = true;
                clsBusinessObject clsBusinessObject = new clsBusinessObject();
                string tag = lstViewUsers.SelectedItems[0].Tag.ToString();
                string Id = tag;
                if (lstViewUsers.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete this object?", "Delete Object", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsBusinessObject.ID = Id;
                        clsBusinessObject.Delete();
                        ListViewItem selectedItem = lstViewUsers.SelectedItems[0];
                        selectedItem.Remove();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUsersInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreare_Click(object sender, EventArgs e)
        {
            frmUsers frmUsers = new frmUsers();
            frmUsers.ShowDialog();
        }

        private void lstViewUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lstViewUsers.FocusedItem != null)
            {
                ListViewItem selectedItem = lstViewUsers.FocusedItem;
                string tag = selectedItem.Tag.ToString();
                ID = tag;
                string id = tag;
                clsUser clsUser = new clsUser();
                clsUser.ID = id;
                clsUser.LastModifier = clsUser.ID;
                clsUser.Read();
                frmUsers frmUsers = new frmUsers(clsUser);
                frmUsers.btnEdit.Visible = true;
                frmUsers.btnSave.Visible = false;
                frmUsers.txtPassword.ReadOnly = true;
                frmUsers.txtConfirmPass.ReadOnly = true;

                if (frmUsers.ShowDialog() == DialogResult.OK)
                {
                    selectedItem.SubItems[0].Text = frmUsers.txtFullName.Text;
                    selectedItem.SubItems[1].Text = frmUsers.txtUsername.Text;
                    clsUser.Update();
                    lstViewUsers.FullRowSelect = true;
                }
            }

        }
    }
}
