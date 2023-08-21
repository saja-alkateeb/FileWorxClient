using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlTypes;
using FileWorxServer;
using System.Diagnostics;
using System.Xml;

namespace FileWorxClient
{
    public partial class frmFILEWORX : Form
    {
        private clsUser clsUser;
        public frmFILEWORX(clsUser user)
        {
            InitializeComponent();
            this.clsUser = user;
            mnuSettings.Visible = user.IsAdmin;
        }
        public frmFILEWORX()
        {
            InitializeComponent();
        }
        public void lstViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstViewObjects.FullRowSelect = true;
            if (lstViewObjects.SelectedItems.Count > 0)
            {
                CheckFolderType();
            }
            else if (lstViewObjects.SelectedItems.Count <= 0)
            {
                EmptyFields();
                if (!tCtrlPreview.Controls.Contains(tabPage2))
                    tCtrlPreview.Controls.Add(tabPage2);
            }
        }
        private void frmFILEWORX_NewObjectAdded(object sender, EventArgs e)
        {
            lstViewObjects.Items.Clear();
            PopulateListView();
        }
        public void PopulateListView()
        {
            var filesQuery = new clsFilesQuery();
            filesQuery.Run();
            List<clsFile> fileList = filesQuery.FileDataList;

            foreach (clsFile file in fileList)
            {
                ListViewItem item = new ListViewItem(file.Name);
                item.SubItems.Add(file.CreationDate.ToString());
                item.SubItems.Add(file.Description);
                item.SubItems.Add(file.Creator);
                Debug.WriteLine(file.GetType().Name);
                if (file.clsPhoto != null)
                {
                    item.Tag = $"Photos|{file.ID}";
                }
                else if (file.clsNews != null)
                {
                    item.Tag = $"News|{file.ID}";
                }

                lstViewObjects.Items.Add(item);
            }
        }


