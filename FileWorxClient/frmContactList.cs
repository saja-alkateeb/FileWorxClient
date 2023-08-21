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
            LoadContacts();
            if (sendObjectsMode)
            {
                lstContact.Items.Clear();
                foreach (var contact in contacts)
                {
                    if (contact.Direction == ContactDirection.TX)
                    {
                        ListViewItem item = new ListViewItem(contact.Name);
                        item.SubItems.Add(contact.FolderLocation);
                        item.Tag = contact;
                        lstContact.Items.Add(item);
                    }
                }
            }
            else
            {
                lstContact.Items.Clear();
                foreach (var contact in contacts)
                {
                    ListViewItem item = new ListViewItem(contact.Name);
                    item.SubItems.Add(contact.FolderLocation);
                    item.Tag = contact;
                    lstContact.Items.Add(item);
                }
            }
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
            contact.Run();
            contacts.AddRange(contact.contacts);
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
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                clsBusinessObject clsBusinessObject = new clsBusinessObject();
                clsContact contact = lstContact.SelectedItems[0].Tag as clsContact;
                if (lstContact.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to delete this object?", "Delete Object", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        clsBusinessObject.ID = contact.ID;

                        short deleteStatus = clsBusinessObject.Delete();

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
            contact.Run();
            contacts.ReceiveFilesFromFolders();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
