//namespace FileWorxClient
//{
//    partial class mainForm
//    {
//        / <summary>
//        / Required designer variable.
//        / </summary>
//        private System.ComponentModel.IContainer components = null;

//        / <summary>
//        / Clean up any resources being used.
//        / </summary>
//        / <param name = "disposing" > true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        / <summary>
//        / Required method for Designer support - do not modify
//        / the contents of this method with the code editor.
//        / </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
//            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
//            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.photosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.logiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.showUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
//            this.listView1 = new System.Windows.Forms.ListView();
//            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
//            this.CreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
//            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
//            this.LastModifier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
//            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
//            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
//            this.txtTiltle = new System.Windows.Forms.TextBox();
//            this.txtCreationDate = new System.Windows.Forms.TextBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label3 = new System.Windows.Forms.Label();
//            this.tabControl1 = new System.Windows.Forms.TabControl();
//            this.tabPage1 = new System.Windows.Forms.TabPage();
//            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
//            this.tabPage2 = new System.Windows.Forms.TabPage();
//            this.pictureBox1 = new System.Windows.Forms.PictureBox();
//            this.comboCategory = new System.Windows.Forms.ComboBox();
//            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
//            this.deleteToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
//            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
//            this.contextMenuStrip1.SuspendLayout();
//            this.menuStrip1.SuspendLayout();
//            this.contextMenuStrip2.SuspendLayout();
//            this.tabControl1.SuspendLayout();
//            this.tabPage1.SuspendLayout();
//            this.tabPage2.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
//            this.contextMenuStrip3.SuspendLayout();
//            this.SuspendLayout();

//            contextMenuStrip1


//            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.deleteToolStripMenuItem});
//            this.contextMenuStrip1.Name = "contextMenuStrip1";
//            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 28);

//            deleteToolStripMenuItem


//            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
//            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
//            this.deleteToolStripMenuItem.Text = "Delete";
//            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);

//            menuStrip1


//            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.fileToolStripMenuItem,
//            this.settingsToolStripMenuItem,
//            this.showUsersToolStripMenuItem});
//            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
//            this.menuStrip1.Name = "menuStrip1";
//            this.menuStrip1.Size = new System.Drawing.Size(632, 28);
//            this.menuStrip1.TabIndex = 1;
//            this.menuStrip1.Text = "menuStrip1";

//            fileToolStripMenuItem


//            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.createNewToolStripMenuItem,
//            this.logiToolStripMenuItem});
//            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
//            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
//            this.fileToolStripMenuItem.Text = " &File";

//            createNewToolStripMenuItem


//            this.createNewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.newsToolStripMenuItem,
//            this.photosToolStripMenuItem});
//            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
//            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
//            this.createNewToolStripMenuItem.Text = "Create new";

//            newsToolStripMenuItem


//            this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
//            this.newsToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
//            this.newsToolStripMenuItem.Text = "News";
//            this.newsToolStripMenuItem.Click += new System.EventHandler(this.newsToolStripMenuItem_Click_1);

//            photosToolStripMenuItem


//            this.photosToolStripMenuItem.Name = "photosToolStripMenuItem";
//            this.photosToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
//            this.photosToolStripMenuItem.Text = "Photos";
//            this.photosToolStripMenuItem.Click += new System.EventHandler(this.photosToolStripMenuItem_Click_1);

//            logiToolStripMenuItem


//            this.logiToolStripMenuItem.Name = "logiToolStripMenuItem";
//            this.logiToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl +L";
//            this.logiToolStripMenuItem.Size = new System.Drawing.Size(269, 26);
//            this.logiToolStripMenuItem.Text = "Login As New User";
//            this.logiToolStripMenuItem.Click += new System.EventHandler(this.logiToolStripMenuItem_Click);

//            settingsToolStripMenuItem


//            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
//            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
//            this.settingsToolStripMenuItem.Text = "Settings";

//            showUsersToolStripMenuItem


//            this.showUsersToolStripMenuItem.Name = "showUsersToolStripMenuItem";
//            this.showUsersToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
//            this.showUsersToolStripMenuItem.Text = "Show Users";
//            this.showUsersToolStripMenuItem.Click += new System.EventHandler(this.showUsersToolStripMenuItem_Click);

