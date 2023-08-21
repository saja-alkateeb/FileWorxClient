namespace FileWorxClient
{
    partial class frmPhoto
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
            this.tabCtrlInfo = new System.Windows.Forms.TabControl();
            this.tabPge1 = new System.Windows.Forms.TabPage();
            this.rtbBody = new System.Windows.Forms.RichTextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabPge2 = new System.Windows.Forms.TabPage();
            this.picPhotos = new System.Windows.Forms.PictureBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblImgPath = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabCtrlInfo.SuspendLayout();
            this.tabPge1.SuspendLayout();
            this.tabPge2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhotos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCtrlInfo
            // 
            this.tabCtrlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrlInfo.Controls.Add(this.tabPge1);
            this.tabCtrlInfo.Controls.Add(this.tabPge2);
            this.tabCtrlInfo.Location = new System.Drawing.Point(-3, 1);
            this.tabCtrlInfo.Name = "tabCtrlInfo";
            this.tabCtrlInfo.SelectedIndex = 0;
            this.tabCtrlInfo.Size = new System.Drawing.Size(458, 368);
            this.tabCtrlInfo.TabIndex = 0;
            // 
            // tabPge1
            // 
            this.tabPge1.Controls.Add(this.rtbBody);
            this.tabPge1.Controls.Add(this.txtDescription);
            this.tabPge1.Controls.Add(this.txtTitle);
            this.tabPge1.Controls.Add(this.lblBody);
            this.tabPge1.Controls.Add(this.lblDescription);
            this.tabPge1.Controls.Add(this.lblTitle);
            this.tabPge1.Location = new System.Drawing.Point(4, 22);
            this.tabPge1.Name = "tabPge1";
            this.tabPge1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPge1.Size = new System.Drawing.Size(450, 342);
            this.tabPge1.TabIndex = 0;
            this.tabPge1.Text = "File Description";
            this.tabPge1.UseVisualStyleBackColor = true;
            // 
            // rtbBody
            // 
            this.rtbBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbBody.Location = new System.Drawing.Point(73, 86);
            this.rtbBody.MaxLength = 10000;
            this.rtbBody.Name = "rtbBody";
            this.rtbBody.Size = new System.Drawing.Size(369, 250);
            this.rtbBody.TabIndex = 5;
            this.rtbBody.Text = "";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(73, 60);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(369, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(73, 34);
            this.txtTitle.MaxLength = 255;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(369, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Location = new System.Drawing.Point(7, 86);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(31, 13);
            this.lblBody.TabIndex = 4;
            this.lblBody.Text = "Body";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(7, 60);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(7, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // tabPge2
            // 
            this.tabPge2.Controls.Add(this.picPhotos);
            this.tabPge2.Controls.Add(this.txtLocation);
            this.tabPge2.Controls.Add(this.lblImgPath);
            this.tabPge2.Controls.Add(this.btnBrowse);
            this.tabPge2.Location = new System.Drawing.Point(4, 22);
            this.tabPge2.Name = "tabPge2";
            this.tabPge2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPge2.Size = new System.Drawing.Size(450, 320);
            this.tabPge2.TabIndex = 1;
            this.tabPge2.Text = "Image";
            this.tabPge2.UseVisualStyleBackColor = true;
            // 
            // picPhotos
            // 
            this.picPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPhotos.Location = new System.Drawing.Point(21, 67);
            this.picPhotos.Name = "picPhotos";
            this.picPhotos.Size = new System.Drawing.Size(412, 250);
            this.picPhotos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhotos.TabIndex = 3;
            this.picPhotos.TabStop = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(94, 41);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(256, 20);
            this.txtLocation.TabIndex = 2;
            // 
            // lblImgPath
            // 
            this.lblImgPath.AutoSize = true;
            this.lblImgPath.Location = new System.Drawing.Point(18, 44);
            this.lblImgPath.Name = "lblImgPath";
            this.lblImgPath.Size = new System.Drawing.Size(61, 13);
            this.lblImgPath.TabIndex = 1;
            this.lblImgPath.Text = "Image Path";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrowse.Location = new System.Drawing.Point(356, 39);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(369, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(289, 375);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 34);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 411);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabCtrlInfo);
            this.Controls.Add(this.btnSave);
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "frmPhoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Photo";
            this.tabCtrlInfo.ResumeLayout(false);
            this.tabPge1.ResumeLayout(false);
            this.tabPge1.PerformLayout();
            this.tabPge2.ResumeLayout(false);
            this.tabPge2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPhotos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrlInfo;
        private System.Windows.Forms.TabPage tabPge1;
        private System.Windows.Forms.TabPage tabPge2;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picPhotos;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblImgPath;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.RichTextBox rtbBody;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtTitle;
        public System.Windows.Forms.Button btnBrowse;
    }
}