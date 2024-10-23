namespace NRO_Forwarder
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNROToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox_Retro = new System.Windows.Forms.CheckBox();
            this.checkBox_Screeshot = new System.Windows.Forms.CheckBox();
            this.checkBox1_Video = new System.Windows.Forms.CheckBox();
            this.checkBox_profile = new System.Windows.Forms.CheckBox();
            this.button_Generate = new System.Windows.Forms.Button();
            this.textBox_TIT = new System.Windows.Forms.TextBox();
            this.textBox_AppTitle = new System.Windows.Forms.TextBox();
            this.textBox_publisher = new System.Windows.Forms.TextBox();
            this.textBox_nropath = new System.Windows.Forms.TextBox();
            this.textBox_Version = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_apptitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_nro = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_RomPath = new System.Windows.Forms.TextBox();
            this.comboBox_retro = new System.Windows.Forms.ComboBox();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_explore = new System.Windows.Forms.Button();
            this.button_open = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Left click for the menu or drag an image or NRO file here");
            this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            this.pictureBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragOver);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.saveImageToolStripMenuItem,
            this.openNROToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 70);
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.loadImageToolStripMenuItem.Text = "Load Image";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.loadImageToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveImageToolStripMenuItem.Text = "Save Image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // openNROToolStripMenuItem
            // 
            this.openNROToolStripMenuItem.Name = "openNROToolStripMenuItem";
            this.openNROToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openNROToolStripMenuItem.Text = "Load NRO";
            this.openNROToolStripMenuItem.Click += new System.EventHandler(this.openNROToolStripMenuItem_Click);
            // 
            // checkBox_Retro
            // 
            this.checkBox_Retro.AutoSize = true;
            this.checkBox_Retro.Location = new System.Drawing.Point(12, 274);
            this.checkBox_Retro.Name = "checkBox_Retro";
            this.checkBox_Retro.Size = new System.Drawing.Size(124, 17);
            this.checkBox_Retro.TabIndex = 1;
            this.checkBox_Retro.Text = "RetroArch Forwarder";
            this.toolTip1.SetToolTip(this.checkBox_Retro, "Check to make RetroArch forwarders");
            this.checkBox_Retro.UseVisualStyleBackColor = true;
            this.checkBox_Retro.CheckedChanged += new System.EventHandler(this.checkBox_Retro_CheckStateChanged);
            this.checkBox_Retro.CheckStateChanged += new System.EventHandler(this.checkBox_Retro_CheckStateChanged);
            // 
            // checkBox_Screeshot
            // 
            this.checkBox_Screeshot.AutoSize = true;
            this.checkBox_Screeshot.Location = new System.Drawing.Point(12, 290);
            this.checkBox_Screeshot.Name = "checkBox_Screeshot";
            this.checkBox_Screeshot.Size = new System.Drawing.Size(121, 17);
            this.checkBox_Screeshot.TabIndex = 2;
            this.checkBox_Screeshot.Text = "Enable Screenshots";
            this.toolTip1.SetToolTip(this.checkBox_Screeshot, "Check to enable homebrew screenshots");
            this.checkBox_Screeshot.UseVisualStyleBackColor = true;
            // 
            // checkBox1_Video
            // 
            this.checkBox1_Video.AutoSize = true;
            this.checkBox1_Video.Location = new System.Drawing.Point(144, 274);
            this.checkBox1_Video.Name = "checkBox1_Video";
            this.checkBox1_Video.Size = new System.Drawing.Size(129, 17);
            this.checkBox1_Video.TabIndex = 3;
            this.checkBox1_Video.Text = "Enable Video Capture";
            this.toolTip1.SetToolTip(this.checkBox1_Video, "Check to enable homebrew video captures");
            this.checkBox1_Video.UseVisualStyleBackColor = true;
            // 
            // checkBox_profile
            // 
            this.checkBox_profile.AutoSize = true;
            this.checkBox_profile.Location = new System.Drawing.Point(144, 290);
            this.checkBox_profile.Name = "checkBox_profile";
            this.checkBox_profile.Size = new System.Drawing.Size(91, 17);
            this.checkBox_profile.TabIndex = 4;
            this.checkBox_profile.Text = "Enable Profile";
            this.toolTip1.SetToolTip(this.checkBox_profile, "Check to enable profiles");
            this.checkBox_profile.UseVisualStyleBackColor = true;
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(189, 505);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(79, 23);
            this.button_Generate.TabIndex = 5;
            this.button_Generate.Text = "Generate NSP";
            this.toolTip1.SetToolTip(this.button_Generate, "Generate forwarder NSP");
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // textBox_TIT
            // 
            this.textBox_TIT.Location = new System.Drawing.Point(12, 323);
            this.textBox_TIT.Name = "textBox_TIT";
            this.textBox_TIT.Size = new System.Drawing.Size(124, 20);
            this.textBox_TIT.TabIndex = 7;
            this.toolTip1.SetToolTip(this.textBox_TIT, "Double click to generate a random value");
            this.textBox_TIT.TextChanged += new System.EventHandler(this.textBox_TIT_TextChanged);
            this.textBox_TIT.DoubleClick += new System.EventHandler(this.textBox_TIT_DoubleClick);
            this.textBox_TIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_TIT_KeyPress);
            // 
            // textBox_AppTitle
            // 
            this.textBox_AppTitle.Location = new System.Drawing.Point(12, 362);
            this.textBox_AppTitle.Name = "textBox_AppTitle";
            this.textBox_AppTitle.Size = new System.Drawing.Size(256, 20);
            this.textBox_AppTitle.TabIndex = 9;
            this.textBox_AppTitle.Text = "Forwarder";
            this.toolTip1.SetToolTip(this.textBox_AppTitle, "Enter the name of the homebrew app or game");
            // 
            // textBox_publisher
            // 
            this.textBox_publisher.Location = new System.Drawing.Point(12, 401);
            this.textBox_publisher.Name = "textBox_publisher";
            this.textBox_publisher.Size = new System.Drawing.Size(256, 20);
            this.textBox_publisher.TabIndex = 10;
            this.textBox_publisher.Text = "MrDude";
            this.toolTip1.SetToolTip(this.textBox_publisher, "Enter the name of the homebrew publisher");
            // 
            // textBox_nropath
            // 
            this.textBox_nropath.Location = new System.Drawing.Point(12, 440);
            this.textBox_nropath.Name = "textBox_nropath";
            this.textBox_nropath.Size = new System.Drawing.Size(256, 20);
            this.textBox_nropath.TabIndex = 11;
            this.textBox_nropath.Text = "/switch/tinwoo/tinwoo.nro";
            this.toolTip1.SetToolTip(this.textBox_nropath, "Enter the full path for the homebrew NRO");
            // 
            // textBox_Version
            // 
            this.textBox_Version.Location = new System.Drawing.Point(144, 323);
            this.textBox_Version.Name = "textBox_Version";
            this.textBox_Version.Size = new System.Drawing.Size(124, 20);
            this.textBox_Version.TabIndex = 12;
            this.textBox_Version.Text = "1.0.0";
            this.toolTip1.SetToolTip(this.textBox_Version, "Version limited to 10 digits");
            this.textBox_Version.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Version_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Version ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Title ID:";
            // 
            // label_apptitle
            // 
            this.label_apptitle.AutoSize = true;
            this.label_apptitle.Location = new System.Drawing.Point(9, 346);
            this.label_apptitle.Name = "label_apptitle";
            this.label_apptitle.Size = new System.Drawing.Size(52, 13);
            this.label_apptitle.TabIndex = 15;
            this.label_apptitle.Text = "App Title:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Publisher:";
            // 
            // label_nro
            // 
            this.label_nro.AutoSize = true;
            this.label_nro.Location = new System.Drawing.Point(9, 424);
            this.label_nro.Name = "label_nro";
            this.label_nro.Size = new System.Drawing.Size(59, 13);
            this.label_nro.TabIndex = 17;
            this.label_nro.Text = "NRO Path:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 463);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Rom Path:";
            // 
            // textBox_RomPath
            // 
            this.textBox_RomPath.Enabled = false;
            this.textBox_RomPath.Location = new System.Drawing.Point(12, 479);
            this.textBox_RomPath.Name = "textBox_RomPath";
            this.textBox_RomPath.Size = new System.Drawing.Size(256, 20);
            this.textBox_RomPath.TabIndex = 19;
            this.textBox_RomPath.Text = "/switch/uae4all2/conf/benefactor.conf";
            // 
            // comboBox_retro
            // 
            this.comboBox_retro.Enabled = false;
            this.comboBox_retro.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_retro.FormattingEnabled = true;
            this.comboBox_retro.Location = new System.Drawing.Point(189, 440);
            this.comboBox_retro.Name = "comboBox_retro";
            this.comboBox_retro.Size = new System.Drawing.Size(79, 20);
            this.comboBox_retro.TabIndex = 20;
            this.toolTip1.SetToolTip(this.comboBox_retro, "Select system");
            this.comboBox_retro.Visible = false;
            this.comboBox_retro.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox_Path
            // 
            this.textBox_Path.Enabled = false;
            this.textBox_Path.Location = new System.Drawing.Point(12, 440);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(168, 20);
            this.textBox_Path.TabIndex = 21;
            this.textBox_Path.Text = "/switch/tinwoo/tinwoo.nro";
            this.toolTip1.SetToolTip(this.textBox_Path, "Enter the full path for the RertoArch core");
            this.textBox_Path.Visible = false;
            // 
            // button_explore
            // 
            this.button_explore.Location = new System.Drawing.Point(101, 505);
            this.button_explore.Name = "button_explore";
            this.button_explore.Size = new System.Drawing.Size(79, 23);
            this.button_explore.TabIndex = 22;
            this.button_explore.Text = "Explore";
            this.toolTip1.SetToolTip(this.button_explore, "Explore program contents");
            this.button_explore.UseVisualStyleBackColor = true;
            this.button_explore.Click += new System.EventHandler(this.button_explore_Click);
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(12, 505);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(79, 23);
            this.button_open.TabIndex = 6;
            this.button_open.Text = "Alt Version";
            this.toolTip1.SetToolTip(this.button_open, "Extract NRO information");
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // MainMenu
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 538);
            this.Controls.Add(this.button_explore);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.comboBox_retro);
            this.Controls.Add(this.textBox_RomPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_nro);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_apptitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Version);
            this.Controls.Add(this.textBox_nropath);
            this.Controls.Add(this.textBox_publisher);
            this.Controls.Add(this.textBox_AppTitle);
            this.Controls.Add(this.textBox_TIT);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.button_Generate);
            this.Controls.Add(this.checkBox_profile);
            this.Controls.Add(this.checkBox1_Video);
            this.Controls.Add(this.checkBox_Screeshot);
            this.Controls.Add(this.checkBox_Retro);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NRO Forwarder";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox_Retro;
        private System.Windows.Forms.CheckBox checkBox_Screeshot;
        private System.Windows.Forms.CheckBox checkBox1_Video;
        private System.Windows.Forms.CheckBox checkBox_profile;
        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.TextBox textBox_TIT;
        private System.Windows.Forms.TextBox textBox_AppTitle;
        private System.Windows.Forms.TextBox textBox_publisher;
        private System.Windows.Forms.TextBox textBox_nropath;
        private System.Windows.Forms.TextBox textBox_Version;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_apptitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_nro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_RomPath;
        private System.Windows.Forms.ComboBox comboBox_retro;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNROToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.Button button_explore;
        private System.Windows.Forms.Button button_open;
    }
}

