namespace tv.Crystal.UI
{
    partial class frmParentForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParentForm));
			this.mnuMenu = new System.Windows.Forms.MenuStrip();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tipMenu = new System.Windows.Forms.ToolTip(this.components);
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMenu
			// 
			this.mnuMenu.Location = new System.Drawing.Point(0, 0);
			this.mnuMenu.Name = "mnuMenu";
			this.mnuMenu.Size = new System.Drawing.Size(632, 24);
			this.mnuMenu.TabIndex = 0;
			this.mnuMenu.Text = "MenuStrip";
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 431);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(632, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "StatusStrip";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel.Text = "Status";
			// 
			// frmParentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 453);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.mnuMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.mnuMenu;
			this.Name = "frmParentForm";
			this.Text = "Crystal";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmParentForm_FormClosing);
			this.Load += new System.EventHandler(this.frmParentForm_Load);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip tipMenu;
    }
}



