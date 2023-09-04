using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;
using FileWorxServer;
namespace FileWorxClient
{
    public partial class frmUsersInfo : Form
    {
        string separator = Constants.Separator;
        public frmUsersInfo()
        {
            InitializeComponent();
        }
        private void frmUsersInfo_Load(object sender, EventArgs e)
        {
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
                UserQuery.RunDB();
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
        private async void mnuDelete_Click(object sender, EventArgs e)
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
                        short deleteStatus = clsBusinessObject.Delete();
                        clsUser user = new clsUser();   
                        await user.DeleteUserFromElasticsearchAsync(Id);
                        if (deleteStatus != 0)
                        {
                            MessageBox.Show("Delete operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            frmUser frmUsers = new frmUser();
            frmUsers.ShowDialog();
            if (frmUsers.DialogResult == DialogResult.OK)
            {
                lstViewUsers.Items.Clear();
                PopulateListView();
            }
        }

        private void lstViewUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lstViewUsers.FocusedItem != null)
            {
                ListViewItem selectedItem = lstViewUsers.FocusedItem;
                string id = selectedItem.Tag.ToString();  // Get the user's ID

                clsUser userDB = new clsUser();
                userDB.ID = id;
                short readStatus = userDB.Read();
                if (readStatus != 0)
                {
                    MessageBox.Show("Read operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmUser frmUsers = new frmUser(userDB);

                if (frmUsers.ShowDialog() == DialogResult.OK)
                {
                    lstViewUsers.Items.Clear();
                    lstViewUsers.Refresh();
                    PopulateListView();
                }
            }
        }
        private async Task LoadUsersFromElasticsearchAsync()
        {
            clsUserQuery userQuery = new clsUserQuery();
            await userQuery.RunES();
            List<clsUser> userList = userQuery.UserList;
            foreach (clsUser user in userList)
            {
                ListViewItem item = new ListViewItem(user.Name);
                item.SubItems.Add(user.UserName);
                item.Tag = user.ID;
                lstViewUsers.Items.Add(item);
            }
        }
        private void LoadUsersFromDataBase()
        {
            clsUserQuery userQuery = new clsUserQuery();
            userQuery.RunDB();
            List<clsUser> userList = userQuery.UserList;
            foreach (clsUser user in userList)
            {
                ListViewItem item = new ListViewItem(user.Name);
                item.SubItems.Add(user.UserName);
                item.Tag = user.ID;
                lstViewUsers.Items.Add(item);
            }
        }

        private async void radioBtnES_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnES.Checked)
            {
                lstViewUsers.Items.Clear();
                lstViewUsers.Refresh();
                await LoadUsersFromElasticsearchAsync();
            }
        }

        private void radioBtnDB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnDB.Checked)
            {
                lstViewUsers.Items.Clear();
                lstViewUsers.Refresh();
                LoadUsersFromDataBase();
            }
        }
    }
}
