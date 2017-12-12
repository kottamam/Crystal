namespace tv.Crystal.UI
{
    partial class frmAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccount));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.gbxTreeView = new System.Windows.Forms.GroupBox();
            this.tvwAccount = new System.Windows.Forms.TreeView();
            this.imlImages = new System.Windows.Forms.ImageList(this.components);
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.txtSearch = new tv.Crystal.UI.nTextBox(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblAccountCount = new System.Windows.Forms.Label();
            this.cboAccountGroup = new ComboTreeBox();
            this.gbxButtons = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.cboOpeningType = new tv.Crystal.UI.CustomControls.nCombobox(this.components);
            this.txtOpening = new tv.Crystal.UI.nTextBox(this.components);
            this.txtAccountName = new tv.Crystal.UI.nTextBox(this.components);
            this.gbxType = new System.Windows.Forms.GroupBox();
            this.radAccount = new System.Windows.Forms.RadioButton();
            this.radAccountGroup = new System.Windows.Forms.RadioButton();
            this.lblOpening = new System.Windows.Forms.Label();
            this.lblAccountGroup = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.tipAccount = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.gbxTreeView.SuspendLayout();
            this.gbxSearch.SuspendLayout();
            this.gbxButtons.SuspendLayout();
            this.gbxType.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.AutoScrollMinSize = new System.Drawing.Size(50, 0);
            this.splitContainer.Panel1.Controls.Add(this.gbxTreeView);
            this.splitContainer.Panel1.Controls.Add(this.gbxSearch);
            this.splitContainer.Panel1.Controls.Add(this.lblAccountCount);
            this.splitContainer.Panel1MinSize = 250;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.cboAccountGroup);
            this.splitContainer.Panel2.Controls.Add(this.gbxButtons);
            this.splitContainer.Panel2.Controls.Add(this.cboOpeningType);
            this.splitContainer.Panel2.Controls.Add(this.txtOpening);
            this.splitContainer.Panel2.Controls.Add(this.txtAccountName);
            this.splitContainer.Panel2.Controls.Add(this.gbxType);
            this.splitContainer.Panel2.Controls.Add(this.lblOpening);
            this.splitContainer.Panel2.Controls.Add(this.lblAccountGroup);
            this.splitContainer.Panel2.Controls.Add(this.lblAccountName);
            this.splitContainer.Panel2.Controls.Add(this.lblType);
            this.splitContainer.Panel2MinSize = 250;
            this.splitContainer.Size = new System.Drawing.Size(1184, 761);
            this.splitContainer.SplitterDistance = 350;
            this.splitContainer.SplitterWidth = 2;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.TabStop = false;
            // 
            // gbxTreeView
            // 
            this.gbxTreeView.Controls.Add(this.tvwAccount);
            this.gbxTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxTreeView.Location = new System.Drawing.Point(0, 20);
            this.gbxTreeView.Name = "gbxTreeView";
            this.gbxTreeView.Size = new System.Drawing.Size(348, 681);
            this.gbxTreeView.TabIndex = 0;
            this.gbxTreeView.TabStop = false;
            // 
            // tvwAccount
            // 
            this.tvwAccount.BackColor = System.Drawing.Color.White;
            this.tvwAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwAccount.ImageIndex = 0;
            this.tvwAccount.ImageList = this.imlImages;
            this.tvwAccount.Location = new System.Drawing.Point(3, 16);
            this.tvwAccount.Name = "tvwAccount";
            this.tvwAccount.SelectedImageIndex = 0;
            this.tvwAccount.Size = new System.Drawing.Size(342, 662);
            this.tvwAccount.TabIndex = 0;
            this.tipAccount.SetToolTip(this.tvwAccount, "Account List");
            this.tvwAccount.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwAccount_BeforeSelect);
            this.tvwAccount.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwAccount_AfterSelect);
            // 
            // imlImages
            // 
            this.imlImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlImages.ImageStream")));
            this.imlImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imlImages.Images.SetKeyName(0, "AccountMasterGroup.png");
            this.imlImages.Images.SetKeyName(1, "AccountGroup.png");
            this.imlImages.Images.SetKeyName(2, "AccountGroupOpen.png");
            this.imlImages.Images.SetKeyName(3, "Ledger.png");
            this.imlImages.Images.SetKeyName(4, "LedgerOpen.png");
            // 
            // gbxSearch
            // 
            this.gbxSearch.Controls.Add(this.txtSearch);
            this.gbxSearch.Controls.Add(this.btnSearch);
            this.gbxSearch.Controls.Add(this.lblSearch);
            this.gbxSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxSearch.Location = new System.Drawing.Point(0, 701);
            this.gbxSearch.Margin = new System.Windows.Forms.Padding(0);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Padding = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.gbxSearch.Size = new System.Drawing.Size(348, 58);
            this.gbxSearch.TabIndex = 1;
            this.gbxSearch.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(55, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(263, 20);
            this.txtSearch.TabIndex = 0;
            this.tipAccount.SetToolTip(this.txtSearch, "Search account here");
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(318, 16);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnSearch.Size = new System.Drawing.Size(27, 27);
            this.btnSearch.TabIndex = 1;
            this.tipAccount.SetToolTip(this.btnSearch, "Click to search account");
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSearch.Location = new System.Drawing.Point(3, 16);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(52, 27);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAccountCount
            // 
            this.lblAccountCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAccountCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAccountCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountCount.Location = new System.Drawing.Point(0, 0);
            this.lblAccountCount.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblAccountCount.Name = "lblAccountCount";
            this.lblAccountCount.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lblAccountCount.Size = new System.Drawing.Size(348, 20);
            this.lblAccountCount.TabIndex = 0;
            this.lblAccountCount.Text = "Accounts";
            this.lblAccountCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cboAccountGroup
            // 
            this.cboAccountGroup.DroppedDown = false;
            this.cboAccountGroup.Images = this.imlImages;
            this.cboAccountGroup.Location = new System.Drawing.Point(249, 257);
            this.cboAccountGroup.Name = "cboAccountGroup";
            this.cboAccountGroup.SelectedNode = null;
            this.cboAccountGroup.Size = new System.Drawing.Size(349, 20);
            this.cboAccountGroup.TabIndex = 2;
            // 
            // gbxButtons
            // 
            this.gbxButtons.Controls.Add(this.btnClose);
            this.gbxButtons.Controls.Add(this.btnDelete);
            this.gbxButtons.Controls.Add(this.btnModify);
            this.gbxButtons.Controls.Add(this.btnNew);
            this.gbxButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbxButtons.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxButtons.Location = new System.Drawing.Point(0, 701);
            this.gbxButtons.Name = "gbxButtons";
            this.gbxButtons.Size = new System.Drawing.Size(830, 58);
            this.gbxButtons.TabIndex = 5;
            this.gbxButtons.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(492, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Cl&ose";
            this.tipAccount.SetToolTip(this.btnClose, "Click here to close");
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(417, 17);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.tipAccount.SetToolTip(this.btnDelete, "Click here to delete account");
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnModify.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.Location = new System.Drawing.Point(342, 17);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 30);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "&Modify";
            this.tipAccount.SetToolTip(this.btnModify, "Click here to modify account");
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(267, 17);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 30);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "&New";
            this.tipAccount.SetToolTip(this.btnNew, "Click here to create new account");
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cboOpeningType
            // 
            this.cboOpeningType.BackColor = System.Drawing.Color.White;
            this.cboOpeningType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboOpeningType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOpeningType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOpeningType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboOpeningType.FormattingEnabled = true;
            this.cboOpeningType.Items.AddRange(new object[] {
            "Debit",
            "Credit"});
            this.cboOpeningType.Location = new System.Drawing.Point(368, 283);
            this.cboOpeningType.Name = "cboOpeningType";
            this.cboOpeningType.Size = new System.Drawing.Size(65, 22);
            this.cboOpeningType.TabIndex = 4;
            this.tipAccount.SetToolTip(this.cboOpeningType, "Opening is debit or credit.");
            // 
            // txtOpening
            // 
            this.txtOpening.BackColor = System.Drawing.Color.White;
            this.txtOpening.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpening.ContentType = tv.Crystal.UI.nTextBox.nType.Amount;
            this.txtOpening.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpening.Location = new System.Drawing.Point(249, 284);
            this.txtOpening.MaxLength = 12;
            this.txtOpening.Name = "txtOpening";
            this.txtOpening.Size = new System.Drawing.Size(118, 20);
            this.txtOpening.TabIndex = 3;
            this.txtOpening.Text = "0.00";
            this.txtOpening.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipAccount.SetToolTip(this.txtOpening, "Account opening value of the selected financial year");
            // 
            // txtAccountName
            // 
            this.txtAccountName.BackColor = System.Drawing.Color.White;
            this.txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(249, 230);
            this.txtAccountName.MaxLength = 50;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(349, 20);
            this.txtAccountName.TabIndex = 1;
            this.tipAccount.SetToolTip(this.txtAccountName, "Account ledger name");
            // 
            // gbxType
            // 
            this.gbxType.Controls.Add(this.radAccount);
            this.gbxType.Controls.Add(this.radAccountGroup);
            this.gbxType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxType.Location = new System.Drawing.Point(248, 170);
            this.gbxType.Name = "gbxType";
            this.gbxType.Size = new System.Drawing.Size(350, 49);
            this.gbxType.TabIndex = 0;
            this.gbxType.TabStop = false;
            // 
            // radAccount
            // 
            this.radAccount.AutoSize = true;
            this.radAccount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAccount.Location = new System.Drawing.Point(202, 20);
            this.radAccount.Name = "radAccount";
            this.radAccount.Size = new System.Drawing.Size(77, 18);
            this.radAccount.TabIndex = 1;
            this.radAccount.Text = "Account";
            this.tipAccount.SetToolTip(this.radAccount, "Click to create account ledger");
            this.radAccount.UseVisualStyleBackColor = true;
            this.radAccount.Click += new System.EventHandler(this.radAccount_Click);
            // 
            // radAccountGroup
            // 
            this.radAccountGroup.AutoSize = true;
            this.radAccountGroup.Checked = true;
            this.radAccountGroup.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAccountGroup.Location = new System.Drawing.Point(53, 20);
            this.radAccountGroup.Name = "radAccountGroup";
            this.radAccountGroup.Size = new System.Drawing.Size(121, 18);
            this.radAccountGroup.TabIndex = 0;
            this.radAccountGroup.TabStop = true;
            this.radAccountGroup.Text = "Account Group";
            this.tipAccount.SetToolTip(this.radAccountGroup, "Click to create account group");
            this.radAccountGroup.UseVisualStyleBackColor = true;
            this.radAccountGroup.Click += new System.EventHandler(this.radAccountGroup_Click);
            // 
            // lblOpening
            // 
            this.lblOpening.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOpening.Location = new System.Drawing.Point(183, 282);
            this.lblOpening.Name = "lblOpening";
            this.lblOpening.Size = new System.Drawing.Size(60, 20);
            this.lblOpening.TabIndex = 20;
            this.lblOpening.Text = "Opening:";
            this.lblOpening.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAccountGroup
            // 
            this.lblAccountGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAccountGroup.Location = new System.Drawing.Point(121, 258);
            this.lblAccountGroup.Name = "lblAccountGroup";
            this.lblAccountGroup.Size = new System.Drawing.Size(121, 15);
            this.lblAccountGroup.TabIndex = 20;
            this.lblAccountGroup.Text = "Account Parent:";
            this.lblAccountGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAccountName
            // 
            this.lblAccountName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAccountName.Location = new System.Drawing.Point(182, 231);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(60, 15);
            this.lblAccountName.TabIndex = 20;
            this.lblAccountName.Text = "Account:";
            this.lblAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblType
            // 
            this.lblType.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblType.Location = new System.Drawing.Point(182, 193);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(60, 15);
            this.lblType.TabIndex = 20;
            this.lblType.Text = "Type:";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAccount
            // 
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Verdana", 7.734375F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmAccount";
            this.Text = "Account";
            this.Load += new System.EventHandler(this.frmAccount_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccount_KeyDown);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.gbxTreeView.ResumeLayout(false);
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            this.gbxButtons.ResumeLayout(false);
            this.gbxType.ResumeLayout(false);
            this.gbxType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.GroupBox gbxTreeView;
        private System.Windows.Forms.GroupBox gbxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblAccountCount;
        private nTextBox txtSearch;
        private System.Windows.Forms.TreeView tvwAccount;
        private System.Windows.Forms.ToolTip tipAccount;
        private nTextBox txtAccountName;
        private System.Windows.Forms.GroupBox gbxType;
        private System.Windows.Forms.RadioButton radAccount;
        private System.Windows.Forms.RadioButton radAccountGroup;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label lblType;
        private CustomControls.nCombobox cboOpeningType;
        private nTextBox txtOpening;
        private System.Windows.Forms.Label lblOpening;
        private System.Windows.Forms.Label lblAccountGroup;
        private System.Windows.Forms.GroupBox gbxButtons;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnNew;
        private ComboTreeBox cboAccountGroup;
        private System.Windows.Forms.ImageList imlImages;
    }
}
