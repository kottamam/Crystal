namespace tv.Crystal.UI
{
	partial class frmCustomer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
			this.tipCustomer = new System.Windows.Forms.ToolTip(this.components);
			this.txtAddress1 = new tv.Crystal.UI.nTextBox(this.components);
			this.txtCustomerName = new tv.Crystal.UI.nTextBox(this.components);
			this.btnClose = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnModify = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.txtSearch = new tv.Crystal.UI.nTextBox(this.components);
			this.btnSearch = new System.Windows.Forms.Button();
			this.tvwCustomer = new System.Windows.Forms.TreeView();
			this.imlImages = new System.Windows.Forms.ImageList(this.components);
			this.txtVehicleNo = new tv.Crystal.UI.nTextBox(this.components);
			this.txtAddress2 = new tv.Crystal.UI.nTextBox(this.components);
			this.txtPhone = new tv.Crystal.UI.nTextBox(this.components);
			this.txtMobile = new tv.Crystal.UI.nTextBox(this.components);
			this.lblAddress = new System.Windows.Forms.Label();
			this.lblVehicleNo = new System.Windows.Forms.Label();
			this.lblCustomerName = new System.Windows.Forms.Label();
			this.lblCustomerCount = new System.Windows.Forms.Label();
			this.lblSearch = new System.Windows.Forms.Label();
			this.gbxSearch = new System.Windows.Forms.GroupBox();
			this.gbxTreeView = new System.Windows.Forms.GroupBox();
			this.gbxButtons = new System.Windows.Forms.GroupBox();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.lblMobile = new System.Windows.Forms.Label();
			this.lblPhone = new System.Windows.Forms.Label();
			this.gbxSearch.SuspendLayout();
			this.gbxTreeView.SuspendLayout();
			this.gbxButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtAddress1
			// 
			this.txtAddress1.BackColor = System.Drawing.Color.White;
			this.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAddress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAddress1.Location = new System.Drawing.Point(180, 251);
			this.txtAddress1.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.txtAddress1.MaxLength = 50;
			this.txtAddress1.Name = "txtAddress1";
			this.txtAddress1.RangeFrom = new System.DateTime(((long)(0)));
			this.txtAddress1.RangeTo = new System.DateTime(((long)(0)));
			this.txtAddress1.Size = new System.Drawing.Size(561, 22);
			this.txtAddress1.TabIndex = 2;
			this.tipCustomer.SetToolTip(this.txtAddress1, "Address");
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.AccessibleDescription = "dtCustomers.Rows";
			this.txtCustomerName.BackColor = System.Drawing.Color.White;
			this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCustomerName.Location = new System.Drawing.Point(180, 171);
			this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.txtCustomerName.MaxLength = 50;
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.RangeFrom = new System.DateTime(((long)(0)));
			this.txtCustomerName.RangeTo = new System.DateTime(((long)(0)));
			this.txtCustomerName.Size = new System.Drawing.Size(561, 22);
			this.txtCustomerName.TabIndex = 0;
			this.tipCustomer.SetToolTip(this.txtCustomerName, "Customer Name");
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(549, 20);
			this.btnClose.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(147, 51);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Cl&ose";
			this.tipCustomer.SetToolTip(this.btnClose, "Click here to close");
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.Location = new System.Drawing.Point(398, 20);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(147, 51);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "&Delete";
			this.tipCustomer.SetToolTip(this.btnDelete, "Click here to delete account");
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnModify
			// 
			this.btnModify.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnModify.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnModify.Location = new System.Drawing.Point(250, 20);
			this.btnModify.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(147, 51);
			this.btnModify.TabIndex = 1;
			this.btnModify.Text = "&Modify";
			this.tipCustomer.SetToolTip(this.btnModify, "Click here to modify account");
			this.btnModify.UseVisualStyleBackColor = false;
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnNew
			// 
			this.btnNew.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnNew.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNew.Location = new System.Drawing.Point(100, 20);
			this.btnNew.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(147, 51);
			this.btnNew.TabIndex = 0;
			this.btnNew.Text = "&New";
			this.tipCustomer.SetToolTip(this.btnNew, "Click here to create new account");
			this.btnNew.UseVisualStyleBackColor = false;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.BackColor = System.Drawing.Color.White;
			this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSearch.Location = new System.Drawing.Point(85, 34);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.RangeFrom = new System.DateTime(((long)(0)));
			this.txtSearch.RangeTo = new System.DateTime(((long)(0)));
			this.txtSearch.Size = new System.Drawing.Size(186, 20);
			this.txtSearch.TabIndex = 0;
			this.tipCustomer.SetToolTip(this.txtSearch, "Search account here");
			// 
			// btnSearch
			// 
			this.btnSearch.BackColor = System.Drawing.Color.Transparent;
			this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
			this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnSearch.FlatAppearance.BorderSize = 0;
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.btnSearch.ForeColor = System.Drawing.Color.Black;
			this.btnSearch.Location = new System.Drawing.Point(277, 34);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Padding = new System.Windows.Forms.Padding(0, 0, 0, 36);
			this.btnSearch.Size = new System.Drawing.Size(23, 20);
			this.btnSearch.TabIndex = 1;
			this.tipCustomer.SetToolTip(this.btnSearch, "Click to search account");
			this.btnSearch.UseVisualStyleBackColor = false;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// tvwCustomer
			// 
			this.tvwCustomer.BackColor = System.Drawing.Color.White;
			this.tvwCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwCustomer.ImageIndex = 0;
			this.tvwCustomer.ImageList = this.imlImages;
			this.tvwCustomer.Location = new System.Drawing.Point(3, 25);
			this.tvwCustomer.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.tvwCustomer.Name = "tvwCustomer";
			this.tvwCustomer.SelectedImageIndex = 0;
			this.tvwCustomer.Size = new System.Drawing.Size(306, 416);
			this.tvwCustomer.TabIndex = 0;
			this.tipCustomer.SetToolTip(this.tvwCustomer, "Account List");
			this.tvwCustomer.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwCustomer_BeforeSelect);
			this.tvwCustomer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCustomer_AfterSelect);
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
			// txtVehicleNo
			// 
			this.txtVehicleNo.AccessibleDescription = "dtCustomers.Rows";
			this.txtVehicleNo.BackColor = System.Drawing.Color.White;
			this.txtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtVehicleNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtVehicleNo.Location = new System.Drawing.Point(180, 211);
			this.txtVehicleNo.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.txtVehicleNo.MaxLength = 15;
			this.txtVehicleNo.Name = "txtVehicleNo";
			this.txtVehicleNo.RangeFrom = new System.DateTime(((long)(0)));
			this.txtVehicleNo.RangeTo = new System.DateTime(((long)(0)));
			this.txtVehicleNo.Size = new System.Drawing.Size(561, 22);
			this.txtVehicleNo.TabIndex = 1;
			this.tipCustomer.SetToolTip(this.txtVehicleNo, "Vehicle Number");
			// 
			// txtAddress2
			// 
			this.txtAddress2.BackColor = System.Drawing.Color.White;
			this.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAddress2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAddress2.Location = new System.Drawing.Point(180, 291);
			this.txtAddress2.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.txtAddress2.MaxLength = 50;
			this.txtAddress2.Name = "txtAddress2";
			this.txtAddress2.RangeFrom = new System.DateTime(((long)(0)));
			this.txtAddress2.RangeTo = new System.DateTime(((long)(0)));
			this.txtAddress2.Size = new System.Drawing.Size(561, 22);
			this.txtAddress2.TabIndex = 3;
			this.tipCustomer.SetToolTip(this.txtAddress2, "Address");
			// 
			// txtPhone
			// 
			this.txtPhone.BackColor = System.Drawing.Color.White;
			this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPhone.ContentType = tv.Crystal.UI.nTextBox.nType.Number;
			this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPhone.Location = new System.Drawing.Point(180, 331);
			this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.txtPhone.MaxLength = 12;
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.RangeFrom = new System.DateTime(((long)(0)));
			this.txtPhone.RangeTo = new System.DateTime(((long)(0)));
			this.txtPhone.Size = new System.Drawing.Size(233, 22);
			this.txtPhone.TabIndex = 4;
			this.tipCustomer.SetToolTip(this.txtPhone, "Address");
			// 
			// txtMobile
			// 
			this.txtMobile.BackColor = System.Drawing.Color.White;
			this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMobile.ContentType = tv.Crystal.UI.nTextBox.nType.Number;
			this.txtMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMobile.Location = new System.Drawing.Point(508, 332);
			this.txtMobile.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.txtMobile.MaxLength = 10;
			this.txtMobile.Name = "txtMobile";
			this.txtMobile.RangeFrom = new System.DateTime(((long)(0)));
			this.txtMobile.RangeTo = new System.DateTime(((long)(0)));
			this.txtMobile.Size = new System.Drawing.Size(233, 22);
			this.txtMobile.TabIndex = 5;
			this.tipCustomer.SetToolTip(this.txtMobile, "Address");
			// 
			// lblAddress
			// 
			this.lblAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblAddress.Location = new System.Drawing.Point(48, 229);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(119, 69);
			this.lblAddress.TabIndex = 20;
			this.lblAddress.Text = "Address:";
			this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblVehicleNo
			// 
			this.lblVehicleNo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblVehicleNo.Location = new System.Drawing.Point(22, 197);
			this.lblVehicleNo.Name = "lblVehicleNo";
			this.lblVehicleNo.Size = new System.Drawing.Size(144, 49);
			this.lblVehicleNo.TabIndex = 20;
			this.lblVehicleNo.Text = "Vehicle No:";
			this.lblVehicleNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblCustomerName
			// 
			this.lblCustomerName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblCustomerName.Location = new System.Drawing.Point(27, 157);
			this.lblCustomerName.Name = "lblCustomerName";
			this.lblCustomerName.Size = new System.Drawing.Size(140, 49);
			this.lblCustomerName.TabIndex = 20;
			this.lblCustomerName.Text = "Customer Name:";
			this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblCustomerCount
			// 
			this.lblCustomerCount.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblCustomerCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblCustomerCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCustomerCount.Location = new System.Drawing.Point(0, 0);
			this.lblCustomerCount.Margin = new System.Windows.Forms.Padding(0, 36, 0, 0);
			this.lblCustomerCount.Name = "lblCustomerCount";
			this.lblCustomerCount.Padding = new System.Windows.Forms.Padding(0, 69, 0, 0);
			this.lblCustomerCount.Size = new System.Drawing.Size(312, 34);
			this.lblCustomerCount.TabIndex = 0;
			this.lblCustomerCount.Text = "Customer";
			this.lblCustomerCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lblSearch
			// 
			this.lblSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblSearch.Location = new System.Drawing.Point(10, 27);
			this.lblSearch.Margin = new System.Windows.Forms.Padding(0);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(77, 34);
			this.lblSearch.TabIndex = 0;
			this.lblSearch.Text = "Search:";
			this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gbxSearch
			// 
			this.gbxSearch.Controls.Add(this.lblSearch);
			this.gbxSearch.Controls.Add(this.txtSearch);
			this.gbxSearch.Controls.Add(this.btnSearch);
			this.gbxSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.gbxSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbxSearch.Location = new System.Drawing.Point(0, 484);
			this.gbxSearch.Margin = new System.Windows.Forms.Padding(0);
			this.gbxSearch.Name = "gbxSearch";
			this.gbxSearch.Padding = new System.Windows.Forms.Padding(3, 9, 3, 49);
			this.gbxSearch.Size = new System.Drawing.Size(312, 84);
			this.gbxSearch.TabIndex = 2;
			this.gbxSearch.TabStop = false;
			// 
			// gbxTreeView
			// 
			this.gbxTreeView.Controls.Add(this.tvwCustomer);
			this.gbxTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbxTreeView.Location = new System.Drawing.Point(0, 34);
			this.gbxTreeView.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.gbxTreeView.Name = "gbxTreeView";
			this.gbxTreeView.Padding = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.gbxTreeView.Size = new System.Drawing.Size(312, 450);
			this.gbxTreeView.TabIndex = 1;
			this.gbxTreeView.TabStop = false;
			// 
			// gbxButtons
			// 
			this.gbxButtons.Controls.Add(this.btnClose);
			this.gbxButtons.Controls.Add(this.btnDelete);
			this.gbxButtons.Controls.Add(this.btnModify);
			this.gbxButtons.Controls.Add(this.btnNew);
			this.gbxButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.gbxButtons.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbxButtons.Location = new System.Drawing.Point(0, 485);
			this.gbxButtons.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.gbxButtons.Name = "gbxButtons";
			this.gbxButtons.Padding = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.gbxButtons.Size = new System.Drawing.Size(790, 83);
			this.gbxButtons.TabIndex = 6;
			this.gbxButtons.TabStop = false;
			// 
			// splitContainer
			// 
			this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.AutoScroll = true;
			this.splitContainer.Panel1.AutoScrollMinSize = new System.Drawing.Size(50, 0);
			this.splitContainer.Panel1.Controls.Add(this.gbxTreeView);
			this.splitContainer.Panel1.Controls.Add(this.gbxSearch);
			this.splitContainer.Panel1.Controls.Add(this.lblCustomerCount);
			this.splitContainer.Panel1MinSize = 250;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.txtPhone);
			this.splitContainer.Panel2.Controls.Add(this.txtAddress2);
			this.splitContainer.Panel2.Controls.Add(this.lblVehicleNo);
			this.splitContainer.Panel2.Controls.Add(this.txtMobile);
			this.splitContainer.Panel2.Controls.Add(this.lblMobile);
			this.splitContainer.Panel2.Controls.Add(this.lblPhone);
			this.splitContainer.Panel2.Controls.Add(this.txtVehicleNo);
			this.splitContainer.Panel2.Controls.Add(this.gbxButtons);
			this.splitContainer.Panel2.Controls.Add(this.txtAddress1);
			this.splitContainer.Panel2.Controls.Add(this.txtCustomerName);
			this.splitContainer.Panel2.Controls.Add(this.lblAddress);
			this.splitContainer.Panel2.Controls.Add(this.lblCustomerName);
			this.splitContainer.Panel2MinSize = 250;
			this.splitContainer.Size = new System.Drawing.Size(1108, 570);
			this.splitContainer.SplitterDistance = 314;
			this.splitContainer.SplitterWidth = 2;
			this.splitContainer.TabIndex = 1;
			this.splitContainer.TabStop = false;
			// 
			// lblMobile
			// 
			this.lblMobile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblMobile.Location = new System.Drawing.Point(377, 311);
			this.lblMobile.Name = "lblMobile";
			this.lblMobile.Size = new System.Drawing.Size(119, 69);
			this.lblMobile.TabIndex = 25;
			this.lblMobile.Text = "Mobile:";
			this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPhone
			// 
			this.lblPhone.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblPhone.Location = new System.Drawing.Point(48, 308);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(119, 69);
			this.lblPhone.TabIndex = 23;
			this.lblPhone.Text = "Phone:";
			this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmCustomer
			// 
			this.AutoResize = false;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1108, 570);
			this.Controls.Add(this.splitContainer);
			this.Name = "frmCustomer";
			this.Text = "Customer";
			this.Load += new System.EventHandler(this.frmCustomer_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCustomer_KeyDown);
			this.gbxSearch.ResumeLayout(false);
			this.gbxSearch.PerformLayout();
			this.gbxTreeView.ResumeLayout(false);
			this.gbxButtons.ResumeLayout(false);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolTip tipCustomer;
		private nTextBox txtAddress1;
		private nTextBox txtCustomerName;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnModify;
		private System.Windows.Forms.Button btnNew;
		private nTextBox txtSearch;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TreeView tvwCustomer;
		private System.Windows.Forms.ImageList imlImages;
		private System.Windows.Forms.Label lblAddress;
		private System.Windows.Forms.Label lblVehicleNo;
		private System.Windows.Forms.Label lblCustomerName;
		private System.Windows.Forms.Label lblCustomerCount;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.GroupBox gbxSearch;
		private System.Windows.Forms.GroupBox gbxTreeView;
		private System.Windows.Forms.GroupBox gbxButtons;
		private System.Windows.Forms.SplitContainer splitContainer;
		private nTextBox txtVehicleNo;
		private nTextBox txtMobile;
		private System.Windows.Forms.Label lblMobile;
		private nTextBox txtPhone;
		private System.Windows.Forms.Label lblPhone;
		private nTextBox txtAddress2;
	}
}