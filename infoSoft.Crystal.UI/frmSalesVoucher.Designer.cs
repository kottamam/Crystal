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
			this.lblVehicleNo = new System.Windows.Forms.Label();
			this.txtVehicleNo = new tv.Crystal.UI.nTextBox(this.components);
			this.lblCustomerName = new System.Windows.Forms.Label();
			this.txtCustomerName = new tv.Crystal.UI.nTextBox(this.components);
			this.cboProduct = new tv.Crystal.UI.CustomControls.nCombobox(this.components);
			this.lblProduct = new System.Windows.Forms.Label();
			this.lblSalesDate = new System.Windows.Forms.Label();
			this.dtpSalesDate = new System.Windows.Forms.DateTimePicker();
			this.lblQty = new System.Windows.Forms.Label();
			this.txtQty = new tv.Crystal.UI.nTextBox(this.components);
			this.lblRate = new System.Windows.Forms.Label();
			this.txtRate = new tv.Crystal.UI.nTextBox(this.components);
			this.lblDiscount = new System.Windows.Forms.Label();
			this.txtDiscount = new tv.Crystal.UI.nTextBox(this.components);
			this.lblNetAmount = new System.Windows.Forms.Label();
			this.lblNetAmountValue = new System.Windows.Forms.Label();
			this.lblPreviousDue = new System.Windows.Forms.Label();
			this.lblPreviousDueValue = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblTotalValue = new System.Windows.Forms.Label();
			this.lblSettledAmount = new System.Windows.Forms.Label();
			this.txtSettledAmount = new tv.Crystal.UI.nTextBox(this.components);
			this.btnSearchVehicleNo = new System.Windows.Forms.Button();
			this.btnSearchCustomer = new System.Windows.Forms.Button();
			this.gbxControls = new System.Windows.Forms.GroupBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.gbxEntry.SuspendLayout();
			this.gbxControls.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxEntry
			// 
			this.gbxEntry.Controls.Add(this.btnSearchCustomer);
			this.gbxEntry.Controls.Add(this.btnSearchVehicleNo);
			this.gbxEntry.Controls.Add(this.dtpSalesDate);
			this.gbxEntry.Controls.Add(this.cboProduct);
			this.gbxEntry.Controls.Add(this.txtRate);
			this.gbxEntry.Controls.Add(this.txtSettledAmount);
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
			this.gbxEntry.Controls.Add(this.lblNetAmountValue);
			this.gbxEntry.Controls.Add(this.lblSettledAmount);
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
			// lblVehicleNo
			// 
			this.lblVehicleNo.Location = new System.Drawing.Point(238, 39);
			this.lblVehicleNo.Name = "lblVehicleNo";
			this.lblVehicleNo.Size = new System.Drawing.Size(184, 22);
			this.lblVehicleNo.TabIndex = 0;
			this.lblVehicleNo.Text = "Vehicle No:";
			this.lblVehicleNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVehicleNo
			// 
			this.txtVehicleNo.BackColor = System.Drawing.Color.White;
			this.txtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtVehicleNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtVehicleNo.Location = new System.Drawing.Point(428, 38);
			this.txtVehicleNo.Name = "txtVehicleNo";
			this.txtVehicleNo.RangeFrom = new System.DateTime(((long)(0)));
			this.txtVehicleNo.RangeTo = new System.DateTime(((long)(0)));
			this.txtVehicleNo.Size = new System.Drawing.Size(260, 22);
			this.txtVehicleNo.TabIndex = 0;
			// 
			// lblCustomerName
			// 
			this.lblCustomerName.Location = new System.Drawing.Point(238, 79);
			this.lblCustomerName.Name = "lblCustomerName";
			this.lblCustomerName.Size = new System.Drawing.Size(184, 22);
			this.lblCustomerName.TabIndex = 0;
			this.lblCustomerName.Text = "Customer Name:";
			this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.BackColor = System.Drawing.Color.White;
			this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCustomerName.Location = new System.Drawing.Point(428, 78);
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.RangeFrom = new System.DateTime(((long)(0)));
			this.txtCustomerName.RangeTo = new System.DateTime(((long)(0)));
			this.txtCustomerName.Size = new System.Drawing.Size(260, 22);
			this.txtCustomerName.TabIndex = 2;
			// 
			// cboProduct
			// 
			this.cboProduct.BackColor = System.Drawing.Color.White;
			this.cboProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboProduct.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboProduct.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboProduct.FormattingEnabled = true;
			this.cboProduct.Location = new System.Drawing.Point(428, 122);
			this.cboProduct.Name = "cboProduct";
			this.cboProduct.Size = new System.Drawing.Size(260, 22);
			this.cboProduct.TabIndex = 4;
			this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
			// 
			// lblProduct
			// 
			this.lblProduct.Location = new System.Drawing.Point(238, 120);
			this.lblProduct.Name = "lblProduct";
			this.lblProduct.Size = new System.Drawing.Size(184, 22);
			this.lblProduct.TabIndex = 0;
			this.lblProduct.Text = "Product:";
			this.lblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSalesDate
			// 
			this.lblSalesDate.Location = new System.Drawing.Point(238, 165);
			this.lblSalesDate.Name = "lblSalesDate";
			this.lblSalesDate.Size = new System.Drawing.Size(184, 22);
			this.lblSalesDate.TabIndex = 0;
			this.lblSalesDate.Text = "Sales Date:";
			this.lblSalesDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dtpSalesDate
			// 
			this.dtpSalesDate.Location = new System.Drawing.Point(428, 166);
			this.dtpSalesDate.Name = "dtpSalesDate";
			this.dtpSalesDate.Size = new System.Drawing.Size(260, 23);
			this.dtpSalesDate.TabIndex = 5;
			// 
			// lblQty
			// 
			this.lblQty.Location = new System.Drawing.Point(238, 213);
			this.lblQty.Name = "lblQty";
			this.lblQty.Size = new System.Drawing.Size(184, 22);
			this.lblQty.TabIndex = 0;
			this.lblQty.Text = "Quantity:";
			this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtQty
			// 
			this.txtQty.BackColor = System.Drawing.Color.White;
			this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtQty.ContentType = tv.Crystal.UI.nTextBox.nType.Number;
			this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQty.Location = new System.Drawing.Point(428, 213);
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
			// lblRate
			// 
			this.lblRate.Location = new System.Drawing.Point(527, 212);
			this.lblRate.Name = "lblRate";
			this.lblRate.Size = new System.Drawing.Size(61, 22);
			this.lblRate.TabIndex = 0;
			this.lblRate.Text = "Rate:";
			this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRate
			// 
			this.txtRate.BackColor = System.Drawing.Color.White;
			this.txtRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRate.ContentType = tv.Crystal.UI.nTextBox.nType.Number;
			this.txtRate.Enabled = false;
			this.txtRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRate.Location = new System.Drawing.Point(594, 212);
			this.txtRate.Name = "txtRate";
			this.txtRate.RangeFrom = new System.DateTime(((long)(0)));
			this.txtRate.RangeTo = new System.DateTime(((long)(0)));
			this.txtRate.Size = new System.Drawing.Size(94, 22);
			this.txtRate.TabIndex = 7;
			// 
			// lblDiscount
			// 
			this.lblDiscount.Location = new System.Drawing.Point(238, 257);
			this.lblDiscount.Name = "lblDiscount";
			this.lblDiscount.Size = new System.Drawing.Size(184, 22);
			this.lblDiscount.TabIndex = 0;
			this.lblDiscount.Text = "Discount:";
			this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDiscount
			// 
			this.txtDiscount.BackColor = System.Drawing.Color.White;
			this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDiscount.ContentType = tv.Crystal.UI.nTextBox.nType.Amount;
			this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDiscount.Location = new System.Drawing.Point(428, 257);
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
			// lblNetAmount
			// 
			this.lblNetAmount.Location = new System.Drawing.Point(238, 389);
			this.lblNetAmount.Name = "lblNetAmount";
			this.lblNetAmount.Size = new System.Drawing.Size(184, 22);
			this.lblNetAmount.TabIndex = 0;
			this.lblNetAmount.Text = "Net Amount:";
			this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblNetAmountValue
			// 
			this.lblNetAmountValue.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNetAmountValue.ForeColor = System.Drawing.Color.White;
			this.lblNetAmountValue.Location = new System.Drawing.Point(428, 379);
			this.lblNetAmountValue.Name = "lblNetAmountValue";
			this.lblNetAmountValue.Size = new System.Drawing.Size(188, 44);
			this.lblNetAmountValue.TabIndex = 0;
			this.lblNetAmountValue.Text = "0.00";
			this.lblNetAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPreviousDue
			// 
			this.lblPreviousDue.Location = new System.Drawing.Point(238, 345);
			this.lblPreviousDue.Name = "lblPreviousDue";
			this.lblPreviousDue.Size = new System.Drawing.Size(184, 22);
			this.lblPreviousDue.TabIndex = 0;
			this.lblPreviousDue.Text = "Previous Due:";
			this.lblPreviousDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPreviousDueValue
			// 
			this.lblPreviousDueValue.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPreviousDueValue.ForeColor = System.Drawing.Color.White;
			this.lblPreviousDueValue.Location = new System.Drawing.Point(428, 335);
			this.lblPreviousDueValue.Name = "lblPreviousDueValue";
			this.lblPreviousDueValue.Size = new System.Drawing.Size(188, 44);
			this.lblPreviousDueValue.TabIndex = 0;
			this.lblPreviousDueValue.Text = "0.00";
			this.lblPreviousDueValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTotal
			// 
			this.lblTotal.Location = new System.Drawing.Point(238, 301);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(184, 22);
			this.lblTotal.TabIndex = 0;
			this.lblTotal.Text = "Total:";
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTotalValue
			// 
			this.lblTotalValue.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalValue.ForeColor = System.Drawing.Color.White;
			this.lblTotalValue.Location = new System.Drawing.Point(428, 291);
			this.lblTotalValue.Name = "lblTotalValue";
			this.lblTotalValue.Size = new System.Drawing.Size(188, 44);
			this.lblTotalValue.TabIndex = 0;
			this.lblTotalValue.Text = "0.00";
			this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSettledAmount
			// 
			this.lblSettledAmount.Location = new System.Drawing.Point(238, 441);
			this.lblSettledAmount.Name = "lblSettledAmount";
			this.lblSettledAmount.Size = new System.Drawing.Size(184, 22);
			this.lblSettledAmount.TabIndex = 0;
			this.lblSettledAmount.Text = "Settled Amount:";
			this.lblSettledAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSettledAmount
			// 
			this.txtSettledAmount.BackColor = System.Drawing.Color.White;
			this.txtSettledAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSettledAmount.ContentType = tv.Crystal.UI.nTextBox.nType.Amount;
			this.txtSettledAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSettledAmount.ForeColor = System.Drawing.Color.Red;
			this.txtSettledAmount.Location = new System.Drawing.Point(428, 441);
			this.txtSettledAmount.MaxLength = 10;
			this.txtSettledAmount.Name = "txtSettledAmount";
			this.txtSettledAmount.RangeFrom = new System.DateTime(((long)(0)));
			this.txtSettledAmount.RangeTo = new System.DateTime(((long)(0)));
			this.txtSettledAmount.Size = new System.Drawing.Size(260, 22);
			this.txtSettledAmount.TabIndex = 9;
			this.txtSettledAmount.Text = "0.00";
			this.txtSettledAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
			this.btnSearchVehicleNo.Location = new System.Drawing.Point(691, 40);
			this.btnSearchVehicleNo.Margin = new System.Windows.Forms.Padding(0);
			this.btnSearchVehicleNo.Name = "btnSearchVehicleNo";
			this.btnSearchVehicleNo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 36);
			this.btnSearchVehicleNo.Size = new System.Drawing.Size(23, 20);
			this.btnSearchVehicleNo.TabIndex = 1;
			this.btnSearchVehicleNo.TabStop = false;
			this.btnSearchVehicleNo.UseVisualStyleBackColor = false;
			this.btnSearchVehicleNo.Click += new System.EventHandler(this.btnSearchVehicleNo_Click);
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
			this.btnSearchCustomer.Location = new System.Drawing.Point(691, 78);
			this.btnSearchCustomer.Margin = new System.Windows.Forms.Padding(0);
			this.btnSearchCustomer.Name = "btnSearchCustomer";
			this.btnSearchCustomer.Padding = new System.Windows.Forms.Padding(0, 0, 0, 36);
			this.btnSearchCustomer.Size = new System.Drawing.Size(23, 20);
			this.btnSearchCustomer.TabIndex = 3;
			this.btnSearchCustomer.TabStop = false;
			this.btnSearchCustomer.UseVisualStyleBackColor = false;
			this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
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
		private nTextBox txtSettledAmount;
		private System.Windows.Forms.Label lblPreviousDueValue;
		private System.Windows.Forms.Label lblPreviousDue;
		private System.Windows.Forms.Label lblTotalValue;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblNetAmountValue;
		private System.Windows.Forms.Label lblSettledAmount;
		private System.Windows.Forms.Label lblNetAmount;
		private System.Windows.Forms.Button btnSearchCustomer;
		private System.Windows.Forms.Button btnSearchVehicleNo;
		private System.Windows.Forms.GroupBox gbxControls;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnClear;
	}
}