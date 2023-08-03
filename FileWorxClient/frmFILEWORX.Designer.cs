
namespace FileWorxClient
{
    partial class frmFILEWORX
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
            this.spltContainer = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNews = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhotos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelogin = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.lstViewObjects = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Lastmodefier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctxContact = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tCtrlPreview = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbPreview = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmboCategory = new System.Windows.Forms.ComboBox();
            this.txtCreationDate = new System.Windows.Forms.TextBox();
            this.txtTiltle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spltContainer)).BeginInit();
            this.spltContainer.Panel1.SuspendLayout();
            this.spltContainer.Panel2.SuspendLayout();
            this.spltContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ctxContact.SuspendLayout();
            this.tCtrlPreview.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // spltContainer
            // 
            this.spltContainer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.spltContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltContainer.Location = new System.Drawing.Point(0, 0);
            this.spltContainer.Margin = new System.Windows.Forms.Padding(2);
            this.spltContainer.Name = "spltContainer";
            this.spltContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltContainer.Panel1
            // 
            this.spltContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.spltContainer.Panel1.Controls.Add(this.menuStrip1);
            this.spltContainer.Panel1.Controls.Add(this.lstViewObjects);
            // 
            // spltContainer.Panel2
            // 
            this.spltContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.spltContainer.Panel2.Controls.Add(this.tCtrlPreview);
            this.spltContainer.Panel2.Controls.Add(this.lblCategory);
            this.spltContainer.Panel2.Controls.Add(this.lblCreationDate);
            this.spltContainer.Panel2.Controls.Add(this.lblTitle);
            this.spltContainer.Panel2.Controls.Add(this.cmboCategory);
            this.spltContainer.Panel2.Controls.Add(this.txtCreationDate);
            this.spltContainer.Panel2.Controls.Add(this.txtTiltle);
            this.spltContainer.Size = new System.Drawing.Size(508, 656);
            this.spltContainer.SplitterDistance = 342;
            this.spltContainer.SplitterWidth = 3;
            this.spltContainer.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "mnuStrip";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreate,
            this.mnuRelogin,
            this.filterToolStripMenuItem});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(40, 20);
            this.mnuFile.Text = " &File";
            // 
            // mnuCreate
            // 
            this.mnuCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNews,
            this.mnuPhotos});
            this.mnuCreate.Name = "mnuCreate";
            this.mnuCreate.Size = new System.Drawing.Size(216, 22);
            this.mnuCreate.Text = "Create new";
            // 
            // mnuNews
            // 
            this.mnuNews.Name = "mnuNews";
            this.mnuNews.Size = new System.Drawing.Size(111, 22);
            this.mnuNews.Text = "News";
            this.mnuNews.Click += new System.EventHandler(this.mnuNews_Click);
            // 
            // mnuPhotos
            // 
            this.mnuPhotos.Name = "mnuPhotos";
            this.mnuPhotos.Size = new System.Drawing.Size(111, 22);
            this.mnuPhotos.Text = "Photos";
            this.mnuPhotos.Click += new System.EventHandler(this.mnuPhotos_Click);
            // 
            // mnuRelogin
            // 
            this.mnuRelogin.Name = "mnuRelogin";
            this.mnuRelogin.ShortcutKeyDisplayString = "Ctrl +L";
            this.mnuRelogin.Size = new System.Drawing.Size(216, 22);
            this.mnuRelogin.Text = "Login As New User";
            this.mnuRelogin.Click += new System.EventHandler(this.mnuRelogin_Click_1);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newsToolStripMenuItem,
            this.photosToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // newsToolStripMenuItem
            // 
            this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
            this.newsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.newsToolStripMenuItem.Text = "News";
            this.newsToolStripMenuItem.Click += new System.EventHandler(this.newsToolStripMenuItem_Click);
            // 
            // photosToolStripMenuItem
            // 
            this.photosToolStripMenuItem.Name = "photosToolStripMenuItem";
            this.photosToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.photosToolStripMenuItem.Text = "Photos";
            this.photosToolStripMenuItem.Click += new System.EventHandler(this.photosToolStripMenuItem_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsers});
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(61, 20);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuUsers
            // 
            this.mnuUsers.Name = "mnuUsers";
            this.mnuUsers.Size = new System.Drawing.Size(147, 22);
            this.mnuUsers.Text = "Users Settings";
            this.mnuUsers.Click += new System.EventHandler(this.mnuUsers_Click);
            // 
            // lstViewObjects
            // 
            this.lstViewObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstViewObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.CreationDate,
            this.Description,
            this.Lastmodefier});
            this.lstViewObjects.ContextMenuStrip = this.ctxContact;
            this.lstViewObjects.GridLines = true;
            this.lstViewObjects.HideSelection = false;
            this.lstViewObjects.Location = new System.Drawing.Point(0, 27);
            this.lstViewObjects.MultiSelect = false;
            this.lstViewObjects.Name = "lstViewObjects";
            this.lstViewObjects.Size = new System.Drawing.Size(507, 321);
            this.lstViewObjects.TabIndex = 16;
            this.lstViewObjects.UseCompatibleStateImageBehavior = false;
            this.lstViewObjects.View = System.Windows.Forms.View.Details;
            this.lstViewObjects.SelectedIndexChanged += new System.EventHandler(this.lstViewUsers_SelectedIndexChanged);
            this.lstViewObjects.DoubleClick += new System.EventHandler(this.lstViewObjects_DoubleClick);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            // 
            // CreationDate
            // 
            this.CreationDate.Text = "Creation Date";
            this.CreationDate.Width = 120;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 200;
            // 
            // Lastmodefier
            // 
            this.Lastmodefier.Text = "Last modefier";
            this.Lastmodefier.Width = 120;
            // 
            // ctxContact
            // 
            this.ctxContact.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxContact.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDelete});
            this.ctxContact.Name = "contextMenuStrip3";
            this.ctxContact.Size = new System.Drawing.Size(108, 26);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(107, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete2_Click);
            // 
            // tCtrlPreview
            // 
            this.tCtrlPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tCtrlPreview.Controls.Add(this.tabPage1);
            this.tCtrlPreview.Controls.Add(this.tabPage2);
            this.tCtrlPreview.Location = new System.Drawing.Point(3, 97);
            this.tCtrlPreview.Name = "tCtrlPreview";
            this.tCtrlPreview.SelectedIndex = 0;
            this.tCtrlPreview.Size = new System.Drawing.Size(502, 221);
            this.tCtrlPreview.TabIndex = 16;
            this.tCtrlPreview.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.tCtrlPreview_ControlRemoved);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtbPreview);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(494, 195);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Preview";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtbPreview
            // 
            this.rtbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPreview.Location = new System.Drawing.Point(0, 2);
            this.rtbPreview.Name = "rtbPreview";
            this.rtbPreview.ReadOnly = true;
            this.rtbPreview.Size = new System.Drawing.Size(501, 182);
            this.rtbPreview.TabIndex = 0;
            this.rtbPreview.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.picImage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(494, 195);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Image";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.Location = new System.Drawing.Point(-1, 3);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(492, 185);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(3, 71);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 15;
            this.lblCategory.Text = "Category";
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Location = new System.Drawing.Point(3, 46);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(72, 13);
            this.lblCreationDate.TabIndex = 14;
            this.lblCreationDate.Text = "Creation Date";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Title";
            // 
            // cmboCategory
            // 
            this.cmboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboCategory.Enabled = false;
            this.cmboCategory.FormattingEnabled = true;
            this.cmboCategory.Items.AddRange(new object[] {
            "General",
            "Sports",
            "Health",
            "Politics"});
            this.cmboCategory.Location = new System.Drawing.Point(87, 75);
            this.cmboCategory.Name = "cmboCategory";
            this.cmboCategory.Size = new System.Drawing.Size(409, 21);
            this.cmboCategory.TabIndex = 12;
            // 
            // txtCreationDate
            // 
            this.txtCreationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreationDate.Location = new System.Drawing.Point(87, 49);
            this.txtCreationDate.MaxLength = 255;
            this.txtCreationDate.Name = "txtCreationDate";
            this.txtCreationDate.ReadOnly = true;
            this.txtCreationDate.Size = new System.Drawing.Size(409, 20);
            this.txtCreationDate.TabIndex = 6;
            // 
            // txtTiltle
            // 
            this.txtTiltle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTiltle.Location = new System.Drawing.Point(87, 23);
            this.txtTiltle.MaxLength = 255;
            this.txtTiltle.Name = "txtTiltle";
            this.txtTiltle.ReadOnly = true;
            this.txtTiltle.Size = new System.Drawing.Size(409, 20);
            this.txtTiltle.TabIndex = 5;
            // 
            // frmFILEWORX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 656);
            this.Controls.Add(this.spltContainer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(60, 47);
            this.Name = "frmFILEWORX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FILEWORX";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFILEWORX_FormClosed_1);
            this.Load += new System.EventHandler(this.frmFILEWORX_Load);
            this.spltContainer.Panel1.ResumeLayout(false);
            this.spltContainer.Panel1.PerformLayout();
            this.spltContainer.Panel2.ResumeLayout(false);
            this.spltContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltContainer)).EndInit();
            this.spltContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ctxContact.ResumeLayout(false);
            this.tCtrlPreview.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spltContainer;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader CreationDate;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.TextBox txtTiltle;
        private System.Windows.Forms.TextBox txtCreationDate;
        private System.Windows.Forms.ComboBox cmboCategory;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuCreate;
        private System.Windows.Forms.ToolStripMenuItem mnuNews;
        private System.Windows.Forms.ToolStripMenuItem mnuPhotos;
        private System.Windows.Forms.ToolStripMenuItem mnuRelogin;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TabControl tCtrlPreview;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtbPreview;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ContextMenuStrip ctxContact;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuUsers;
        private System.Windows.Forms.ColumnHeader Lastmodefier;
        public System.Windows.Forms.ListView lstViewObjects;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem photosToolStripMenuItem;
    }
}