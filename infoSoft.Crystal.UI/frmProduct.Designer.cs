namespace tv.Crystal.UI
{
	partial class frmProduct
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProduct));
			this.tipProduct = new System.Windows.Forms.ToolTip(this.components);
			this.txtProductName = new tv.Crystal.UI.nTextBox(this.components);
			this.btnClose = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.txtSearch = new tv.Crystal.UI.nTextBox(this.components);
			this.btnSearch = new System.Windows.Forms.Button();
			this.tvwProduct = new System.Windows.Forms.TreeView();
			this.imlImages = new System.Windows.Forms.ImageList(this.components);
			this.txtDescription = new tv.Crystal.UI.nTextBox(this.components);
			this.txtRate = new tv.Crystal.UI.nTextBox(this.components);
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblProductName = new System.Windows.Forms.Label();
			this.lblProductCount = new System.Windows.Forms.Label();
			this.lblSearch = new System.Windows.Forms.Label();
			this.gbxSearch = new System.Windows.Forms.GroupBox();
			this.gbxTreeView = new System.Windows.Forms.GroupBox();
			this.gbxButtons = new System.Windows.Forms.GroupBox();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.lblRate = new System.Windows.Forms.Label();
			this.gbxSearch.SuspendLayout();
			this.gbxTreeView.SuspendLayout();
			this.gbxButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtProductName
			// 
			this.txtProductName.AccessibleDescription = "dtProducts.Rows";
			this.txtProductName.BackColor = System.Drawing.Color.White;
			this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtProductName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProductName.Enabled = false;
			this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtProductName.Location = new System.Drawing.Point(180, 171);
			this.txtProductName.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.txtProductName.MaxLength = 50;
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.RangeFrom = new System.DateTime(((long)(0)));
			this.txtProductName.RangeTo = new System.DateTime(((long)(0)));
			this.txtProductName.Size = new System.Drawing.Size(561, 22);
			this.txtProductName.TabIndex = 0;
			this.tipProduct.SetToolTip(this.txtProductName, "Product Name");
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(400, 20);
			this.btnClose.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(147, 51);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Cl&ose";
			this.tipProduct.SetToolTip(this.btnClose, "Click here to close");
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnUpdate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdate.Location = new System.Drawing.Point(249, 20);
			this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(147, 51);
			this.btnUpdate.TabIndex = 0;
			this.btnUpdate.Text = "&Update";
			this.tipProduct.SetToolTip(this.btnUpdate, "Click here to create new account");
			this.btnUpdate.UseVisualStyleBackColor = false;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
			this.tipProduct.SetToolTip(this.txtSearch, "Search account here");
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
			this.tipProduct.SetToolTip(this.btnSearch, "Click to search account");
			this.btnSearch.UseVisualStyleBackColor = false;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// tvwProduct
			// 
			this.tvwProduct.BackColor = System.Drawing.Color.White;
			this.tvwProduct.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwProduct.ImageIndex = 0;
			this.tvwProduct.ImageList = this.imlImages;
			this.tvwProduct.Location = new System.Drawing.Point(3, 25);
			this.tvwProduct.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.tvwProduct.Name = "tvwProduct";
			this.tvwProduct.SelectedImageIndex = 0;
			this.tvwProduct.Size = new System.Drawing.Size(306, 416);
			this.tvwProduct.TabIndex = 0;
			this.tipProduct.SetToolTip(this.tvwProduct, "Account List");
			this.tvwProduct.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwProduct_BeforeSelect);
			this.tvwProduct.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwProduct_AfterSelect);
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
			// txtDescription
			// 
			this.txtDescription.AccessibleDescription = "dtProducts.Rows";
			this.txtDescription.BackColor = System.Drawing.Color.White;
			this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDescription.Enabled = false;
			this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDescription.Location = new System.Drawing.Point(180, 211);
			this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.txtDescription.MaxLength = 50;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.RangeFrom = new System.DateTime(((long)(0)));
			this.txtDescription.RangeTo = new System.DateTime(((long)(0)));
			this.txtDescription.Size = new System.Drawing.Size(561, 22);
			this.txtDescription.TabIndex = 1;
			this.tipProduct.SetToolTip(this.txtDescription, "Vehicle Number");
			// 
			// txtRate
			// 
			this.txtRate.BackColor = System.Drawing.Color.White;
			this.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRate.ContentType = tv.Crystal.UI.nTextBox.nType.Amount;
			this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRate.Location = new System.Drawing.Point(180, 251);
			this.txtRate.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
			this.txtRate.MaxLength = 8;
			this.txtRate.Name = "txtRate";
			this.txtRate.RangeFrom = new System.DateTime(((long)(0)));
			this.txtRate.RangeTo = new System.DateTime(((long)(0)));
			this.txtRate.Size = new System.Drawing.Size(233, 22);
			this.txtRate.TabIndex = 4;
			this.txtRate.Text = "0.00";
			this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tipProduct.SetToolTip(this.txtRate, "Address");
			// 
			// lblDescription
			// 
			this.lblDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblDescription.Location = new System.Drawing.Point(22, 197);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(144, 49);
			this.lblDescription.TabIndex = 20;
			this.lblDescription.Text = "Description:";
			this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblProductName
			// 
			this.lblProductName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblProductName.Location = new System.Drawing.Point(27, 157);
			this.lblProductName.Name = "lblProductName";
			this.lblProductName.Size = new System.Drawing.Size(140, 49);
			this.lblProductName.TabIndex = 20;
			this.lblProductName.Text = "Product Name:";
			this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblProductCount
			// 
			this.lblProductCount.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblProductCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblProductCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProductCount.Location = new System.Drawing.Point(0, 0);
			this.lblProductCount.Margin = new System.Windows.Forms.Padding(0, 36, 0, 0);
			this.lblProductCount.Name = "lblProductCount";
			this.lblProductCount.Padding = new System.Windows.Forms.Padding(0, 69, 0, 0);
			this.lblProductCount.Size = new System.Drawing.Size(312, 34);
			this.lblProductCount.TabIndex = 0;
			this.lblProductCount.Text = "Product";
			this.lblProductCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
			this.gbxTreeView.Controls.Add(this.tvwProduct);
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
			this.gbxButtons.Controls.Add(this.btnUpdate);
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
			this.splitContainer.Panel1.Controls.Add(this.lblProductCount);
			this.splitContainer.Panel1MinSize = 250;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.txtRate);
			this.splitContainer.Panel2.Controls.Add(this.lblDescription);
			this.splitContainer.Panel2.Controls.Add(this.lblRate);
			this.splitContainer.Panel2.Controls.Add(this.txtDescription);
			this.splitContainer.Panel2.Controls.Add(this.gbxButtons);
			this.splitContainer.Panel2.Controls.Add(this.txtProductName);
			this.splitContainer.Panel2.Controls.Add(this.lblProductName);
			this.splitContainer.Panel2MinSize = 250;
			this.splitContainer.Size = new System.Drawing.Size(1108, 570);
			this.splitContainer.SplitterDistance = 314;
			this.splitContainer.SplitterWidth = 2;
			this.splitContainer.TabIndex = 1;
			this.splitContainer.TabStop = false;
			// 
			// lblRate
			// 
			this.lblRate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblRate.Location = new System.Drawing.Point(48, 228);
			this.lblRate.Name = "lblRate";
			this.lblRate.Size = new System.Drawing.Size(119, 69);
			this.lblRate.TabIndex = 23;
			this.lblRate.Text = "Rate:";
			this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmProduct
			// 
			this.AutoResize = false;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1108, 570);
			this.Controls.Add(this.splitContainer);
			this.Name = "frmProduct";
			this.Text = "Product";
			this.Load += new System.EventHandler(this.frmProduct_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProduct_KeyDown);
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

		private System.Windows.Forms.ToolTip tipProduct;
		private nTextBox txtProductName;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnUpdate;
		private nTextBox txtSearch;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TreeView tvwProduct;
		private System.Windows.Forms.ImageList imlImages;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblProductName;
		private System.Windows.Forms.Label lblProductCount;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.GroupBox gbxSearch;
		private System.Windows.Forms.GroupBox gbxTreeView;
		private System.Windows.Forms.GroupBox gbxButtons;
		private System.Windows.Forms.SplitContainer splitContainer;
		private nTextBox txtDescription;
		private nTextBox txtRate;
		private System.Windows.Forms.Label lblRate;
	}
}