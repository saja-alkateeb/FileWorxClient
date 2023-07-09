using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileWorxClient
{
    public partial class ListUsers : Form
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public ListUsers()
        {
            InitializeComponent();
        }
        private void ListUsers_Load(object sender, EventArgs e)
        {
            PopulateListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;
        }
        private List<User> GetUsersFromFolder(string folderPath)
        {
            List<User> users = new List<User>();
            string[] usersFiles = Directory.GetFiles(folderPath, "*.txt");
            foreach (string file in usersFiles)
            {
                string serializedusers = File.ReadAllText(file);
                string[] attributes = serializedusers.Split(new string[] { "#%%%#" }, StringSplitOptions.None);
                User user = new User();
                user.FullName = attributes[0];
                user.Username = attributes[1];
                user.Password = attributes[2];
                user.LastModifier = attributes[3];
                user.FileName = attributes[4];
                users.Add(user);
            }
            return users;
            
        }
        public void PopulateListView()
        {

            string usersFolderPath = Path.Combine(desktopPath, "Users");
            Directory.CreateDirectory(usersFolderPath);
            List<User> users = GetUsersFromFolder(usersFolderPath);
            foreach (User user in users)
            {
                ListViewItem item = new ListViewItem(user.FullName);
                item.SubItems.Add(user.Username);
                item.Tag =user.FileName;
                listView1.Items.Add(item);
            }
        }

        public class User
        {
            public string FullName { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string  LastModifier { get; set; }
            public string  FileName { get; set; }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;
            string usersFolderPath = Path.Combine(desktopPath, "Users");
            Directory.CreateDirectory(usersFolderPath);
            string tag = listView1.SelectedItems[0].Tag.ToString();
            string filePath1 = Path.Combine(usersFolderPath, $"{tag}.txt");
            if (listView1.SelectedItems.Count > 0)
            {

                if (MessageBox.Show("Are you sure you want to delete this object?", "Delete Object", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(filePath1);
                    ListViewItem selectedItem = listView1.SelectedItems[0];
                    selectedItem.Remove();
                }
            }
            }

        private void ListUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            var form1 = new Home2();
            form1.Show();
        }
    }
}
