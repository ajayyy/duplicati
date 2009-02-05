namespace Duplicati.GUI.Wizard_pages
{
    partial class MainPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Backup = new System.Windows.Forms.RadioButton();
            this.Remove = new System.Windows.Forms.RadioButton();
            this.Restore = new System.Windows.Forms.RadioButton();
            this.Edit = new System.Windows.Forms.RadioButton();
            this.CreateNew = new System.Windows.Forms.RadioButton();
            this.ShowAdvanced = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "What do you want to do?";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Backup);
            this.panel1.Controls.Add(this.Remove);
            this.panel1.Controls.Add(this.Restore);
            this.panel1.Controls.Add(this.Edit);
            this.panel1.Controls.Add(this.CreateNew);
            this.panel1.Location = new System.Drawing.Point(32, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 176);
            this.panel1.TabIndex = 1;
            // 
            // Backup
            // 
            this.Backup.AutoSize = true;
            this.Backup.Location = new System.Drawing.Point(0, 152);
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(150, 17);
            this.Backup.TabIndex = 4;
            this.Backup.TabStop = true;
            this.Backup.Text = "Run a backup immediately";
            this.Backup.UseVisualStyleBackColor = true;
            this.Backup.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // Remove
            // 
            this.Remove.AutoSize = true;
            this.Remove.Location = new System.Drawing.Point(0, 72);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(157, 17);
            this.Remove.TabIndex = 3;
            this.Remove.TabStop = true;
            this.Remove.Text = "Remove an existing backup";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // Restore
            // 
            this.Restore.AutoSize = true;
            this.Restore.Location = new System.Drawing.Point(0, 120);
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(154, 17);
            this.Restore.TabIndex = 2;
            this.Restore.TabStop = true;
            this.Restore.Text = "Restore files from a backup";
            this.Restore.UseVisualStyleBackColor = true;
            this.Restore.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // Edit
            // 
            this.Edit.AutoSize = true;
            this.Edit.Location = new System.Drawing.Point(0, 40);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(135, 17);
            this.Edit.TabIndex = 1;
            this.Edit.TabStop = true;
            this.Edit.Text = "Edit an existing backup";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // CreateNew
            // 
            this.CreateNew.AutoSize = true;
            this.CreateNew.Location = new System.Drawing.Point(0, 8);
            this.CreateNew.Name = "CreateNew";
            this.CreateNew.Size = new System.Drawing.Size(141, 17);
            this.CreateNew.TabIndex = 0;
            this.CreateNew.TabStop = true;
            this.CreateNew.Text = "Schedule a new backup";
            this.CreateNew.UseVisualStyleBackColor = true;
            this.CreateNew.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // ShowAdvanced
            // 
            this.ShowAdvanced.Location = new System.Drawing.Point(32, 216);
            this.ShowAdvanced.Name = "ShowAdvanced";
            this.ShowAdvanced.Size = new System.Drawing.Size(104, 24);
            this.ShowAdvanced.TabIndex = 2;
            this.ShowAdvanced.Text = "Advanced setup";
            this.ShowAdvanced.UseVisualStyleBackColor = true;
            this.ShowAdvanced.Click += new System.EventHandler(this.ShowAdvanced_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShowAdvanced);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(506, 242);
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton Restore;
        private System.Windows.Forms.RadioButton Edit;
        private System.Windows.Forms.RadioButton CreateNew;
        private System.Windows.Forms.Button ShowAdvanced;
        private System.Windows.Forms.RadioButton Backup;
        private System.Windows.Forms.RadioButton Remove;
    }
}
