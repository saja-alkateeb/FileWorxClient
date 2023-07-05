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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FileWorxClient
{
    public partial class newNewsForm :Form
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public newNewsForm()
        {
            InitializeComponent();
            
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            comboBoxCategory.SelectedItem= string.Empty;
            richTextBox1.Clear();
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string newsFolderPath = Path.Combine(desktopPath, "News");
            Directory.CreateDirectory(newsFolderPath);
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            comboBoxCategory.Items.Add("Genera");
            comboBoxCategory.Items.Add("Sports");
            comboBoxCategory.Items.Add("Health");
            comboBoxCategory.Items.Add("Politics");
            string category = comboBoxCategory.SelectedItem.ToString();
            string body = richTextBox1.Text;
            DateTime creationDate = DateTime.Now;
            News news = new News(title, description, category, body, creationDate);
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) ||string.IsNullOrEmpty(category) || string.IsNullOrEmpty(body))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (title.Length > 255 || description.Length > 255 || body.Length > 10000)
            {
                //Haytham note:Detail the error(specify the valid length for each field)
                MessageBox.Show("Please enter valid length.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string fileName = Guid.NewGuid().ToString();
                string filePath = Path.Combine(newsFolderPath, $"{fileName}.txt");
                char separator = '#';
                string data = $"{title}{separator}{creationDate}{separator}{description}{separator}{category}{separator}{body}";
                Directory.CreateDirectory(newsFolderPath);
                File.WriteAllText(filePath, data);
                MessageBox.Show("News created and saved successfully!");
                txtTitle.Text = string.Empty;
                txtDescription.Text = string.Empty;
                comboBoxCategory.Text = string.Empty;   
                richTextBox1.Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while creating the news: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newNewsForm_Load(object sender, EventArgs e)
        {

        }
        public class News
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Body { get; set; }
            public string Category { get; set; }
            public DateTime CreationDate { get; set; }
            public News(string title,string description,string body,string category,DateTime creationDate)
            {
                this.Title = title;
                this.Description = description; 
                this.Body = body;
                this.Category = category;
                this.CreationDate = creationDate;
                
            }

        }
    }
}
    