//            listView1


//            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
//            this.Title,
//            this.CreationDate,
//            this.Description,
//            this.LastModifier});
//            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
//            this.listView1.GridLines = true;
//            this.listView1.HideSelection = false;
//            this.listView1.Location = new System.Drawing.Point(4, 55);
//            this.listView1.Margin = new System.Windows.Forms.Padding(4);
//            this.listView1.MultiSelect = false;
//            this.listView1.Name = "listView1";
//            this.listView1.Size = new System.Drawing.Size(619, 241);
//            this.listView1.TabIndex = 15;
//            this.listView1.UseCompatibleStateImageBehavior = false;
//            this.listView1.View = System.Windows.Forms.View.Details;
//            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
//            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);

//            Title


//            this.Title.Text = "Title";

//            CreationDate


//            this.CreationDate.Text = "Creation Date";
//            this.CreationDate.Width = 120;

//            Description


//            this.Description.Text = "Description";
//            this.Description.Width = 200;

//            LastModifier


//            this.LastModifier.Text = "Last Modifier";
//            this.LastModifier.Width = 120;

//            contextMenuStrip2


//            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.deleteToolStripMenuItem1});
//            this.contextMenuStrip2.Name = "contextMenuStrip2";
//            this.contextMenuStrip2.Size = new System.Drawing.Size(123, 28);

//            deleteToolStripMenuItem1


//            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
//            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(122, 24);
//            this.deleteToolStripMenuItem1.Text = "Delete";

//            txtTiltle


//            this.txtTiltle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.txtTiltle.Location = new System.Drawing.Point(121, 306);
//            this.txtTiltle.Margin = new System.Windows.Forms.Padding(4);
//            this.txtTiltle.Name = "txtTiltle";
//            this.txtTiltle.Size = new System.Drawing.Size(502, 22);
//            this.txtTiltle.TabIndex = 4;

//            txtCreationDate


//            this.txtCreationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.txtCreationDate.Location = new System.Drawing.Point(121, 342);
//            this.txtCreationDate.Margin = new System.Windows.Forms.Padding(4);
//            this.txtCreationDate.Name = "txtCreationDate";
//            this.txtCreationDate.Size = new System.Drawing.Size(502, 22);
//            this.txtCreationDate.TabIndex = 5;

//            label1


//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(13, 309);
//            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(35, 17);
//            this.label1.TabIndex = 7;
//            this.label1.Text = "Title";

//            label2


//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(13, 345);
//            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(95, 17);
//            this.label2.TabIndex = 8;
//            this.label2.Text = "Creation Date";

//            label3


//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(13, 378);
//            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(65, 17);
//            this.label3.TabIndex = 9;
//            this.label3.Text = "Category";

//            tabControl1


//            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.tabControl1.Controls.Add(this.tabPage1);
//            this.tabControl1.Controls.Add(this.tabPage2);
//            this.tabControl1.Location = new System.Drawing.Point(0, 427);
//            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
//            this.tabControl1.Name = "tabControl1";
//            this.tabControl1.SelectedIndex = 0;
//            this.tabControl1.Size = new System.Drawing.Size(632, 298);
//            this.tabControl1.TabIndex = 10;

//            tabPage1


//            this.tabPage1.Controls.Add(this.richTextBox1);
//            this.tabPage1.Location = new System.Drawing.Point(4, 25);
//            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
//            this.tabPage1.Name = "tabPage1";
//            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
//            this.tabPage1.Size = new System.Drawing.Size(624, 269);
//            this.tabPage1.TabIndex = 0;
//            this.tabPage1.Text = "Preview";
//            this.tabPage1.UseVisualStyleBackColor = true;
//            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click_1);

//            richTextBox1


//            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.richTextBox1.Location = new System.Drawing.Point(0, 2);
//            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
//            this.richTextBox1.Name = "richTextBox1";
//            this.richTextBox1.Size = new System.Drawing.Size(628, 258);
//            this.richTextBox1.TabIndex = 0;
//            this.richTextBox1.Text = "";

//            tabPage2


