namespace tv.Crystal.UI
{
	partial class frmSalesVoucher
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesVoucher));
			this.tipSalesVoucher = new System.Windows.Forms.ToolTip(this.components);
			this.gbxEntry = new System.Windows.Forms.GroupBox();
			this.gbxCustomerDetails = new System.Windows.Forms.GroupBox();
			this.lblCollectionAmountValue = new System.Windows.Forms.Label();
			this.lblSelectedDueValue = new System.Windows.Forms.Label();
			this.lblCollectionAmount = new System.Windows.Forms.Label();
			this.lblSelectedDue = new System.Windows.Forms.Label();
			this.lblTotalDueValue = new System.Windows.Forms.Label();
			this.lblTotalDue = new System.Windows.Forms.Label();
			this.chkShowAll = new System.Windows.Forms.CheckBox();
			this.dgvSalesHistory = new tv.Crystal.UI.CustomControls.nDataGridView();
			this.lblCustomerFound = new System.Windows.Forms.Label();
			this.btnSearchCustomer = new System.Windows.Forms.Button();
			this.btnSearchVehicleNo = new System.Windows.Forms.Button();
			this.dtpSalesDate = new System.Windows.Forms.DateTimePicker();
			this.cboProduct = new tv.Crystal.UI.CustomControls.nCombobox(this.components);
			this.txtRate = new tv.Crystal.UI.nTextBox(this.components);
			this.txtReceivedAmount = new tv.Crystal.UI.nTextBox(this.components);
			this.txtDiscount = new tv.Crystal.UI.nTextBox(this.components);
			this.txtQty = new tv.Crystal.UI.nTextBox(this.components);
			this.txtCustomerName = new tv.Crystal.UI.nTextBox(this.components);
			this.lblCustomerName = new System.Windows.Forms.Label();
			this.txtVehicleNo = new tv.Crystal.UI.nTextBox(this.components);
			this.lblRate = new System.Windows.Forms.Label();
			this.lblPreviousDueValue = new System.Windows.Forms.Label();
			this.lblPreviousDue = new System.Windows.Forms.Label();
			this.lblTotalValue = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblExcessAmountValue = new System.Windows.Forms.Label();
			this.lblNetAmountValue = new System.Windows.Forms.Label();
			this.lblExcessAmount = new System.Windows.Forms.Label();
			this.lblReceivedAmount = new System.Windows.Forms.Label();
			this.lblNetAmount = new System.Windows.Forms.Label();
			this.lblDiscount = new System.Windows.Forms.Label();
			this.lblQty = new System.Windows.Forms.Label();
			this.lblSalesDate = new System.Windows.Forms.Label();
			this.lblProduct = new System.Windows.Forms.Label();
			this.lblVehicleNo = new System.Windows.Forms.Label();
			this.gbxControls = new System.Windows.Forms.GroupBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.gbxEntry.SuspendLayout();
			this.gbxCustomerDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSalesHistory)).BeginInit();
			this.gbxControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxEntry
			// 
			this.gbxEntry.Controls.Add(this.gbxCustomerDetails);
			this.gbxEntry.Controls.Add(this.btnSearchCustomer);
			this.gbxEntry.Controls.Add(this.btnSearchVehicleNo);
			this.gbxEntry.Controls.Add(this.dtpSalesDate);
			this.gbxEntry.Controls.Add(this.cboProduct);
			this.gbxEntry.Controls.Add(this.txtRate);
			this.gbxEntry.Controls.Add(this.txtReceivedAmount);
			this.gbxEntry.Controls.Add(this.txtDiscount);
			this.gbxEntry.Controls.Add(this.txtQty);
			this.gbxEntry.Controls.Add(this.txtCustomerName);
			this.gbxEntry.Controls.Add(this.lblCustomerName);
			this.gbxEntry.Controls.Add(this.txtVehicleNo);
			this.gbxEntry.Controls.Add(this.lblRate);
			this.gbxEntry.Controls.Add(this.lblPreviousDueValue);
			this.gbxEntry.Controls.Add(this.lblPreviousDue);
			this.gbxEntry.Controls.Add(this.lblTotalValue);
			this.gbxEntry.Controls.Add(this.lblTotal);
			this.gbxEntry.Controls.Add(this.lblExcessAmountValue);
			this.gbxEntry.Controls.Add(this.lblNetAmountValue);
			this.gbxEntry.Controls.Add(this.lblExcessAmount);
			this.gbxEntry.Controls.Add(this.lblReceivedAmount);
			this.gbxEntry.Controls.Add(this.lblNetAmount);
			this.gbxEntry.Controls.Add(this.lblDiscount);
			this.gbxEntry.Controls.Add(this.lblQty);
			this.gbxEntry.Controls.Add(this.lblSalesDate);
			this.gbxEntry.Controls.Add(this.lblProduct);
			this.gbxEntry.Controls.Add(this.lblVehicleNo);
			this.gbxEntry.Location = new System.Drawing.Point(3, -5);
			this.gbxEntry.Name = "gbxEntry";
			this.gbxEntry.Size = new System.Drawing.Size(1102, 492);
			this.gbxEntry.TabIndex = 0;
			this.gbxEntry.TabStop = false;
			// 
			// gbxCustomerDetails
			// 
			this.gbxCustomerDetails.Controls.Add(this.lblCollectionAmountValue);
			this.gbxCustomerDetails.Controls.Add(this.lblSelectedDueValue);
			this.gbxCustomerDetails.Controls.Add(this.lblCollectionAmount);
			this.gbxCustomerDetails.Controls.Add(this.lblSelectedDue);
			this.gbxCustomerDetails.Controls.Add(this.lblTotalDueValue);
			this.gbxCustomerDetails.Controls.Add(this.lblTotalDue);
			this.gbxCustomerDetails.Controls.Add(this.chkShowAll);
			this.gbxCustomerDetails.Controls.Add(this.dgvSalesHistory);
			this.gbxCustomerDetails.Controls.Add(this.lblCustomerFound);
			this.gbxCustomerDetails.Location = new System.Drawing.Point(608, 15);
			this.gbxCustomerDetails.Name = "gbxCustomerDetails";
			this.gbxCustomerDetails.Size = new System.Drawing.Size(459, 473);
			this.gbxCustomerDetails.TabIndex = 11;
			this.gbxCustomerDetails.TabStop = false;
			// 
			// lblCollectionAmountValue
			// 
			this.lblCollectionAmountValue.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCollectionAmountValue.ForeColor = System.Drawing.Color.White;
			this.lblCollectionAmountValue.Location = new System.Drawing.Point(258, 438);
			this.lblCollectionAmountValue.Name = "lblCollectionAmountValue";
			this.lblCollectionAmountValue.Size = new System.Drawing.Size(188, 32);
			this.lblCollectionAmountValue.TabIndex = 13;
			this.lblCollectionAmountValue.Text = "0.00";
			this.lblCollectionAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSelectedDueValue
			// 
			this.lblSelectedDueValue.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSelectedDueValue.ForeColor = System.Drawing.Color.White;
			this.lblSelectedDueValue.Location = new System.Drawing.Point(258, 404);
			this.lblSelectedDueValue.Name = "lblSelectedDueValue";
			this.lblSelectedDueValue.Size = new System.Drawing.Size(188, 32);
			this.lblSelectedDueValue.TabIndex = 13;
			this.lblSelectedDueValue.Text = "0.00";
			this.lblSelectedDueValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblCollectionAmount
			// 
			this.lblCollectionAmount.Location = new System.Drawing.Point(19, 442);
			this.lblCollectionAmount.Name = "lblCollectionAmount";
			this.lblCollectionAmount.Size = new System.Drawing.Size(233, 22);
			this.lblCollectionAmount.TabIndex = 14;
			this.lblCollectionAmount.Text = "Required Collection Amount:";
			this.lblCollectionAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSelectedDue
			// 
			this.lblSelectedDue.Location = new System.Drawing.Point(68, 408);
			this.lblSelectedDue.Name = "lblSelectedDue";
			this.lblSelectedDue.Size = new System.Drawing.Size(184, 22);
			this.lblSelectedDue.TabIndex = 14;
			this.lblSelectedDue.Text = "Selected Due Amount:";
			this.lblSelectedDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTotalDueValue
			// 
			this.lblTotalDueValue.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalDueValue.ForeColor = System.Drawing.Color.White;
			this.lblTotalDueValue.Location = new System.Drawing.Point(258, 369);
			this.lblTotalDueValue.Name = "lblTotalDueValue";
			this.lblTotalDueValue.Size = new System.Drawing.Size(188, 32);
			this.lblTotalDueValue.TabIndex = 13;
			this.lblTotalDueValue.Text = "0.00";
			this.lblTotalDueValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTotalDue
			// 
			this.lblTotalDue.Location = new System.Drawing.Point(68, 373);
			this.lblTotalDue.Name = "lblTotalDue";
			this.lblTotalDue.Size = new System.Drawing.Size(184, 22);
			this.lblTotalDue.TabIndex = 14;
			this.lblTotalDue.Text = "Total Due:";
			this.lblTotalDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkShowAll
			// 
			this.chkShowAll.AutoSize = true;
			this.chkShowAll.Location = new System.Drawing.Point(19, 65);
			this.chkShowAll.Name = "chkShowAll";
			this.chkShowAll.Size = new System.Drawing.Size(82, 20);
			this.chkShowAll.TabIndex = 12;
			this.chkShowAll.TabStop = false;
			this.chkShowAll.Text = "Show all";
			this.chkShowAll.UseVisualStyleBackColor = true;
			this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
			// 
			// dgvSalesHistory
			// 
			this.dgvSalesHistory.AllowUserToAddRows = false;
			this.dgvSalesHistory.AllowUserToDeleteRows = false;
			this.dgvSalesHistory.AllowUserToResizeRows = false;
			this.dgvSalesHistory.BackgroundColor = System.Drawing.Color.White;
			this.dgvSalesHistory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			this.dgvSalesHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgvSalesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSalesHistory.Location = new System.Drawing.Point(6, 90);
			this.dgvSalesHistory.MultiSelect = false;
			this.dgvSalesHistory.Name = "dgvSalesHistory";
			this.dgvSalesHistory.RowHeadersVisible = false;
			this.dgvSalesHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvSalesHistory.Size = new System.Drawing.Size(447, 273);
			this.dgvSalesHistory.TabIndex = 11;
			this.dgvSalesHistory.TabStop = false;
			this.dgvSalesHistory.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesHistory_CellEndEdit);
			this.dgvSalesHistory.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSalesHistory_CellMouseUp);
			// 
			// lblCustomerFound
			// 
			this.lblCustomerFound.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCustomerFound.ForeColor = System.Drawing.Color.Lime;
			this.lblCustomerFound.Location = new System.Drawing.Point(6, 19);
			this.lblCustomerFound.Name = "lblCustomerFound";
			this.lblCustomerFound.Size = new System.Drawing.Size(447, 39);
			this.lblCustomerFound.TabIndex = 10;
			this.lblCustomerFound.Text = "Customer Found";
			this.lblCustomerFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnSearchCustomer
			// 
			this.btnSearchCustomer.BackColor = System.Drawing.Color.Transparent;
			this.btnSearchCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchCustomer.BackgroundImage")));
			this.btnSearchCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnSearchCustomer.FlatAppearance.BorderSize = 0;
			this.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchCustomer.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.btnSearchCustomer.ForeColor = System.Drawing.Color.Black;
			this.btnSearchCustomer.Location = new System.Drawing.Point(560, 68);
			this.btnSearchCustomer.Margin = new System.Windows.Forms.Padding(0);
			this.btnSearchCustomer.Name = "btnSearchCustomer";
			this.btnSearchCustomer.Padding = new System.Windows.Forms.Padding(0, 0, 0, 36);
			this.btnSearchCustomer.Size = new System.Drawing.Size(23, 20);
			this.btnSearchCustomer.TabIndex = 3;
			this.btnSearchCustomer.TabStop = false;
			this.btnSearchCustomer.UseVisualStyleBackColor = false;
			this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
			// 
			// btnSearchVehicleNo
			// 
			this.btnSearchVehicleNo.BackColor = System.Drawing.Color.Transparent;
			this.btnSearchVehicleNo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearchVehicleNo.BackgroundImage")));
			this.btnSearchVehicleNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnSearchVehicleNo.FlatAppearance.BorderSize = 0;
			this.btnSearchVehicleNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchVehicleNo.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.btnSearchVehicleNo.ForeColor = System.Drawing.Color.Black;
			this.btnSearchVehicleNo.Location = new System.Drawing.Point(560, 30);
			this.btnSearchVehicleNo.Margin = new System.Windows.Forms.Padding(0);
			this.btnSearchVehicleNo.Name = "btnSearchVehicleNo";
			this.btnSearchVehicleNo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 36);
			this.btnSearchVehicleNo.Size = new System.Drawing.Size(23, 20);
			this.btnSearchVehicleNo.TabIndex = 1;
			this.btnSearchVehicleNo.TabStop = false;
			this.btnSearchVehicleNo.UseVisualStyleBackColor = false;
			this.btnSearchVehicleNo.Click += new System.EventHandler(this.btnSearchVehicleNo_Click);
			// 
			// dtpSalesDate
			// 
			this.dtpSalesDate.Location = new System.Drawing.Point(297, 156);
			this.dtpSalesDate.Name = "dtpSalesDate";
			this.dtpSalesDate.Size = new System.Drawing.Size(260, 23);
			this.dtpSalesDate.TabIndex = 5;
			// 
			// cboProduct
			// 
			this.cboProduct.BackColor = System.Drawing.Color.White;
			this.cboProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboProduct.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboProduct.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboProduct.FormattingEnabled = true;
			this.cboProduct.Location = new System.Drawing.Point(297, 112);
			this.cboProduct.Name = "cboProduct";
			this.cboProduct.Size = new System.Drawing.Size(260, 22);
			this.cboProduct.TabIndex = 4;
			this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
			// 
			// txtRate
			// 
			this.txtRate.BackColor = System.Drawing.Color.White;
			this.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRate.ContentType = tv.Crystal.UI.nTextBox.nType.Number;
			this.txtRate.Enabled = false;
			this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRate.Location = new System.Drawing.Point(463, 199);
			this.txtRate.Name = "txtRate";
			this.txtRate.RangeFrom = new System.DateTime(((long)(0)));
			this.txtRate.RangeTo = new System.DateTime(((long)(0)));
			this.txtRate.Size = new System.Drawing.Size(94, 22);
			this.txtRate.TabIndex = 7;
			// 
			// txtReceivedAmount
			// 
			this.txtReceivedAmount.BackColor = System.Drawing.Color.White;
			this.txtReceivedAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtReceivedAmount.ContentType = tv.Crystal.UI.nTextBox.nType.Amount;
			this.txtReceivedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtReceivedAmount.ForeColor = System.Drawing.Color.Red;
			this.txtReceivedAmount.Location = new System.Drawing.Point(297, 418);
			this.txtReceivedAmount.MaxLength = 10;
			this.txtReceivedAmount.Name = "txtReceivedAmount";
			this.txtReceivedAmount.RangeFrom = new System.DateTime(((long)(0)));
			this.txtReceivedAmount.RangeTo = new System.DateTime(((long)(0)));
			this.txtReceivedAmount.Size = new System.Drawing.Size(260, 22);
			this.txtReceivedAmount.TabIndex = 9;
			this.txtReceivedAmount.Text = "0.00";
			this.txtReceivedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtReceivedAmount.TextChanged += new System.EventHandler(this.txtReceivedAmount_TextChanged);
			// 
			// txtDiscount
			// 
			this.txtDiscount.BackColor = System.Drawing.Color.White;
			this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDiscount.ContentType = tv.Crystal.UI.nTextBox.nType.Amount;
			this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDiscount.Location = new System.Drawing.Point(297, 244);
			this.txtDiscount.MaxLength = 9;
			this.txtDiscount.Name = "txtDiscount";
			this.txtDiscount.RangeFrom = new System.DateTime(((long)(0)));
			this.txtDiscount.RangeTo = new System.DateTime(((long)(0)));
			this.txtDiscount.Size = new System.Drawing.Size(93, 22);
			this.txtDiscount.TabIndex = 8;
			this.txtDiscount.Text = "0.00";
			this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
			// 
			// txtQty
			// 
			this.txtQty.BackColor = System.Drawing.Color.White;
			this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtQty.ContentType = tv.Crystal.UI.nTextBox.nType.Number;
			this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQty.Location = new System.Drawing.Point(297, 200);
			this.txtQty.MaxLength = 6;
			this.txtQty.Name = "txtQty";
			this.txtQty.RangeFrom = new System.DateTime(((long)(0)));
			this.txtQty.RangeTo = new System.DateTime(((long)(0)));
			this.txtQty.Select_OnClick = true;
			this.txtQty.Size = new System.Drawing.Size(93, 22);
			this.txtQty.TabIndex = 6;
			this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.BackColor = System.Drawing.Color.White;
			this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCustomerName.Location = new System.Drawing.Point(297, 68);
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.RangeFrom = new System.DateTime(((long)(0)));
			this.txtCustomerName.RangeTo = new System.DateTime(((long)(0)));
			this.txtCustomerName.Size = new System.Drawing.Size(260, 22);
			this.txtCustomerName.TabIndex = 2;
			this.txtCustomerName.Leave += new System.EventHandler(this.txtCustomerName_Leave);
			// 
			// lblCustomerName
			// 
			this.lblCustomerName.Location = new System.Drawing.Point(107, 69);
			this.lblCustomerName.Name = "lblCustomerName";
			this.lblCustomerName.Size = new System.Drawing.Size(184, 22);
			this.lblCustomerName.TabIndex = 0;
			this.lblCustomerName.Text = "Customer Name:";
			this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVehicleNo
			// 
			this.txtVehicleNo.BackColor = System.Drawing.Color.White;
			this.txtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtVehicleNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtVehicleNo.Location = new System.Drawing.Point(297, 28);
			this.txtVehicleNo.Name = "txtVehicleNo";
			this.txtVehicleNo.RangeFrom = new System.DateTime(((long)(0)));
			this.txtVehicleNo.RangeTo = new System.DateTime(((long)(0)));
			this.txtVehicleNo.Size = new System.Drawing.Size(260, 22);
			this.txtVehicleNo.TabIndex = 0;
			this.txtVehicleNo.Leave += new System.EventHandler(this.txtVehicleNo_Leave);
			// 
			// lblRate
			// 
			this.lblRate.Location = new System.Drawing.Point(396, 199);
			this.lblRate.Name = "lblRate";
			this.lblRate.Size = new System.Drawing.Size(61, 22);
			this.lblRate.TabIndex = 0;
			this.lblRate.Text = "Rate:";
			this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPreviousDueValue
			// 
			this.lblPreviousDueValue.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPreviousDueValue.ForeColor = System.Drawing.Color.White;
			this.lblPreviousDueValue.Location = new System.Drawing.Point(297, 318);
			this.lblPreviousDueValue.Name = "lblPreviousDueValue";
			this.lblPreviousDueValue.Size = new System.Drawing.Size(188, 44);
			this.lblPreviousDueValue.TabIndex = 0;
			this.lblPreviousDueValue.Text = "0.00";
			this.lblPreviousDueValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPreviousDue
			// 
			this.lblPreviousDue.Location = new System.Drawing.Point(107, 328);
			this.lblPreviousDue.Name = "lblPreviousDue";
			this.lblPreviousDue.Size = new System.Drawing.Size(184, 22);
			this.lblPreviousDue.TabIndex = 0;
			this.lblPreviousDue.Text = "Previous Due:";
			this.lblPreviousDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTotalValue
			// 
			this.lblTotalValue.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalValue.ForeColor = System.Drawing.Color.White;
			this.lblTotalValue.Location = new System.Drawing.Point(297, 274);
			this.lblTotalValue.Name = "lblTotalValue";
			this.lblTotalValue.Size = new System.Drawing.Size(188, 44);
			this.lblTotalValue.TabIndex = 0;
			this.lblTotalValue.Text = "0.00";
			this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTotal
			// 
			this.lblTotal.Location = new System.Drawing.Point(107, 284);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(184, 22);
			this.lblTotal.TabIndex = 0;
			this.lblTotal.Text = "Total:";
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblExcessAmountValue
			// 
			this.lblExcessAmountValue.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblExcessAmountValue.ForeColor = System.Drawing.Color.White;
			this.lblExcessAmountValue.Location = new System.Drawing.Point(304, 443);
			this.lblExcessAmountValue.Name = "lblExcessAmountValue";
			this.lblExcessAmountValue.Size = new System.Drawing.Size(261, 44);
			this.lblExcessAmountValue.TabIndex = 0;
			this.lblExcessAmountValue.Text = "0.00";
			this.lblExcessAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblNetAmountValue
			// 
			this.lblNetAmountValue.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNetAmountValue.ForeColor = System.Drawing.Color.White;
			this.lblNetAmountValue.Location = new System.Drawing.Point(297, 362);
			this.lblNetAmountValue.Name = "lblNetAmountValue";
			this.lblNetAmountValue.Size = new System.Drawing.Size(188, 44);
			this.lblNetAmountValue.TabIndex = 0;
			this.lblNetAmountValue.Text = "0.00";
			this.lblNetAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblExcessAmount
			// 
			this.lblExcessAmount.Location = new System.Drawing.Point(107, 457);
			this.lblExcessAmount.Name = "lblExcessAmount";
			this.lblExcessAmount.Size = new System.Drawing.Size(184, 22);
			this.lblExcessAmount.TabIndex = 0;
			this.lblExcessAmount.Text = "Excess Amount:";
			this.lblExcessAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblReceivedAmount
			// 
			this.lblReceivedAmount.Location = new System.Drawing.Point(107, 418);
			this.lblReceivedAmount.Name = "lblReceivedAmount";
			this.lblReceivedAmount.Size = new System.Drawing.Size(184, 22);
			this.lblReceivedAmount.TabIndex = 0;
			this.lblReceivedAmount.Text = "Received Amount:";
			this.lblReceivedAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblNetAmount
			// 
			this.lblNetAmount.Location = new System.Drawing.Point(107, 372);
			this.lblNetAmount.Name = "lblNetAmount";
			this.lblNetAmount.Size = new System.Drawing.Size(184, 22);
			this.lblNetAmount.TabIndex = 0;
			this.lblNetAmount.Text = "Net Amount:";
			this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDiscount
			// 
			this.lblDiscount.Location = new System.Drawing.Point(107, 244);
			this.lblDiscount.Name = "lblDiscount";
			this.lblDiscount.Size = new System.Drawing.Size(184, 22);
			this.lblDiscount.TabIndex = 0;
			this.lblDiscount.Text = "Discount:";
			this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblQty
			// 
			this.lblQty.Location = new System.Drawing.Point(107, 200);
			this.lblQty.Name = "lblQty";
			this.lblQty.Size = new System.Drawing.Size(184, 22);
			this.lblQty.TabIndex = 0;
			this.lblQty.Text = "Quantity:";
			this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSalesDate
			// 
			this.lblSalesDate.Location = new System.Drawing.Point(107, 155);
			this.lblSalesDate.Name = "lblSalesDate";
			this.lblSalesDate.Size = new System.Drawing.Size(184, 22);
			this.lblSalesDate.TabIndex = 0;
			this.lblSalesDate.Text = "Sales Date:";
			this.lblSalesDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblProduct
			// 
			this.lblProduct.Location = new System.Drawing.Point(107, 110);
			this.lblProduct.Name = "lblProduct";
			this.lblProduct.Size = new System.Drawing.Size(184, 22);
			this.lblProduct.TabIndex = 0;
			this.lblProduct.Text = "Product:";
			this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblVehicleNo
			// 
			this.lblVehicleNo.Location = new System.Drawing.Point(107, 29);
			this.lblVehicleNo.Name = "lblVehicleNo";
			this.lblVehicleNo.Size = new System.Drawing.Size(184, 22);
			this.lblVehicleNo.TabIndex = 0;
			this.lblVehicleNo.Text = "Vehicle No:";
			this.lblVehicleNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gbxControls
			// 
			this.gbxControls.Controls.Add(this.btnClose);
			this.gbxControls.Controls.Add(this.btnClear);
			this.gbxControls.Controls.Add(this.btnSave);
			this.gbxControls.Location = new System.Drawing.Point(3, 480);
			this.gbxControls.Name = "gbxControls";
			this.gbxControls.Size = new System.Drawing.Size(1102, 87);
			this.gbxControls.TabIndex = 1;
			this.gbxControls.TabStop = false;
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(627, 23);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(136, 51);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Cl&ose";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnClear
			// 
			this.btnClear.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClear.Location = new System.Drawing.Point(485, 23);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(136, 51);
			this.btnClear.TabIndex = 1;
			this.btnClear.Text = "&Clear";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSave.Location = new System.Drawing.Point(343, 23);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(136, 51);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// frmSalesVoucher
			// 
			this.AutoResize = false;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1108, 570);
			this.Controls.Add(this.gbxEntry);
			this.Controls.Add(this.gbxControls);
			this.Name = "frmSalesVoucher";
			this.Text = "Sales Voucher";
			this.Load += new System.EventHandler(this.frmSalesVoucher_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSalesVoucher_KeyDown);
			this.gbxEntry.ResumeLayout(false);
			this.gbxEntry.PerformLayout();
			this.gbxCustomerDetails.ResumeLayout(false);
			this.gbxCustomerDetails.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSalesHistory)).EndInit();
			this.gbxControls.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolTip tipSalesVoucher;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.GroupBox gbxEntry;
		private System.Windows.Forms.DateTimePicker dtpSalesDate;
		private CustomControls.nCombobox cboProduct;
		private nTextBox txtCustomerName;
		private System.Windows.Forms.Label lblCustomerName;
		private nTextBox txtVehicleNo;
		private System.Windows.Forms.Label lblSalesDate;
		private System.Windows.Forms.Label lblProduct;
		private System.Windows.Forms.Label lblVehicleNo;
		private nTextBox txtRate;
		private nTextBox txtDiscount;
		private nTextBox txtQty;
		private System.Windows.Forms.Label lblRate;
		private System.Windows.Forms.Label lblDiscount;
		private System.Windows.Forms.Label lblQty;
		private nTextBox txtReceivedAmount;
		private System.Windows.Forms.Label lblPreviousDueValue;
		private System.Windows.Forms.Label lblPreviousDue;
		private System.Windows.Forms.Label lblTotalValue;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblNetAmountValue;
		private System.Windows.Forms.Label lblReceivedAmount;
		private System.Windows.Forms.Label lblNetAmount;
		private System.Windows.Forms.Button btnSearchCustomer;
		private System.Windows.Forms.Button btnSearchVehicleNo;
		private System.Windows.Forms.GroupBox gbxControls;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.GroupBox gbxCustomerDetails;
		private System.Windows.Forms.Label lblCustomerFound;
		private CustomControls.nDataGridView dgvSalesHistory;
		private System.Windows.Forms.CheckBox chkShowAll;
		private System.Windows.Forms.Label lblSelectedDueValue;
		private System.Windows.Forms.Label lblSelectedDue;
		private System.Windows.Forms.Label lblTotalDueValue;
		private System.Windows.Forms.Label lblTotalDue;
		private System.Windows.Forms.Label lblExcessAmountValue;
		private System.Windows.Forms.Label lblExcessAmount;
		private System.Windows.Forms.Label lblCollectionAmountValue;
		private System.Windows.Forms.Label lblCollectionAmount;
	}
}