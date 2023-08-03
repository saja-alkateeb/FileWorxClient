namespace FileWorxClient
{
    partial class frmUsersInfo
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
            this.lstViewUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreare = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctxUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstViewUsers
            // 
            this.lstViewUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstViewUsers.ContextMenuStrip = this.ctxUsers;
            this.lstViewUsers.HideSelection = false;
            this.lstViewUsers.Location = new System.Drawing.Point(-1, 10);
            this.lstViewUsers.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstViewUsers.MultiSelect = false;
            this.lstViewUsers.Name = "lstViewUsers";
            this.lstViewUsers.Size = new System.Drawing.Size(453, 158);
            this.lstViewUsers.TabIndex = 0;
            this.lstViewUsers.UseCompatibleStateImageBehavior = false;
            this.lstViewUsers.View = System.Windows.Forms.View.Details;
            this.lstViewUsers.SelectedIndexChanged += new System.EventHandler(this.lstViewUsers_SelectedIndexChanged);
            this.lstViewUsers.DoubleClick += new System.EventHandler(this.lstViewUsers_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Full Name";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User Name";
            this.columnHeader2.Width = 100;
            // 
            // ctxUsers
            // 
            this.ctxUsers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDelete});
            this.ctxUsers.Name = "contextMenuStrip1";
            this.ctxUsers.Size = new System.Drawing.Size(108, 26);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(107, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // btnCreare
            // 
            this.btnCreare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreare.Location = new System.Drawing.Point(12, 173);
            this.btnCreare.Name = "btnCreare";
            this.btnCreare.Size = new System.Drawing.Size(75, 30);
            this.btnCreare.TabIndex = 1;
            this.btnCreare.Text = "New user";
            this.btnCreare.UseVisualStyleBackColor = true;
            this.btnCreare.Click += new System.EventHandler(this.btnCreare_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(366, 173);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmUsersInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 210);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreare);
            this.Controls.Add(this.lstViewUsers);
            this.Name = "frmUsersInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users Information";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUsersInfo_FormClosed);
            this.Load += new System.EventHandler(this.frmUsersInfo_Load);
            this.ctxUsers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstViewUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip ctxUsers;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.Button btnCreare;
        private System.Windows.Forms.Button btnClose;
    }
}