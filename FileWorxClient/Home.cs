//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;


//namespace FileWorxClient
//{
//    public partial class mainForm : Form
//    {
//        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
//        public mainForm()
//        {
//            InitializeComponent();
//        }
//        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            var user = new ListUsers();
//            user.ShowDialog();
//        }

//        private void tabPage1_Click(object sender, EventArgs e)
//        {

//        }

//        private void richTextBox1_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void mainForm_Load(object sender, EventArgs e)
//        {
//            PopulateListView();

//        }

//        private void logiToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            this.Hide();
//            var form1 = new loginForm();
//            form1.ShowDialog();
//        }

//        private void newsToolStripMenuItem_Click_1(object sender, EventArgs e)
//        {
//            var form4 = new newNewsForm();
//            form4.Show();

//        }

//        private void photosToolStripMenuItem_Click_1(object sender, EventArgs e)
//        {
//            var form6 = new CreatePhotos();
//            form6.Show();
//        }

//        private void tabPage1_Click_1(object sender, EventArgs e)
//        {

//        }

//        public void listView1_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            listView1.FullRowSelect = true;
//            if (listView1.SelectedItems.Count > 0)
//            {

//                string tag = listView1.SelectedItems[0].Tag.ToString();
//                string[] tagParts = tag.Split('|');

//                string folder = tagParts[0];
//                string filePath = tagParts[1];

//                if (folder == "Photos")
//                {
//                    string photosFolderPath = Path.Combine(desktopPath, "Photos");
//                    Directory.CreateDirectory(photosFolderPath);
//                    string filePaths = Path.Combine(photosFolderPath, $"{filePath}.txt");
//                    string serializedPhoto = File.ReadAllText(filePaths);
//                    string[] photoAttributes = serializedPhoto.Split(new[] { "#%%%#" }, StringSplitOptions.None);
//                    string title = photoAttributes[0];
//                    string creationDate = photoAttributes[1];
//                    string description = photoAttributes[2];
//                    string imagePath = photoAttributes[3];
//                    string body = photoAttributes[4];
//                    txtTiltle.Text = title;
//                    txtCreationDate.Text = creationDate;
//                    comboCategory.Text = null;
//                    pictureBox1.Image = Image.FromFile(imagePath);
//                    richTextBox1.Text = $"{body}";
//                    this.txtTiltle.ReadOnly = true;
//                    this.txtCreationDate.ReadOnly = true;


//                }
//                else if (folder == "News")
//                {
//                    string newsFolderPath = Path.Combine(desktopPath, "news");
//                    Directory.CreateDirectory(newsFolderPath);
//                    string filePaths = Path.Combine(newsFolderPath, $"{filePath}.txt");
//                    string serializedNew = File.ReadAllText(filePaths);
//                    string[] newAttributes = serializedNew.Split(new[] { "#%%%#" }, StringSplitOptions.None);
//                    string title = newAttributes[0];
//                    string creationDate = newAttributes[1];
//                    string description = newAttributes[2];
//                    string category = newAttributes[3];
//                    string body = newAttributes[4];
//                    txtTiltle.Text = title;
//                    txtCreationDate.Text = creationDate;
//                    comboCategory.SelectedItem= category;
//                    this.txtTiltle.ReadOnly = true;
//                    this.txtCreationDate.ReadOnly = true;
//                    richTextBox1.Text = $"{body}";
//                    pictureBox1.Image = null;
//                }
//            }

//            else if (listView1.SelectedItems.Count <= 0)
//            {
//                txtTiltle.Text = null;
//                txtCreationDate.Text = null;
//                comboCategory.Text = null;
//                richTextBox1.Text = null;
//                pictureBox1.Image = null;
//            }


//            }
        

//        public class ContentFile
//        {
//            public string Title { get; set; }
//            public string Description { get; set; }
//            public DateTime CreationDate { get; set; }
//            public string Body { get; set; }
//        }
//        public class Photo : ContentFile
//        {
//            public string ImagePath { get; set; }
//            public string FileName { get; set; }
//            public void editPhoto(string filePath)
//            {
//            }

//        }

//        public class News : ContentFile
//        {
//            public string Category { get; set; }
//            public string FileName { get; set; }
//        }
//        private List<Photo> GetPhotosFromFolder(string folderPath)
//        {
//            List<Photo> photos = new List<Photo>();
//            string[] photosFiles = Directory.GetFiles(folderPath, "*.txt");
//            foreach (string file in photosFiles)
//            {
//                string serializedPhotos = File.ReadAllText(file);
//                string[] attributes = serializedPhotos.Split(new string[] { "#%%%#" }, StringSplitOptions.None);
//                Photo photo = new Photo();
//                photo.Title = attributes[0];
//                photo.CreationDate = DateTime.Parse(attributes[1]);
//                photo.Description = attributes[2];
//                photo.ImagePath = attributes[3];
//                photo.Body = attributes[4];
//                photo.FileName = attributes[5];
//                photos.Add(photo);
//            }
//            return photos;
//        }



