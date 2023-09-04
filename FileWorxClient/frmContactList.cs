using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using FileWorxServer;
using System.Runtime.Remoting.Contexts;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Transport;
using Nest;
using System.Windows.Controls.Primitives;

namespace FileWorxClient
{
    public partial class frmContactList : Form
    {
        public bool sendObjectsMode = false;
        private List<clsContact> contacts;
        string separator = Constants.Separator;
        public List<clsContact> SelectedContacts { get; private set; } = new List<clsContact>();
        public frmContactList()
        {
            InitializeComponent();
            contacts = new List<clsContact>();
        }
        private void frmContactList_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }
        public clsContact GetSelectedContact()
        {
            if (lstContact.SelectedItems.Count > 0)
            {
                int selectedIndex = lstContact.SelectedIndices[0];
                return contacts[selectedIndex]; 
            }
            return null;
        }
        private void LoadContacts()
        {
            clsContactQuery contact = new clsContactQuery();
            contact.RunDB();
            contacts.Clear();
            contacts.AddRange(contact.Contacts);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (lstContact.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in lstContact.SelectedItems)
                {
                    SelectedContacts.Add(selectedItem.Tag as clsContact);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                clsBusinessObject deleteBusinessObject = new clsBusinessObject();
                clsContact contact = lstContact.SelectedItems[0].Tag as clsContact;
                if (lstContact.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete this object?", "Delete Object", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        deleteBusinessObject.ID = contact.ID;
                                        
                        short deleteStatus = deleteBusinessObject.Delete();
                        clsContact deleteContact = new clsContact();
                        await deleteContact.DeleteContactFromElasticsearchAsync(contact.ID);

                        if (deleteStatus != 0)
                        {
                            MessageBox.Show("delete operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ListViewItem selectedItem = lstContact.SelectedItems[0];
                        selectedItem.Remove();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the object: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void ReceiveTimer_Tick_1(object sender, EventArgs e)
        {
            clsContactQuery contact = new clsContactQuery();
            clsContact contacts = new clsContact();
            contact.RunDB();
            contacts.ReceiveFilesFromFolders();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task LoadContactsFromElasticsearchAsync()
        {
            clsContactQuery contact = new clsContactQuery();
            await contact.RunAsync();
            contacts.Clear();
            contacts.AddRange(contact.Contacts);
        }
        private void lstContact_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstContact.FocusedItem != null)
            {
                ListViewItem selectedItem = lstContact.FocusedItem;
                clsContact contacts = lstContact.SelectedItems[0].Tag as clsContact;
                clsContact contact = new clsContact();
                contact.ID =contacts.ID;
                short readStatus = contact.Read();
                if (readStatus != 0)
                {
                    MessageBox.Show("Read operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmContactProperties ContactProperties = new frmContactProperties(contact);
                if (ContactProperties.ShowDialog() == DialogResult.OK)
                {
                    short updateStatus = contact.Update();
                    if (updateStatus != 0)
                    {
                        MessageBox.Show("Update operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    UpdateContactList(contact);
                }
            }
        }
        private void UpdateContactList(clsContact updatedContact)
        {
            int index = contacts.FindIndex(c => c.ID == updatedContact.ID);
            if (index >= 0)
            {
                contacts[index] = updatedContact;
                ListViewItem updatedItem = lstContact.Items[index];
                updatedItem.SubItems[0].Text = updatedContact.Name;
                updatedItem.SubItems[1].Text = updatedContact.FolderLocation;
                updatedItem.Tag = updatedContact;
            }
        }
        private void lstContact_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void PopulateListView()
        {
            lstContact.Items.Clear();
            LoadContacts();
            if (sendObjectsMode)
            {
                PopulateListViewForSendMode();
            }
            else
            {
                PopulateListViewForNormalMode();
            }
        }
        private void PopulateListViewForSendMode()
        {
            foreach (var contact in contacts)
            {
                if (contact.Direction == ContactDirection.TX)
                {
                    AddContactToListView(contact);
                }
            }
        }
        private void AddContactToListView(clsContact contact)
        {
            ListViewItem item = new ListViewItem(contact.Name);
            item.SubItems.Add(contact.FolderLocation);
            item.Tag = contact;
            lstContact.Items.Add(item);
        }

        private void PopulateListViewForNormalMode()
        {
            foreach (var contact in contacts)
            {
                AddContactToListView(contact);
            }
        }
        private async void radioBtnES_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnES.Checked)
            {
                lstContact.Items.Clear();
                await LoadContactsFromElasticsearchAsync();
                if (sendObjectsMode)
                {
                    PopulateListViewForSendMode();
                }
                else
                {
                    PopulateListViewForNormalMode();
                }
            }
        }
        private void radioBtnDB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnDB.Checked)
            {
                PopulateListView();
            }
        }
    }
}