        private ClassIds currentFilter = ClassIds.All;
        public void CheckFolderType()
        {
            string tag = lstViewObjects.SelectedItems[0].Tag.ToString();
            string[] tagParts = tag.Split('|');
            string filetype = tagParts[0];
            string id = tagParts[1];
            if (filetype == "Photos")
            {
                var photoDB = new clsPhoto();
                photoDB.ID = id;
                short readStatus=photoDB.Read();
                if (readStatus != 0)
                {
                    MessageBox.Show("Read operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DisplayPhotoPreview(photoDB);
            }
            else//news
            {
                var newsDB = new clsNews();
                newsDB.ID = id;
                short readStatus=newsDB.Read();
                if (readStatus != 0)
                {
                    MessageBox.Show("Read operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DisplayNewsPreview(newsDB);
            }
        }//CheckFolderType
        private void DisplayPhotoPreview(clsPhoto photoDB)
        {
            txtTiltle.Text = photoDB.Name;
            txtCreationDate.Text = photoDB.CreationDate.ToString();
            picImage.Image = Image.FromFile(photoDB.PhotoPath);
            rtbPreview.Text = $"{photoDB.Body}";
            if (!tCtrlPreview.Controls.Contains(tabPage2))
                tCtrlPreview.Controls.Add(tabPage2);
        }
        private void DisplayNewsPreview(clsNews newsDB)
        {
            txtTiltle.Text = newsDB.Name;
            txtCreationDate.Text = newsDB.CreationDate.ToString();
            rtbPreview.Text = $"{newsDB.Body}";
            cmboCategory.SelectedItem = newsDB.Category;
            tCtrlPreview.TabPages.Remove(tabPage2);
            picImage.Image = null;
        }
        public void EmptyFields()
        {
            txtTiltle.Text = null;
            txtCreationDate.Text = null;
            cmboCategory.Text = null;
            rtbPreview.Text = null;
            picImage.Image = null;
        }
        public void frmFILEWORX_Load(object sender, EventArgs e)
        {
            int splitterDistance = (int)(spltContainer.Panel2.Height * (2.5 / 4.0));
            spltContainer.SplitterDistance = splitterDistance;
            PopulateListView();
            this.MinimumSize = new System.Drawing.Size(500, 500);
        }
        private void mnuDelete2_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem;
            lstViewObjects.FullRowSelect = true;
            if (lstViewObjects.SelectedItems.Count > 0)
            {
                selectedItem = lstViewObjects.FocusedItem;
                clsBusinessObject clsBusinessObject = new clsBusinessObject();
                clsPhoto clsPhoto = new clsPhoto();
                string tag = lstViewObjects.SelectedItems[0].Tag.ToString();
                string[] tagParts = tag.Split('|');
                string fileType = tagParts[0];
                string ID = tagParts[1];
                if (MessageBox.Show("Are you sure you want to delete this object?", "Delete Object", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (fileType == "Photos")
                    {
                        DeletePhotoItem(ID);
                    }
                    else if (fileType == "News")
                    {
                        DeleteNewsItem(ID);
                    }
                    selectedItem = lstViewObjects.SelectedItems[0];
                    selectedItem.Remove();
                    EmptyFields();
                }
            }
         }
        private void DeletePhotoItem(string ID)
        {
            var photoDB = new clsPhoto();
            photoDB.ID = ID;
            short readStatus = photoDB.Read();
            if (readStatus != 0)
            {
                MessageBox.Show("Read operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(photoDB.PhotoPathCopy) && File.Exists(photoDB.PhotoPathCopy))
            {
                File.Delete(photoDB.PhotoPathCopy);
            }
            DeleteBusinessObject(ID);
        }
        private void DeleteNewsItem(string ID)
        {
            DeleteBusinessObject(ID);
        }
        private void DeleteBusinessObject(string ID)
        {
            var clsBusinessObject = new clsBusinessObject();
            clsBusinessObject.ID = ID;
            short deleteStatus = clsBusinessObject.Delete();
            if (deleteStatus != 0)
            {
                MessageBox.Show("Delete operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuRelogin_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void mnuNews_Click(object sender, EventArgs e)
        {
            var frmNews = new frmNews();
            frmNews.ShowDialog();
            if (frmNews.DialogResult == DialogResult.OK)
            {
                lstViewObjects.Items.Clear();
                PopulateListView();
            }
        }

        private void mnuPhotos_Click(object sender, EventArgs e)
        {
            var frmPhoto = new frmPhoto();
            frmPhoto.ShowDialog();
            if (frmPhoto.DialogResult == DialogResult.OK)
            {
                lstViewObjects.Items.Clear();
                PopulateListView();
            }
        }

        private void frmFILEWORX_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void mnuUsers_Click(object sender, EventArgs e)
        {
            var frmUsersInfo = new frmUsersInfo();
            frmUsersInfo.Show();
        }
        private void lstViewObjects_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = lstViewObjects.FocusedItem;
            string tag = selectedItem.Tag.ToString();
            string[] tagParts = tag.Split('|');
            string fileType = tagParts[0];
            string id = tagParts[1];

            if (fileType == "Photos")
            {
                var photoDB = new clsPhoto();
                photoDB.ID = id;
                short readStatus = photoDB.Read();
                if (readStatus != 0)
                {
                    MessageBox.Show("Read operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                var frmPhoto = new frmPhoto(photoDB);
                if (frmPhoto.ShowDialog() == DialogResult.OK)
                {
                    lstViewObjects.FullRowSelect = true;
                    if (lstViewObjects.SelectedItems.Count > 0)
                    {
                        CheckFolderType();
                        lstViewObjects.Items.Clear();
                        PopulateListView();
                    }
                    else if (lstViewObjects.SelectedItems.Count <= 0)
                    {
                        EmptyFields();
                        if (!tCtrlPreview.Controls.Contains(tabPage2))
                            tCtrlPreview.Controls.Add(tabPage2);
                    }
                }
            }
            else if (fileType == "News")
            {
                var newsDB = new clsNews();
                newsDB.ID = id;
                short readStatus = newsDB.Read();
                if (readStatus != 0)
                {
                    MessageBox.Show("Read operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                var frmNews = new frmNews(newsDB);
                if (frmNews.ShowDialog() == DialogResult.OK)
                {
                    lstViewObjects.FullRowSelect = true;
                    if (lstViewObjects.SelectedItems.Count > 0)
                    {
                        CheckFolderType();
                        lstViewObjects.Items.Clear();
                        PopulateListView();
                    }
                    else if (lstViewObjects.SelectedItems.Count <= 0)
                    {
                        EmptyFields();
                        if (!tCtrlPreview.Controls.Contains(tabPage2))
                            tCtrlPreview.Controls.Add(tabPage2);
                    }
                }
            }
        }
        private void newsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentFilter = ClassIds.News;
            FilterListViewByClass();
        }
        private void photosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentFilter = ClassIds.Photo;
            FilterListViewByClass();
        }
        private void FilterListViewByClass()
        {
            lstViewObjects.Items.Clear();
            EmptyFields();
            if (!tCtrlPreview.Controls.Contains(tabPage2))
                tCtrlPreview.Controls.Add(tabPage2);
            PopulateListView();
        }
        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clscontact=new clsContact();
            var contactForm = new frmContactProperties(clscontact);
            contactForm.ShowDialog();
        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contactlist=new frmContactList();
            contactlist.ShowDialog();
        }
        private void sendToContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ListViewItem> selectedItems = new List<ListViewItem>();
            foreach (ListViewItem selectedItem in lstViewObjects.SelectedItems)
            {
                selectedItems.Add(selectedItem);
            }

            if (selectedItems.Count > 0)
            {
                using (var contactListForm = new frmContactList())
                {
                    contactListForm.sendObjectsMode = true;
                    if (contactListForm.ShowDialog() == DialogResult.OK)
                    {
                        List<clsContact> selectedContacts = contactListForm.SelectedContacts;
                        clsContact clsContact = new clsContact();
                        clsContact.SendItemsToContactFolders(selectedItems, selectedContacts);
                        MessageBox.Show("Items sent to the selected contact folders.", "Send Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No items selected.", "No Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
