using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FileWorxServer;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml;

namespace FileWorxClient
{
    public partial class frmContactProperties : Form
    {
        public clsContact Contact { get; private set; }
        public frmContactProperties(clsContact contact)
        {
            InitializeComponent();
            Contact = contact;
            FillField();
            
        }
        private void FillField()
        {
            txtName.Text = Contact.Name;
            txtLocation.Text = Contact.FolderLocation;
            cmbContactDirection.DataSource = Enum.GetValues(typeof(ContactDirection));
            cmbContactDirection.DataSource = Enum.GetValues(typeof(ContactDirection));
            cmbContactDirection.SelectedIndex = -1;
            cmbContactDirection.SelectedItem = Contact.Direction;
        }
        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            Contact.Name = txtName.Text;
            clsClass classDB = new clsClass();
            Contact.ClassID = (int)ClassIds.Contact;
            Contact.FolderLocation = txtLocation.Text;
            Contact.Direction = (ContactDirection)(cmbContactDirection.SelectedItem);
            if (string.IsNullOrEmpty(Contact.Name) || string.IsNullOrEmpty(Contact.FolderLocation) || string.IsNullOrEmpty(Contact.Direction.ToString()))
            {
                MessageBox.Show("Please enter all the required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Contact.ContactExistsInDatabase(Contact.ID))
            {
                short updateStatus=Contact.Update();
                 
                if (updateStatus != 0)
                {
                    MessageBox.Show("Update operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Contact.ID = Guid.NewGuid().ToString();
                Contact.CreationDate = DateTime.Now;
                short insertStatus = Contact.Insert();
                if (insertStatus != 0)
                {
                    MessageBox.Show("Insert operation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
