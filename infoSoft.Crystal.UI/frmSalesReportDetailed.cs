#region Copyright

// ©Copyright 2017, tv Software Private Limited,  All rights reserved.

#endregion Copyright

#region Code history

// Created On   : 29.12.2017
// Created By   : Noble
// Description  : Screen for sales detailed report
// -----------------------------------------//
// Modified By  : 
// Modified Date: 
// Description  : 

#endregion Code history

#region Using Directives

using System;
using System.Data;
using System.Windows.Forms;
using tv.Crystal.Business;
using tv.Crystal.Common.Models;
using tv.Crystal.Common.Constants;
using tv.Crystal.UI.CustomControls;
using System.Drawing;

#endregion Using Directives

namespace tv.Crystal.UI
{
	public partial class frmSalesReportDetailed : BaseForm
	{
		#region Constructor

		public frmSalesReportDetailed()
		{
			InitializeComponent();
		}

		#endregion

		#region Private Variables

		private enum GridCols
		{
			VoucherSalesId
			, SlNo
			, Date
			, Model
			, Customer
			, Qty
			, Rate
			, Discount
			, NetAmount
			, SettledAmount
			, ReceivedAmount
			, User
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// To clear all controls
		/// </summary>
		private void ClearFields()
		{
			try
			{
				DateTime today = GeneralBLL.GetServerDateAndTime().Date;
				dtpFromDate.MaxDate = today;
				dtpToDate.MaxDate = today;
				dtpFromDate.Value = today;
				dtpToDate.Value = today;
				cboModel.SelectedIndex = 0;
				cboUser.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// To bind product models
		/// </summary>
		private void BindProductModels()
		{
			try
			{
				cboModel.Items.Clear();
				nComboboxItem item = new nComboboxItem();
				item.Text = string.Empty;
				item.Value = 0;
				cboModel.Items.Add(item);
				DataTable dtModels = ProductBLL.GetProductModelList();
				if (dtModels.Rows.Count > 0)
				{
					foreach (DataRow drProduct in dtModels.Rows)
					{
						item = new nComboboxItem();
						item.Text = drProduct["ModelName"].ToString().Trim();
						item.Value = Convert.ToInt32(drProduct["ModelID"]);
						cboModel.Items.Add(item);
					}
					dtModels.Dispose();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Bind users
		/// </summary>
		private void BindUsers()
		{
			try
			{
				cboUser.Items.Clear();
				nComboboxItem item = new nComboboxItem();
				item.Text = string.Empty;
				item.Value = 0;
				cboUser.Items.Add(item);
				DataTable dtUsers = UserBLL.GetUserList();
				if (dtUsers.Rows.Count > 0)
				{
					foreach (DataRow drUser in dtUsers.Rows)
					{
						item = new nComboboxItem();
						item.Text = drUser["FullName"].ToString().Trim();
						item.Value = Convert.ToInt32(drUser["UserId"]);
						cboUser.Items.Add(item);
					}
					dtUsers.Dispose();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void SetGrid()
		{
			try
			{
				dgvReport.Rows.Clear();
				dgvReport.Columns.Clear();

				// Creating sales id column and adding into report grid
				DataGridViewCheckBoxColumn colVoucherSalesId = new DataGridViewCheckBoxColumn();
				colVoucherSalesId.Name = "colVoucherSalesId";
				colVoucherSalesId.HeaderText = "";
				colVoucherSalesId.Visible = false;

				nDataGridViewTextBoxColumn colSlNo = new nDataGridViewTextBoxColumn();
				colSlNo.Name = "colSlNo";
				colSlNo.HeaderText = "Sl";
				colSlNo.MinimumWidth = 20;
				colSlNo.FillWeight = 10;
				colSlNo.ReadOnly = true;
				colSlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colSlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colSlNo.SortMode = DataGridViewColumnSortMode.NotSortable;

				nDataGridViewTextBoxColumn colDate = new nDataGridViewTextBoxColumn();
				colDate.Name = "colVoucherDate";
				colDate.HeaderText = "Date";
				colDate.MinimumWidth = 80;
				colDate.FillWeight = 250;
				colDate.ReadOnly = true;
				colDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colDate.SortMode = DataGridViewColumnSortMode.NotSortable;

				nDataGridViewTextBoxColumn colModel = new nDataGridViewTextBoxColumn();
				colModel.Name = "colModel";
				colModel.HeaderText = "Model";
				colModel.MinimumWidth = 80;
				colModel.FillWeight = 250;
				colModel.ReadOnly = true;
				colModel.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colModel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colModel.SortMode = DataGridViewColumnSortMode.NotSortable;

				nDataGridViewTextBoxColumn colCustomer = new nDataGridViewTextBoxColumn();
				colCustomer.Name = "colCustomer";
				colCustomer.HeaderText = "Customer";
				colCustomer.MinimumWidth = 80;
				colCustomer.FillWeight = 250;
				colCustomer.ReadOnly = true;
				colCustomer.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colCustomer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colCustomer.SortMode = DataGridViewColumnSortMode.NotSortable;

				nDataGridViewTextBoxColumn colQty = new nDataGridViewTextBoxColumn();
				colQty.Name = "colQty";
				colQty.HeaderText = "Qty";
				colQty.MinimumWidth = 80;
				colQty.FillWeight = 250;
				colQty.ReadOnly = true;
				colQty.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				colQty.SortMode = DataGridViewColumnSortMode.NotSortable;

				nDataGridViewTextBoxColumn colRate = new nDataGridViewTextBoxColumn();
				colRate.Name = "colRate";
				colRate.HeaderText = "Rate";
				colRate.MinimumWidth = 80;
				colRate.FillWeight = 250;
				colRate.ReadOnly = true;
				colRate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colRate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				colRate.SortMode = DataGridViewColumnSortMode.NotSortable;

				nDataGridViewTextBoxColumn colDiscount = new nDataGridViewTextBoxColumn();
				colDiscount.Name = "colDiscount";
				colDiscount.HeaderText = "Discount";
				colDiscount.MinimumWidth = 80;
				colDiscount.FillWeight = 250;
				colDiscount.ReadOnly = true;
				colDiscount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				colDiscount.SortMode = DataGridViewColumnSortMode.NotSortable;

				nDataGridViewTextBoxColumn colNetAmount = new nDataGridViewTextBoxColumn();
				colNetAmount.Name = "colNetAmount";
				colNetAmount.HeaderText = "Net";
				colNetAmount.MinimumWidth = 80;
				colNetAmount.FillWeight = 250;
				colNetAmount.ReadOnly = true;
				colNetAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colNetAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				colNetAmount.SortMode = DataGridViewColumnSortMode.NotSortable;

				nDataGridViewTextBoxColumn colSettledAmount = new nDataGridViewTextBoxColumn();
				colSettledAmount.Name = "colSettledAmount";
				colSettledAmount.HeaderText = "Settled";
				colSettledAmount.MinimumWidth = 80;
				colSettledAmount.FillWeight = 250;
				colSettledAmount.ReadOnly = true;
				colSettledAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colSettledAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				colSettledAmount.SortMode = DataGridViewColumnSortMode.NotSortable;

				nDataGridViewTextBoxColumn colReceivedAmount = new nDataGridViewTextBoxColumn();
				colReceivedAmount.Name = "colReceivedAmount";
				colReceivedAmount.HeaderText = "Received";
				colReceivedAmount.MinimumWidth = 80;
				colReceivedAmount.FillWeight = 250;
				colReceivedAmount.ReadOnly = true;
				colReceivedAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colReceivedAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
				colReceivedAmount.SortMode = DataGridViewColumnSortMode.NotSortable;

				nDataGridViewTextBoxColumn colUser = new nDataGridViewTextBoxColumn();
				colUser.Name = "colUser";
				colUser.HeaderText = "User";
				colUser.MinimumWidth = 80;
				colUser.FillWeight = 250;
				colUser.ReadOnly = true;
				colUser.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colUser.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colUser.SortMode = DataGridViewColumnSortMode.NotSortable;

				dgvReport.Columns.AddRange(new DataGridViewColumn[] {
																		colVoucherSalesId
																		, colSlNo
																		, colDate
																		, colModel
																		, colCustomer
																		, colQty
																		, colRate
																		, colDiscount
																		, colNetAmount
																		, colSettledAmount
																		, colReceivedAmount
																		, colUser});
				dgvReport.Rows.Add();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion

		#region Form Events

		private void frmSalesReportDetailed_Load(object sender, EventArgs e)
		{
			try
			{
				BindProductModels();
				BindUsers();
				ClearFields();
				SetGrid();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("SalesReportDetailed_Load: " + ex.Message, EventLogType.Reports, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		#endregion

		#region Button Events

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				ClearFields();
				SetGrid();

			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("SalesReportDetailed_ClearButton: " + ex.Message, EventLogType.Reports, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void btnShow_Click(object sender, EventArgs e)
		{
			try
			{
				SetGrid();
				if(dtpFromDate.Value > dtpToDate.Value)
				{
					Messages.ShowInformationMessage("Invalid date. Cannot proceed.");
					dtpFromDate.Focus();
					return;
				}
				DataTable dtReport = SalesBLL.GetSalesVoucherReportDetailed(dtpFromDate.Value, dtpToDate.Value, 0, (cboModel.SelectedItem as nComboboxItem).Value, (cboUser.SelectedItem as nComboboxItem).Value);
				if(dtReport.Rows.Count > 0)
				{
					decimal discount = 0, net = 0, settled = 0, received = 0;
					int lastRowIndex = 0;
					foreach (DataRow row in dtReport.Rows)
					{
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.VoucherSalesId].Value = row["SalesID"].ToString();
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.SlNo].Value = lastRowIndex + 1;
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.Date].Value = row["SalesDate"].ToString();
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.Model].Value = row["ModelName"].ToString();
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.Customer].Value = row["Customer"].ToString();
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.Qty].Value = row["Quantity"].ToString();
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.Rate].Value = Convert.ToDecimal(row["Rate"]).ToString("F");
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.Discount].Value = Convert.ToDecimal(row["Discount"]).ToString("F");
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.NetAmount].Value = Convert.ToDecimal(row["NetAmount"]).ToString("F");
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.SettledAmount].Value = Convert.ToDecimal(row["SettledAmount"]).ToString("F");
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.ReceivedAmount].Value = Convert.ToDecimal(row["ReceivedAmount"]).ToString("F");
						dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.User].Value = row["CreatedBy"].ToString();
						lastRowIndex = dgvReport.RowCount;
						dgvReport.Rows.Add();
						discount += Convert.ToDecimal(row["Discount"]);
						net += Convert.ToDecimal(row["NetAmount"]);
						settled += Convert.ToDecimal(row["SettledAmount"]);
						received += Convert.ToDecimal(row["ReceivedAmount"]);
					}
					dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.Discount].Value = discount.ToString("F");
					dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.NetAmount].Value = net.ToString("F");
					dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.SettledAmount].Value = settled.ToString("F");
					dgvReport.Rows[lastRowIndex].Cells[(int)GridCols.ReceivedAmount].Value = received.ToString("F");
					dgvReport.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
				}
				else
				{
					Messages.ShowInformationMessage("No results found.");
					dtpFromDate.Focus();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("SalesReportDetailed_ShowButton: " + ex.Message, EventLogType.Reports, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		#endregion
	}
}
