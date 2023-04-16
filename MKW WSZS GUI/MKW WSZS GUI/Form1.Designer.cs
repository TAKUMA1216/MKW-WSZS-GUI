namespace MKW_WSZS_GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.newBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.folderPath = new System.Windows.Forms.TextBox();
            this.folderBtn = new System.Windows.Forms.Button();
            this.pachBtn = new System.Windows.Forms.Button();
            this.packBtn = new System.Windows.Forms.Button();
            this.unpackBtn = new System.Windows.Forms.Button();
            this.version = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newBtn
            // 
            this.newBtn.Font = new System.Drawing.Font("Yu Gothic UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.newBtn.Location = new System.Drawing.Point(11, 12);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(175, 77);
            this.newBtn.TabIndex = 0;
            this.newBtn.Text = "NEW TRACK";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.folderPath);
            this.groupBox1.Controls.Add(this.folderBtn);
            this.groupBox1.Controls.Add(this.pachBtn);
            this.groupBox1.Controls.Add(this.packBtn);
            this.groupBox1.Controls.Add(this.unpackBtn);
            this.groupBox1.Location = new System.Drawing.Point(11, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 239);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Track Create";
            // 
            // folderPath
            // 
            this.folderPath.Enabled = false;
            this.folderPath.Location = new System.Drawing.Point(107, 195);
            this.folderPath.Name = "folderPath";
            this.folderPath.Size = new System.Drawing.Size(292, 27);
            this.folderPath.TabIndex = 5;
            this.folderPath.TextChanged += new System.EventHandler(this.folderPath_TextChanged);
            // 
            // folderBtn
            // 
            this.folderBtn.Location = new System.Drawing.Point(19, 195);
            this.folderBtn.Name = "folderBtn";
            this.folderBtn.Size = new System.Drawing.Size(81, 29);
            this.folderBtn.TabIndex = 2;
            this.folderBtn.Text = "FOLDER";
            this.folderBtn.UseVisualStyleBackColor = true;
            this.folderBtn.Click += new System.EventHandler(this.folderBtn_Click);
            // 
            // pachBtn
            // 
            this.pachBtn.Location = new System.Drawing.Point(17, 109);
            this.pachBtn.Name = "pachBtn";
            this.pachBtn.Size = new System.Drawing.Size(175, 77);
            this.pachBtn.TabIndex = 4;
            this.pachBtn.Text = "AUTO PACH MINIMAP";
            this.pachBtn.UseVisualStyleBackColor = true;
            this.pachBtn.Click += new System.EventHandler(this.pachBtn_Click);
            // 
            // packBtn
            // 
            this.packBtn.Location = new System.Drawing.Point(225, 27);
            this.packBtn.Name = "packBtn";
            this.packBtn.Size = new System.Drawing.Size(175, 77);
            this.packBtn.TabIndex = 3;
            this.packBtn.Text = "PACK SZS";
            this.packBtn.UseVisualStyleBackColor = true;
            this.packBtn.Click += new System.EventHandler(this.packBtn_Click);
            // 
            // unpackBtn
            // 
            this.unpackBtn.Location = new System.Drawing.Point(17, 27);
            this.unpackBtn.Name = "unpackBtn";
            this.unpackBtn.Size = new System.Drawing.Size(175, 77);
            this.unpackBtn.TabIndex = 2;
            this.unpackBtn.Text = "UN PACK SZS";
            this.unpackBtn.UseVisualStyleBackColor = true;
            this.unpackBtn.Click += new System.EventHandler(this.unpackBtn_Click);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(11, 427);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(246, 20);
            this.version.TabIndex = 2;
            this.version.Text = "Version:1.0.1 Takuma Blender Studio";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(11, 407);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(403, 20);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/TAKUMA1216/MKW-WSZS-GUI/releases";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 448);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.version);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.newBtn);
            this.MaximumSize = new System.Drawing.Size(448, 495);
            this.MinimumSize = new System.Drawing.Size(448, 495);
            this.Name = "Form1";
            this.Text = "MKW WSZS GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button newBtn;
        private GroupBox groupBox1;
        private TextBox folderPath;
        private Button folderBtn;
        private Button pachBtn;
        private Button packBtn;
        private Button unpackBtn;
        private Label version;
        private LinkLabel linkLabel1;
    }
}