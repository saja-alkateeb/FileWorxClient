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
        public ListUsers()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListUsers_Load(object sender, EventArgs e)
        {
            string usersFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            DataTable dt = new DataTable();
            dt.Columns.Add("Full Name");
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");
            dt.Columns.Add("last Modifier");
            if (Directory.Exists(usersFolderPath))
            {
                string[] userFiles = Directory.GetFiles(usersFolderPath, "*.txt");
                foreach (string filePath in userFiles)
                {
                    string serializedUser = File.ReadAllText(filePath);
                    string[] userAttributes = serializedUser.Split('#');
                    string fullName = userAttributes[0];
                    string username = userAttributes[1];
                    string password = userAttributes[2];
                    string lastModifier = userAttributes[3];
                    dt.Rows.Add(new object[] { fullName, username, password, lastModifier });
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
