namespace FileWorxClient
{
    partial class frmContactList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstContact = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxContact = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.ReceiveTimer = new System.Windows.Forms.Timer(this.components);
            this.radioBtnDB = new System.Windows.Forms.RadioButton();
            this.radioBtnES = new System.Windows.Forms.RadioButton();
            this.ctxContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstContact
            // 
            this.lstContact.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstContact.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstContact.ContextMenuStrip = this.ctxContact;
            this.lstContact.FullRowSelect = true;
            this.lstContact.HideSelection = false;
            this.lstContact.Location = new System.Drawing.Point(3, 2);
            this.lstContact.Name = "lstContact";
            this.lstContact.Size = new System.Drawing.Size(482, 258);
            this.lstContact.TabIndex = 0;
            this.lstContact.UseCompatibleStateImageBehavior = false;
            this.lstContact.View = System.Windows.Forms.View.Details;
            this.lstContact.SelectedIndexChanged += new System.EventHandler(this.lstContact_SelectedIndexChanged);
            this.lstContact.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstContact_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Contact Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Folder Location";
            this.columnHeader2.Width = 150;
            // 
            // ctxContact
            // 
            this.ctxContact.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.ctxContact.Name = "ctxContact";
            this.ctxContact.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(400, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(319, 276);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ReceiveTimer
            // 
            this.ReceiveTimer.Enabled = true;
            this.ReceiveTimer.Interval = 10;
            this.ReceiveTimer.Tick += new System.EventHandler(this.ReceiveTimer_Tick_1);
            // 
            // radioBtnDB
            // 
            this.radioBtnDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioBtnDB.AutoSize = true;
            this.radioBtnDB.Location = new System.Drawing.Point(3, 275);
            this.radioBtnDB.Name = "radioBtnDB";
            this.radioBtnDB.Size = new System.Drawing.Size(71, 17);
            this.radioBtnDB.TabIndex = 3;
            this.radioBtnDB.TabStop = true;
            this.radioBtnDB.Text = "Database";
            this.radioBtnDB.UseVisualStyleBackColor = true;
            this.radioBtnDB.CheckedChanged += new System.EventHandler(this.radioBtnDB_CheckedChanged);
            // 
            // radioBtnES
            // 
            this.radioBtnES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioBtnES.AutoSize = true;
            this.radioBtnES.Location = new System.Drawing.Point(94, 275);
            this.radioBtnES.Name = "radioBtnES";
            this.radioBtnES.Size = new System.Drawing.Size(93, 17);
            this.radioBtnES.TabIndex = 4;
            this.radioBtnES.TabStop = true;
            this.radioBtnES.Text = "Elastic Search";
            this.radioBtnES.UseVisualStyleBackColor = true;
            this.radioBtnES.CheckedChanged += new System.EventHandler(this.radioBtnES_CheckedChanged);
            // 
            // frmContactList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 311);
            this.Controls.Add(this.radioBtnES);
            this.Controls.Add(this.radioBtnDB);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstContact);
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "frmContactList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contact List";
            this.Load += new System.EventHandler(this.frmContactList_Load);
            this.ctxContact.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstContact;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip ctxContact;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Timer ReceiveTimer;
        private System.Windows.Forms.RadioButton radioBtnDB;
        private System.Windows.Forms.RadioButton radioBtnES;
    }
}