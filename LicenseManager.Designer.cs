namespace RulePad
{
    partial class LicenseManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tscbLicenseList = new System.Windows.Forms.ToolStripComboBox();
            this.licensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.doneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbLicenseEditor = new System.Windows.Forms.RichTextBox();
            this.ofdOpenLicenseFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveLicenseFile = new System.Windows.Forms.SaveFileDialog();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbUseLicenses = new System.Windows.Forms.ToolStripComboBox();
            this.removeFromScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveUseListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licensesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(747, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbLicenseList,
            this.tscbUseLicenses});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(747, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tscbLicenseList
            // 
            this.tscbLicenseList.DropDownWidth = 250;
            this.tscbLicenseList.Name = "tscbLicenseList";
            this.tscbLicenseList.Size = new System.Drawing.Size(200, 25);
            // 
            // licensesToolStripMenuItem
            // 
            this.licensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveUseListToolStripMenuItem,
            this.toolStripMenuItem2,
            this.addToScriptsToolStripMenuItem,
            this.removeFromScriptsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.doneToolStripMenuItem});
            this.licensesToolStripMenuItem.Name = "licensesToolStripMenuItem";
            this.licensesToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.licensesToolStripMenuItem.Text = "Licenses";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // addToScriptsToolStripMenuItem
            // 
            this.addToScriptsToolStripMenuItem.Name = "addToScriptsToolStripMenuItem";
            this.addToScriptsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addToScriptsToolStripMenuItem.Text = "Add To Scripts";
            this.addToScriptsToolStripMenuItem.Click += new System.EventHandler(this.addToScriptsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
            // 
            // doneToolStripMenuItem
            // 
            this.doneToolStripMenuItem.Name = "doneToolStripMenuItem";
            this.doneToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.doneToolStripMenuItem.Text = "Done";
            this.doneToolStripMenuItem.Click += new System.EventHandler(this.doneToolStripMenuItem_Click);
            // 
            // rtbLicenseEditor
            // 
            this.rtbLicenseEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLicenseEditor.Location = new System.Drawing.Point(0, 49);
            this.rtbLicenseEditor.Name = "rtbLicenseEditor";
            this.rtbLicenseEditor.Size = new System.Drawing.Size(747, 372);
            this.rtbLicenseEditor.TabIndex = 2;
            this.rtbLicenseEditor.Text = "";
            // 
            // ofdOpenLicenseFile
            // 
            this.ofdOpenLicenseFile.FileName = "*.txt";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // tscbUseLicenses
            // 
            this.tscbUseLicenses.DropDownWidth = 250;
            this.tscbUseLicenses.Name = "tscbUseLicenses";
            this.tscbUseLicenses.Size = new System.Drawing.Size(200, 25);
            // 
            // removeFromScriptsToolStripMenuItem
            // 
            this.removeFromScriptsToolStripMenuItem.Name = "removeFromScriptsToolStripMenuItem";
            this.removeFromScriptsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.removeFromScriptsToolStripMenuItem.Text = "Remove From Scripts";
            this.removeFromScriptsToolStripMenuItem.Click += new System.EventHandler(this.removeFromScriptsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(183, 6);
            // 
            // saveUseListToolStripMenuItem
            // 
            this.saveUseListToolStripMenuItem.Name = "saveUseListToolStripMenuItem";
            this.saveUseListToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveUseListToolStripMenuItem.Text = "Save Use List";
            this.saveUseListToolStripMenuItem.Click += new System.EventHandler(this.saveUseListToolStripMenuItem_Click);
            // 
            // LicenseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 421);
            this.Controls.Add(this.rtbLicenseEditor);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LicenseManager";
            this.Text = "LicenseManager";
            this.Shown += new System.EventHandler(this.LicenseManager_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem licensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToScriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem doneToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tscbLicenseList;
        private System.Windows.Forms.RichTextBox rtbLicenseEditor;
        private System.Windows.Forms.OpenFileDialog ofdOpenLicenseFile;
        private System.Windows.Forms.SaveFileDialog sfdSaveLicenseFile;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromScriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tscbUseLicenses;
        private System.Windows.Forms.ToolStripMenuItem saveUseListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}