//            this.tabPage2.Controls.Add(this.pictureBox1);
//            this.tabPage2.Location = new System.Drawing.Point(4, 25);
//            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
//            this.tabPage2.Name = "tabPage2";
//            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
//            this.tabPage2.Size = new System.Drawing.Size(624, 269);
//            this.tabPage2.TabIndex = 1;
//            this.tabPage2.Text = "Image";
//            this.tabPage2.UseVisualStyleBackColor = true;

//            pictureBox1


//            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.pictureBox1.Location = new System.Drawing.Point(-1, 4);
//            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
//            this.pictureBox1.Name = "pictureBox1";
//            this.pictureBox1.Size = new System.Drawing.Size(629, 266);
//            this.pictureBox1.TabIndex = 0;
//            this.pictureBox1.TabStop = false;

//            comboCategory


//            this.comboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.comboCategory.FormattingEnabled = true;
//            this.comboCategory.Items.AddRange(new object[] {
//            "General",
//            "Sports",
//            "Health",
//            "Politics"});
//            this.comboCategory.Location = new System.Drawing.Point(121, 378);
//            this.comboCategory.Margin = new System.Windows.Forms.Padding(4);
//            this.comboCategory.Name = "comboCategory";
//            this.comboCategory.Size = new System.Drawing.Size(502, 24);
//            this.comboCategory.TabIndex = 11;

//            contextMenuStrip3


//            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
//            this.deleteToolStripMenuItem2});
//            this.contextMenuStrip3.Name = "contextMenuStrip3";
//            this.contextMenuStrip3.Size = new System.Drawing.Size(123, 28);

//            deleteToolStripMenuItem2


//            this.deleteToolStripMenuItem2.Name = "deleteToolStripMenuItem2";
//            this.deleteToolStripMenuItem2.Size = new System.Drawing.Size(122, 24);
//            this.deleteToolStripMenuItem2.Text = "Delete";

//            contextMenuStrip4


//            this.contextMenuStrip4.ImageScalingSize = new System.Drawing.Size(20, 20);
//            this.contextMenuStrip4.Name = "contextMenuStrip4";
//            this.contextMenuStrip4.Size = new System.Drawing.Size(61, 4);

//            mainForm


//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(632, 725);
//            this.Controls.Add(this.comboCategory);
//            this.Controls.Add(this.tabControl1);
//            this.Controls.Add(this.label3);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.txtCreationDate);
//            this.Controls.Add(this.txtTiltle);
//            this.Controls.Add(this.listView1);
//            this.Controls.Add(this.menuStrip1);
//            this.Margin = new System.Windows.Forms.Padding(4);
//            this.Name = "mainForm";
//            this.Text = "FileWorx";
//            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
//            this.Load += new System.EventHandler(this.mainForm_Load);
//            this.contextMenuStrip1.ResumeLayout(false);
//            this.menuStrip1.ResumeLayout(false);
//            this.menuStrip1.PerformLayout();
//            this.contextMenuStrip2.ResumeLayout(false);
//            this.tabControl1.ResumeLayout(false);
//            this.tabPage1.ResumeLayout(false);
//            this.tabPage2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
//            this.contextMenuStrip3.ResumeLayout(false);
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion
//        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
//        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
//        private System.Windows.Forms.MenuStrip menuStrip1;
//        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem logiToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
//        private System.Windows.Forms.ToolStripMenuItem photosToolStripMenuItem;
//        private System.Windows.Forms.ListView listView1;
//        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
//        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
//        private System.Windows.Forms.TextBox txtTiltle;
//        private System.Windows.Forms.TextBox txtCreationDate;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.TabControl tabControl1;
//        private System.Windows.Forms.TabPage tabPage1;
//        private System.Windows.Forms.TabPage tabPage2;
//        private System.Windows.Forms.ComboBox comboCategory;
//        private System.Windows.Forms.ColumnHeader Title;
//        private System.Windows.Forms.ColumnHeader CreationDate;
//        private System.Windows.Forms.ColumnHeader Description;
//        private System.Windows.Forms.PictureBox pictureBox1;
//        private System.Windows.Forms.RichTextBox richTextBox1;
//        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
//        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem2;
//        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
//        private System.Windows.Forms.ColumnHeader LastModifier;
//        private System.Windows.Forms.ToolStripMenuItem showUsersToolStripMenuItem;
//    }
//}