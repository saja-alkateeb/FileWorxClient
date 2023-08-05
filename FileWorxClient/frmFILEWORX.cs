using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace FileWorxClient
{
    public partial class frmFILEWORX : Form
    {
        public delegate void NewObjectAddedEventHandler(object sender, EventArgs e);
        public event NewObjectAddedEventHandler NewObjectAdded;
        string separator = Constants.Separator;
        private clsUser clsUser;
        public frmFILEWORX(clsUser user)
        {
            InitializeComponent();
            this.clsUser = user;
            mnuSettings.Visible = user.IsAdmin;
            this.NewObjectAdded += frmFILEWORX_NewObjectAdded;
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
        public void OnNewObjectAdded(EventArgs e)
        {
            NewObjectAdded?.Invoke(this, e);
        }
        public void PopulateListView()
        {
            var photoDB = new clsPhoto();
            var photoQuery = new clsPhotoQuery();
            var newsDB = new clsNews();
            var newsQuery = new clsNewsQuery();
            photoQuery.QClasses = ClassIds.Photo;
            newsQuery.QClasses = ClassIds.News;
            photoQuery.Run();
            newsQuery.Run();
            List<clsPhoto> photosList = photoQuery.PhotoList;
            List<clsNews> newsList = newsQuery.NewsList;
            foreach (clsPhoto photo in photosList)
            {
                ListViewItem item = new ListViewItem(photo.Name);
                item.SubItems.Add(photo.CreationDate.ToString());
                item.SubItems.Add(photo.Description);
                item.SubItems.Add(photo.Creator);
                item.Tag = $"Photos|{photo.ID}";// Store the photo ID in the Tag
                lstViewObjects.Items.Add(item);
            }
            foreach (clsNews news in newsList)
            {
                ListViewItem item = new ListViewItem(news.Name);
                item.SubItems.Add(news.CreationDate.ToString());
                item.SubItems.Add(news.Description);
                item.SubItems.Add(news.Creator);
                item.Tag = $"News|{news.ID}"; // Store the news ID in the Tag
                lstViewObjects.Items.Add(item);
            }
        }
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
                photoDB.Read();
                txtTiltle.Text = photoDB.Name;
                txtCreationDate.Text = photoDB.CreationDate.ToString();
                picImage.Image = Image.FromFile(photoDB.PhotoPath);
                rtbPreview.Text = $"{photoDB.Body}";
                if (!tCtrlPreview.Controls.Contains(tabPage2))
                    tCtrlPreview.Controls.Add(tabPage2);
            }
            else//news
            {
                var newsDB = new clsNews();
                newsDB.ID = id;
                newsDB.Read();
                txtTiltle.Text = newsDB.Name;
                txtCreationDate.Text = newsDB.CreationDate.ToString();
                rtbPreview.Text = $"{newsDB.Body}";
                cmboCategory.SelectedItem = newsDB.Category;
                tCtrlPreview.TabPages.Remove(tabPage2);
                picImage.Image = null;
            }
        }//CheckFolderType
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
                        var photoDB = new clsPhoto();
                        photoDB.ID = ID;
                        photoDB.Read();
                        if (!string.IsNullOrEmpty(photoDB.PhotoPathCopy) && File.Exists(photoDB.PhotoPathCopy))
                        {
                            File.Delete(photoDB.PhotoPathCopy);
                        }

                        clsBusinessObject.ID = ID;
                        clsBusinessObject.Delete();
                    }
                    else if (fileType == "News")
                    {
                        clsBusinessObject.ID = ID;
                        clsBusinessObject.Delete();
                    }
                    selectedItem = lstViewObjects.SelectedItems[0];
                    selectedItem.Remove();
                    EmptyFields();
                }
            }

         }

        private void mnuRelogin_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new frmLogin();
            form1.Show();
        }

        private void mnuNews_Click(object sender, EventArgs e)
        {
            var form4 = new frmNews(clsUser.LastModifier)
            {
                Owner = this 
            };
            form4.Show();
        }

        private void mnuPhotos_Click(object sender, EventArgs e)
        {
            var form6 = new frmPhoto(clsUser.LastModifier)
            {
                Owner = this
            };
            form6.Show();
        }

        private void frmFILEWORX_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tCtrlPreview_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void mnuUsers_Click(object sender, EventArgs e)
        {
            var form = new frmUsersInfo();
            form.Show();
        }
        private void mnuSettings_Click(object sender, EventArgs e)
        {
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
                photoDB.LastModifier = clsUser.ID;
                photoDB.Read();
                var frmPhoto = new frmPhoto(photoDB);
                frmPhoto.btnEdit.Visible = true;
                frmPhoto.btnSave.Visible = false;
                if (frmPhoto.ShowDialog() == DialogResult.OK)
                {
                    //DateTime creationDate = DateTime.Now;
                    selectedItem.SubItems[0].Text = frmPhoto.txtTitle.Text;
                    selectedItem.SubItems[1].Text = photoDB.CreationDate.ToString();
                    selectedItem.SubItems[2].Text = frmPhoto.txtDescription.Text;
                    //selectedItem.SubItems[3].Text = photo.LastModifier;
                    photoDB.Update();
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
            }//Photo
            else if (fileType == "News")
            {
                var newsDB = new clsNews();
                newsDB.ID = id;
                newsDB.LastModifier = clsUser.ID;
                newsDB.Read();
                frmNews frmNews = new frmNews(newsDB);
                frmNews.btnEdit.Visible = true;
                frmNews.btnSave.Visible = false;

                if (frmNews.ShowDialog() == DialogResult.OK)
                {
                    selectedItem.SubItems[0].Text = frmNews.txtTitle.Text;
                    selectedItem.SubItems[1].Text = newsDB.CreationDate.ToString();
                    selectedItem.SubItems[2].Text = frmNews.txtDescription.Text;
                    newsDB.Update();
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
            }
        }
        private void newsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstViewObjects.Items.Clear();
            EmptyFields();
            if (!tCtrlPreview.Controls.Contains(tabPage2))
                tCtrlPreview.Controls.Add(tabPage2);
            var newsDB = new clsNews();
            var newsQuery = new clsNewsQuery();
            newsQuery.QClasses = ClassIds.News;
            newsQuery.Run();
            List<clsNews> newsList = newsQuery.NewsList;
            foreach (clsNews news in newsList)
            {
                ListViewItem item = new ListViewItem(news.Name);
                item.SubItems.Add(news.CreationDate.ToString());
                item.SubItems.Add(news.Description);
                item.SubItems.Add(news.Creator);
                item.Tag = $"News|{news.ID}"; 
                lstViewObjects.Items.Add(item);
            }
        }
        private void photosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstViewObjects.Items.Clear();
            EmptyFields();
            if (!tCtrlPreview.Controls.Contains(tabPage2))
                tCtrlPreview.Controls.Add(tabPage2);
            var photoDB = new clsPhoto();
            var photoQuery = new clsPhotoQuery();
            photoQuery.QClasses = ClassIds.Photo;
            photoQuery.Run();
            List<clsPhoto> photosList = photoQuery.PhotoList;
            foreach (clsPhoto photo in photosList)
            {
                ListViewItem item = new ListViewItem(photo.Name);
                item.SubItems.Add(photo.CreationDate.ToString());
                item.SubItems.Add(photo.Description);
                item.SubItems.Add(photo.Creator);
                item.Tag = $"Photos|{photo.ID}";
                lstViewObjects.Items.Add(item);
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
