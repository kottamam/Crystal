namespace tv.Crystal.UI
{
	partial class frmSalesReportDetailed
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
			this.tipSales = new System.Windows.Forms.ToolTip(this.components);
			this.cboUser = new tv.Crystal.UI.CustomControls.nCombobox(this.components);
			this.cboModel = new tv.Crystal.UI.CustomControls.nCombobox(this.components);
			this.dtpToDate = new System.Windows.Forms.DateTimePicker();
			this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
			this.btnShow = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.gbxInputControls = new System.Windows.Forms.GroupBox();
			this.lblUser = new System.Windows.Forms.Label();
			this.lblModel = new System.Windows.Forms.Label();
			this.lblToDate = new System.Windows.Forms.Label();
			this.lblFromDate = new System.Windows.Forms.Label();
			this.gbxReport = new System.Windows.Forms.GroupBox();
			this.dgvReport = new tv.Crystal.UI.CustomControls.nDataGridView();
			this.gbxInputControls.SuspendLayout();
			this.gbxReport.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
			this.SuspendLayout();
			// 
			// cboUser
			// 
			this.cboUser.BackColor = System.Drawing.Color.White;
			this.cboUser.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboUser.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboUser.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboUser.FormattingEnabled = true;
			this.cboUser.Location = new System.Drawing.Point(681, 24);
			this.cboUser.Name = "cboUser";
			this.cboUser.Size = new System.Drawing.Size(169, 22);
			this.cboUser.TabIndex = 3;
			this.tipSales.SetToolTip(this.cboUser, "Users");
			// 
			// cboModel
			// 
			this.cboModel.BackColor = System.Drawing.Color.White;
			this.cboModel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboModel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboModel.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cboModel.FormattingEnabled = true;
			this.cboModel.Location = new System.Drawing.Point(447, 24);
			this.cboModel.Name = "cboModel";
			this.cboModel.Size = new System.Drawing.Size(169, 22);
			this.cboModel.TabIndex = 3;
			this.tipSales.SetToolTip(this.cboModel, "Product models");
			// 
			// dtpToDate
			// 
			this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpToDate.Location = new System.Drawing.Point(242, 24);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(127, 23);
			this.dtpToDate.TabIndex = 0;
			this.tipSales.SetToolTip(this.dtpToDate, "To date");
			// 
			// dtpFromDate
			// 
			this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFromDate.Location = new System.Drawing.Point(62, 24);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(127, 23);
			this.dtpFromDate.TabIndex = 0;
			this.tipSales.SetToolTip(this.dtpFromDate, "From date");
			// 
			// btnShow
			// 
			this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnShow.Location = new System.Drawing.Point(876, 18);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new System.Drawing.Size(89, 36);
			this.btnShow.TabIndex = 4;
			this.btnShow.Text = "&Show";
			this.tipSales.SetToolTip(this.btnShow, "Click to show the details");
			this.btnShow.UseVisualStyleBackColor = true;
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// btnClear
			// 
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClear.Location = new System.Drawing.Point(971, 18);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(89, 36);
			this.btnClear.TabIndex = 4;
			this.btnClear.Text = "&Clear";
			this.tipSales.SetToolTip(this.btnClear, "Click to clear the details");
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// gbxInputControls
			// 
			this.gbxInputControls.Controls.Add(this.btnClear);
			this.gbxInputControls.Controls.Add(this.btnShow);
			this.gbxInputControls.Controls.Add(this.cboUser);
			this.gbxInputControls.Controls.Add(this.lblUser);
			this.gbxInputControls.Controls.Add(this.cboModel);
			this.gbxInputControls.Controls.Add(this.lblModel);
			this.gbxInputControls.Controls.Add(this.lblToDate);
			this.gbxInputControls.Controls.Add(this.lblFromDate);
			this.gbxInputControls.Controls.Add(this.dtpToDate);
			this.gbxInputControls.Controls.Add(this.dtpFromDate);
			this.gbxInputControls.Location = new System.Drawing.Point(2, -6);
			this.gbxInputControls.Name = "gbxInputControls";
			this.gbxInputControls.Size = new System.Drawing.Size(1104, 68);
			this.gbxInputControls.TabIndex = 0;
			this.gbxInputControls.TabStop = false;
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.Location = new System.Drawing.Point(631, 26);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(43, 16);
			this.lblUser.TabIndex = 2;
			this.lblUser.Text = "User:";
			// 
			// lblModel
			// 
			this.lblModel.AutoSize = true;
			this.lblModel.Location = new System.Drawing.Point(397, 26);
			this.lblModel.Name = "lblModel";
			this.lblModel.Size = new System.Drawing.Size(52, 16);
			this.lblModel.TabIndex = 2;
			this.lblModel.Text = "Model:";
			// 
			// lblToDate
			// 
			this.lblToDate.AutoSize = true;
			this.lblToDate.Location = new System.Drawing.Point(213, 26);
			this.lblToDate.Name = "lblToDate";
			this.lblToDate.Size = new System.Drawing.Size(30, 16);
			this.lblToDate.TabIndex = 1;
			this.lblToDate.Text = "To:";
			// 
			// lblFromDate
			// 
			this.lblFromDate.AutoSize = true;
			this.lblFromDate.Location = new System.Drawing.Point(17, 26);
			this.lblFromDate.Name = "lblFromDate";
			this.lblFromDate.Size = new System.Drawing.Size(46, 16);
			this.lblFromDate.TabIndex = 1;
			this.lblFromDate.Text = "From:";
			// 
			// gbxReport
			// 
			this.gbxReport.Controls.Add(this.dgvReport);
			this.gbxReport.Location = new System.Drawing.Point(2, 55);
			this.gbxReport.Name = "gbxReport";
			this.gbxReport.Size = new System.Drawing.Size(1104, 513);
			this.gbxReport.TabIndex = 1;
			this.gbxReport.TabStop = false;
			// 
			// dgvReport
			// 
			this.dgvReport.AllowUserToAddRows = false;
			this.dgvReport.AllowUserToDeleteRows = false;
			this.dgvReport.AllowUserToOrderColumns = true;
			this.dgvReport.AllowUserToResizeRows = false;
			this.dgvReport.BackgroundColor = System.Drawing.Color.White;
			this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReport.Location = new System.Drawing.Point(3, 11);
			this.dgvReport.MultiSelect = false;
			this.dgvReport.Name = "dgvReport";
			this.dgvReport.RowHeadersVisible = false;
			this.dgvReport.Size = new System.Drawing.Size(1097, 498);
			this.dgvReport.TabIndex = 0;
			// 
			// frmSalesReportDetailed
			// 
			this.AutoResize = false;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1108, 570);
			this.Controls.Add(this.gbxInputControls);
			this.Controls.Add(this.gbxReport);
			this.Name = "frmSalesReportDetailed";
			this.Text = "Sales Report - Detailed";
			this.Load += new System.EventHandler(this.frmSalesReportDetailed_Load);
			this.gbxInputControls.ResumeLayout(false);
			this.gbxInputControls.PerformLayout();
			this.gbxReport.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolTip tipSales;
		private System.Windows.Forms.GroupBox gbxInputControls;
		private System.Windows.Forms.Label lblToDate;
		private System.Windows.Forms.Label lblFromDate;
		private System.Windows.Forms.DateTimePicker dtpToDate;
		private System.Windows.Forms.DateTimePicker dtpFromDate;
		private CustomControls.nCombobox cboUser;
		private System.Windows.Forms.Label lblUser;
		private CustomControls.nCombobox cboModel;
		private System.Windows.Forms.Label lblModel;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.GroupBox gbxReport;
		private CustomControls.nDataGridView dgvReport;
	}
}