//        private List<News> GetNewsFromFolder(string folderPath)
//        {
//            List<News> newsList = new List<News>();
//            string[] files = Directory.GetFiles(folderPath);
//            foreach (string file in files)
//            {
//                string serializedNews = File.ReadAllText(file);
//                string[] attributes = serializedNews.Split(new string[] { "#%%%#" }, StringSplitOptions.None);
//                News news = new News();
//                news.Title = attributes[0];
//                news.CreationDate = DateTime.Parse(attributes[1]);
//                news.Description = attributes[2];
//                news.Category = attributes[3];
//                news.Body = attributes[4];
//                news.FileName = attributes[5];
//                newsList.Add(news);
//            }
//            return newsList;
//        }
//        public void PopulateListView()
//        {
//            string newsFolderPath = Path.Combine(desktopPath, "News");
//            Directory.CreateDirectory(newsFolderPath);
//            string photosFolderPath = Path.Combine(desktopPath, "Photos");
//            Directory.CreateDirectory(photosFolderPath);
//            List<Photo> photos = GetPhotosFromFolder(photosFolderPath);
//            List<News> newsList = GetNewsFromFolder(newsFolderPath);
//            foreach (Photo photo in photos)
//            {
//                ListViewItem item = new ListViewItem(photo.Title);
//                item.SubItems.Add(photo.CreationDate.ToString());
//                item.SubItems.Add(photo.Description);
//                item.Tag = $"Photos|{photo.FileName}";
//                listView1.Items.Add(item);
//            }
//            foreach (News news in newsList)
//            {
//                ListViewItem item = new ListViewItem(news.Title);
//                item.SubItems.Add(news.CreationDate.ToString());
//                item.SubItems.Add(news.Description);
//                item.Tag = $"News|{news.FileName}";
//                listView1.Items.Add(item);
//            }
//        }
//        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            if (listView1.SelectedItems.Count >0)
//            {
//                string tag = listView1.SelectedItems[0].Tag.ToString();
//                string[] tagParts = tag.Split('|');
//                string folder = tagParts[0];
//                string filePath = tagParts[1];
//                string photosFolderPath = Path.Combine(desktopPath, "Photos");
//                Directory.CreateDirectory(photosFolderPath);
//                string filePath1 = Path.Combine(photosFolderPath, $"{filePath}.txt");
//                string newsFolderPath = Path.Combine(desktopPath, "news");
//                Directory.CreateDirectory(newsFolderPath);
//                string filePath2 = Path.Combine(newsFolderPath, $"{filePath}.txt");
//                if (MessageBox.Show("Are you sure you want to delete this object?", "Delete Object", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//                {
//                    if (folder == "Photos")
//                    {
//                        File.Delete(filePath1);
//                    }
//                    else
//                    {
//                        File.Delete(filePath2);
//                    }
//                    ListViewItem selectedItem = listView1.SelectedItems[0];
//                    selectedItem.Remove();
//                    txtTiltle.Text = null;
//                    txtCreationDate.Text = null;
//                    comboCategory.Text = null;
//                    richTextBox1.Text = null;
//                    pictureBox1.Image = null;
//                }
                
//            }
         
//        }


//        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
//        {
//            Application.ExitThread();
//        }

//        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
//        {
//            if (listView1.FocusedItem != null)
//            {
//                ListViewItem selectedItem = listView1.FocusedItem;
//                string tag = selectedItem.Tag.ToString();
//                string[] tagParts = tag.Split('|');

//                string folder = tagParts[0];
//                string filePath = tagParts[1];

//                //if (folder == "Photos")
//                //{
//                //    // Edit photo object
//                //    Photo editPhotoForm = new Photo();
//                //    if (editPhotoForm.ShowDialog() == DialogResult.OK)
//                //    {
//                //        editPhoto
//                //        // Update the item in the ListView
//                //        selectedItem.SubItems[0].Text = editPhotoForm.Title;
//                //        selectedItem.SubItems[1].Text = editPhotoForm.CreationDate.ToString();
//                //        selectedItem.SubItems[2].Text = editPhotoForm.Description;
//                //    }
//                //}
//                //else if (folder == "News")
//                //{
//                //    // Edit news object
//                //    EditNewsForm editNewsForm = new EditNewsForm(filePath);
//                //    if (editNewsForm.ShowDialog() == DialogResult.OK)
//                //    {
//                //        // Update the item in the ListView
//                //        selectedItem.SubItems[0].Text = editNewsForm.Title;
//                //        selectedItem.SubItems[1].Text = editNewsForm.CreationDate.ToString();
//                //        selectedItem.SubItems[2].Text = editNewsForm.Description;
//                //    }
//                //}

//            }
//        }

//        private void showUsersToolStripMenuItem_Click(object sender, EventArgs e)
//        {
//            ListUsers listusers = new ListUsers();
//            listusers.Show();
//        }
//    }
//   }
    