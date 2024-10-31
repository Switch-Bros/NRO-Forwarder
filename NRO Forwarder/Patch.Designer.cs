namespace NRO_Forwarder
{
    partial class Form_Patch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Patch));
            this.radioButton_nodebug = new System.Windows.Forms.RadioButton();
            this.radioButton_allowdebug = new System.Windows.Forms.RadioButton();
            this.radioButton_forceprod = new System.Windows.Forms.RadioButton();
            this.radioButton_forcedebug = new System.Windows.Forms.RadioButton();
            this.button_patch = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButton_nodebug
            // 
            this.radioButton_nodebug.AutoSize = true;
            this.radioButton_nodebug.Location = new System.Drawing.Point(7, 6);
            this.radioButton_nodebug.Name = "radioButton_nodebug";
            this.radioButton_nodebug.Size = new System.Drawing.Size(144, 17);
            this.radioButton_nodebug.TabIndex = 0;
            this.radioButton_nodebug.TabStop = true;
            this.radioButton_nodebug.Text = "Flag: No debugs enabled";
            this.radioButton_nodebug.UseVisualStyleBackColor = true;
            // 
            // radioButton_allowdebug
            // 
            this.radioButton_allowdebug.AutoSize = true;
            this.radioButton_allowdebug.Location = new System.Drawing.Point(7, 29);
            this.radioButton_allowdebug.Name = "radioButton_allowdebug";
            this.radioButton_allowdebug.Size = new System.Drawing.Size(153, 17);
            this.radioButton_allowdebug.TabIndex = 1;
            this.radioButton_allowdebug.TabStop = true;
            this.radioButton_allowdebug.Text = "Flag: Allow_debug enabled";
            this.radioButton_allowdebug.UseVisualStyleBackColor = true;
            // 
            // radioButton_forceprod
            // 
            this.radioButton_forceprod.AutoSize = true;
            this.radioButton_forceprod.Location = new System.Drawing.Point(7, 52);
            this.radioButton_forceprod.Name = "radioButton_forceprod";
            this.radioButton_forceprod.Size = new System.Drawing.Size(182, 17);
            this.radioButton_forceprod.TabIndex = 2;
            this.radioButton_forceprod.TabStop = true;
            this.radioButton_forceprod.Text = "Flag: Force_debug_prod enabled";
            this.radioButton_forceprod.UseVisualStyleBackColor = true;
            // 
            // radioButton_forcedebug
            // 
            this.radioButton_forcedebug.AutoSize = true;
            this.radioButton_forcedebug.Location = new System.Drawing.Point(7, 75);
            this.radioButton_forcedebug.Name = "radioButton_forcedebug";
            this.radioButton_forcedebug.Size = new System.Drawing.Size(155, 17);
            this.radioButton_forcedebug.TabIndex = 3;
            this.radioButton_forcedebug.TabStop = true;
            this.radioButton_forcedebug.Text = "Flag: Force_debug enabled";
            this.radioButton_forcedebug.UseVisualStyleBackColor = true;
            // 
            // button_patch
            // 
            this.button_patch.Location = new System.Drawing.Point(7, 98);
            this.button_patch.Name = "button_patch";
            this.button_patch.Size = new System.Drawing.Size(75, 23);
            this.button_patch.TabIndex = 4;
            this.button_patch.Text = "Patch";
            this.button_patch.UseVisualStyleBackColor = true;
            this.button_patch.Click += new System.EventHandler(this.button_patch_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(114, 98);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 23);
            this.button_exit.TabIndex = 5;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // Form_Patch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 129);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_patch);
            this.Controls.Add(this.radioButton_forcedebug);
            this.Controls.Add(this.radioButton_forceprod);
            this.Controls.Add(this.radioButton_allowdebug);
            this.Controls.Add(this.radioButton_nodebug);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Patch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "main.npdm Patcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_nodebug;
        private System.Windows.Forms.RadioButton radioButton_allowdebug;
        private System.Windows.Forms.RadioButton radioButton_forceprod;
        private System.Windows.Forms.RadioButton radioButton_forcedebug;
        private System.Windows.Forms.Button button_patch;
        private System.Windows.Forms.Button button_exit;
    }
}