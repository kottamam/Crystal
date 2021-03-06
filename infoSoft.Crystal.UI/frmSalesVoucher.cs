﻿#region Copyright

// ©Copyright 2017, tv Software Private Limited,  All rights reserved.

#endregion Copyright

#region Code history

// Created On   : 25.11.2017
// Created By   : Noble
// Description  : Screen for create Product
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
	public partial class frmSalesVoucher : BaseForm
	{
		#region Constructor

		public frmSalesVoucher()
		{
			InitializeComponent();
		}

		#endregion Constructor

		#region Enum

		private enum GridColsSalesVoucherHistory
		{
			Select,
			SalesId,
			Date,
			Model,
			Amount,
			Settled,
			Pending
		}

		#endregion

		#region Form Events

		private void frmSalesVoucher_Load(object sender, EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				BindProducts();
				ClearFields();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("SalesVoucher_Load: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private void frmSalesVoucher_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					switch (this.ActiveControl.Name)
					{
						case "txtVehicleNo":
							if (txtVehicleNo.Text.Trim().Length > 0)
							{
								//btnSearchVehicleNo.PerformClick();
								cboProduct.Focus();
							}
							else
							{
								txtCustomerName.Focus();
							}
							break;
						case "txtCustomerName":
							if (txtCustomerName.Text.Trim().Length > 0)
							{
								btnSearchCustomer.PerformClick();
							}
							cboProduct.Focus();
							break;
						case "txtRefNo":
							if(txtRefNo.Text.Length > 0)
							{
								FillSalesDetailsUsingRefNo();
							}
							break;
						default:
							SelectNextControl(this.ActiveControl, true, true, true, true);
							break;
					}
				}
				else if (e.KeyCode == Keys.Escape && Messages.ShowConfirmation("Are you sure to close this screen?", MessageBoxDefaultButton.Button2))
				{
					Close();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("SalesVoucher_KeyDown: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		#endregion

		#region Private Methods

		private void BindProducts()
		{
			try
			{
				cboProduct.Items.Clear();
				DataTable dtProducts = ProductBLL.GetProductModelList();
				if (dtProducts.Rows.Count > 0)
				{
					foreach (DataRow drProduct in dtProducts.Rows)
					{
						nComboboxItem item = new nComboboxItem();
						item.Text = drProduct["ModelName"].ToString().Trim();
						item.Value = Convert.ToInt32(drProduct["ModelID"]);
						cboProduct.Items.Add(item);
					}
					dtProducts.Dispose();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void ClearFields()
		{
			try
			{
				txtVehicleNo.Text = string.Empty;
				txtVehicleNo.Tag = 0;
				txtCustomerName.Text = string.Empty;
				cboProduct.SelectedIndex = 0;
				dtpSalesDate.MaxDate = GeneralBLL.GetServerDateAndTime().Date;
				dtpSalesDate.Value = GeneralBLL.GetServerDateAndTime().Date;
				txtQty.Text = "0";
				txtDiscount.Text = "0.00";
				lblTotalValue.Text = "0.00";
				lblPreviousDueValue.Text = "0.00";
				lblNetAmountValue.Text = "0.00";
				txtReceivedAmount.Text = "0.00";
				lblTotalDueValue.Text = "0.00";
				lblSelectedDueValue.Text = "0.00";
				lblExcessAmountValue.Text = "0.00";
				lblCollectionAmountValue.Text = "0.00";
				txtVehicleNo.Enabled = true;
				txtCustomerName.Enabled = true;
				chkShowAll.Checked = false;
				SetCustomerDetailsArea();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void CalculateAmount()
		{
			try
			{
				int qty = 0;
				decimal rate = 0;
				decimal discount = 0;
				decimal total = 0;
				decimal due = 0;
				decimal selectedDue = 0;
				decimal receivedAmount = 0;
				if (txtQty.Text.Length > 0)
				{
					qty = Convert.ToInt32(txtQty.Text);
				}
				rate = Convert.ToDecimal(txtRate.Text);
				if (txtDiscount.Text.Length > 0)
				{
					discount = Convert.ToDecimal(txtDiscount.Text);
				}
				total = (qty * rate) - discount;
				due = Convert.ToDecimal(lblPreviousDueValue.Text);
				lblTotalValue.Text = total.ToString("F");
				lblNetAmountValue.Text = (total + due).ToString("F");
				selectedDue = Convert.ToDecimal(lblSelectedDueValue.Text);
				if(txtReceivedAmount.Text.Length > 0)
				{
					receivedAmount = Convert.ToDecimal(txtReceivedAmount.Text);
				}
				lblExcessAmountValue.Text = (receivedAmount - total - selectedDue).ToString("F");
				lblCollectionAmountValue.Text = (total + selectedDue).ToString("F");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void SearchVehicleNo()
		{
			try
			{
				DataTable dtCustomerDetails = CustomerBLL.GetCustomerPendingAmountUsingVehicleNo(txtVehicleNo.Text.Trim());
				if (dtCustomerDetails.Rows.Count > 0)
				{
					txtVehicleNo.Tag = dtCustomerDetails.Rows[0]["CustomerID"];
					txtCustomerName.Text = (dtCustomerDetails.Rows[0]["CustomerName"] ?? string.Empty).ToString().Trim();
					txtCustomerName.Enabled = false;
					lblPreviousDueValue.Text = Convert.ToDecimal(dtCustomerDetails.Rows[0]["PendingAmount"]).ToString("F");
					CalculateAmount();
				}
				else
				{
					txtVehicleNo.Tag = 0;
				}
				SetCustomerDetailsArea();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void SearchCustomerName()
		{
			try
			{
				DataTable dtCustomerDetails = CustomerBLL.GetCustomerPendingAmountUsingName(txtCustomerName.Text.Trim());
				if (dtCustomerDetails.Rows.Count > 0)
				{
					txtVehicleNo.Tag = dtCustomerDetails.Rows[0]["CustomerID"];
					txtVehicleNo.Text = (dtCustomerDetails.Rows[0]["VehicleNo"] ?? string.Empty).ToString().Trim();
					txtVehicleNo.Enabled = false;
					lblPreviousDueValue.Text = Convert.ToDecimal(dtCustomerDetails.Rows[0]["PendingAmount"]).ToString("F");
					CalculateAmount();
				}
				else
				{
					txtVehicleNo.Tag = 0;
				}
				SetCustomerDetailsArea();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void SetCustomerDetailsArea()
		{
			int customerId = Convert.ToInt32(txtVehicleNo.Tag);
			if (customerId > 0)
			{
				gbxCustomerDetails.Visible = true;
				lblCustomerFound.ForeColor = Color.Lime;
				lblCustomerFound.Text = "Old Customer";
				SetSalesVoucherHistoryGrid();
				FillSalesVoucherHistoryGrid();
			}
			else
			{
				if (txtVehicleNo.Text.Trim().Length > 0 || txtCustomerName.Text.Trim().Length > 0)
				{
					gbxCustomerDetails.Visible = true;
					lblCustomerFound.ForeColor = Color.Red;
					lblCustomerFound.Text = "New Customer";
				}
				else
				{
					gbxCustomerDetails.Visible = false;
				}
			}
		}

		private void SetSalesVoucherHistoryGrid()
		{
			try
			{
				dgvSalesHistory.Rows.Clear();
				dgvSalesHistory.Columns.Clear();

				// Creating check column and adding into voucher details grid
				DataGridViewCheckBoxColumn colVoucherCheck = new DataGridViewCheckBoxColumn();
				colVoucherCheck.Name = "colVoucherCheck";
				colVoucherCheck.HeaderText = "";
				colVoucherCheck.MinimumWidth = 30;
				colVoucherCheck.Width = 40;
				colVoucherCheck.ReadOnly = false;
				colVoucherCheck.Visible = true;
				colVoucherCheck.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				colVoucherCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				colVoucherCheck.SortMode = DataGridViewColumnSortMode.NotSortable;

				// Creating sales id column and adding into voucher details grid
				DataGridViewCheckBoxColumn colVoucherSalesId = new DataGridViewCheckBoxColumn();
				colVoucherSalesId.Name = "colVoucherSalesId";
				colVoucherSalesId.HeaderText = "";
				colVoucherSalesId.Visible = false;

				// Creating date column and adding into voucher details grid
				nDataGridViewTextBoxColumn colVoucherDate = new nDataGridViewTextBoxColumn();
				colVoucherDate.Name = "colVoucherDate";
				colVoucherDate.HeaderText = "Date";
				colVoucherDate.MinimumWidth = 80;
				colVoucherDate.FillWeight = 250;
				colVoucherDate.ReadOnly = true;
				colVoucherDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colVoucherDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colVoucherDate.SortMode = DataGridViewColumnSortMode.NotSortable;

				// Creating model column and adding into voucher details grid
				nDataGridViewTextBoxColumn colVoucherModel = new nDataGridViewTextBoxColumn();
				colVoucherModel.Name = "colVoucherModel";
				colVoucherModel.HeaderText = "Model";
				colVoucherModel.MinimumWidth = 100;
				colVoucherModel.FillWeight = 350;
				colVoucherModel.ReadOnly = true;
				colVoucherModel.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colVoucherModel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colVoucherModel.SortMode = DataGridViewColumnSortMode.NotSortable;

				// Creating amount column and adding into voucher details grid
				nDataGridViewTextBoxColumn colVoucherNetAmount = new nDataGridViewTextBoxColumn();
				colVoucherNetAmount.Name = "colVoucherAmount";
				colVoucherNetAmount.HeaderText = "Amount";
				colVoucherNetAmount.MinimumWidth = 80;
				colVoucherNetAmount.FillWeight = 250;
				colVoucherNetAmount.ReadOnly = true;
				colVoucherNetAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colVoucherNetAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colVoucherNetAmount.SortMode = DataGridViewColumnSortMode.NotSortable;

				// Creating Settled amount column and adding into voucher details grid
				nDataGridViewTextBoxColumn colVoucherSettledAmount = new nDataGridViewTextBoxColumn();
				colVoucherSettledAmount.Name = "colVoucherSettledAmount";
				colVoucherSettledAmount.HeaderText = "Settled";
				colVoucherSettledAmount.MinimumWidth = 80;
				colVoucherSettledAmount.FillWeight = 250;
				colVoucherSettledAmount.ReadOnly = true;
				colVoucherSettledAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colVoucherSettledAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colVoucherSettledAmount.SortMode = DataGridViewColumnSortMode.NotSortable;

				// Creating Settled amount column and adding into voucher details grid
				nDataGridViewTextBoxColumn colVoucherPendingAmount = new nDataGridViewTextBoxColumn();
				colVoucherPendingAmount.Name = "colVoucherPendingAmount";
				colVoucherPendingAmount.HeaderText = "Pending";
				colVoucherPendingAmount.MinimumWidth = 80;
				colVoucherPendingAmount.FillWeight = 250;
				colVoucherPendingAmount.ReadOnly = true;
				colVoucherPendingAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colVoucherPendingAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				colVoucherPendingAmount.SortMode = DataGridViewColumnSortMode.NotSortable;

				dgvSalesHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
																								colVoucherCheck,
																								colVoucherSalesId,
																								colVoucherDate,
																								colVoucherModel,
																								colVoucherNetAmount,
																								colVoucherSettledAmount,
																								colVoucherPendingAmount});

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void FillSalesVoucherHistoryGrid()
		{
			try
			{
				DataTable dtSalesVouchers = SalesBLL.GetSalesVoucherHistory(Convert.ToInt32(txtVehicleNo.Tag), chkShowAll.Checked);
				decimal totalDue = 0.00M;
				foreach (DataRow Sales in dtSalesVouchers.Rows)
				{
					dgvSalesHistory.Rows.Add();

					dgvSalesHistory.Rows[dgvSalesHistory.RowCount - 1].Cells[(int)GridColsSalesVoucherHistory.SalesId].Value = Sales["SalesID"];
					dgvSalesHistory.Rows[dgvSalesHistory.RowCount - 1].Cells[(int)GridColsSalesVoucherHistory.Date].Value = Sales["SalesDate"].ToString();
					dgvSalesHistory.Rows[dgvSalesHistory.RowCount - 1].Cells[(int)GridColsSalesVoucherHistory.Model].Value = Sales["ModelName"].ToString();
					decimal amount = Convert.ToDecimal(Sales["NetAmount"]);
					decimal settled = Convert.ToDecimal(Sales["SettledAmount"]);
					decimal pending = amount - settled > 0 ? amount - settled : 0;
					totalDue += pending;
					dgvSalesHistory.Rows[dgvSalesHistory.RowCount - 1].Cells[(int)GridColsSalesVoucherHistory.Amount].Value = amount.ToString("F");
					dgvSalesHistory.Rows[dgvSalesHistory.RowCount - 1].Cells[(int)GridColsSalesVoucherHistory.Settled].Value = settled.ToString("F");
					dgvSalesHistory.Rows[dgvSalesHistory.RowCount - 1].Cells[(int)GridColsSalesVoucherHistory.Pending].Value = pending.ToString("F");
				}
				lblTotalDueValue.Text = totalDue.ToString("F");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void FillSalesDetailsUsingRefNo()
		{
			try
			{
				int refNo = Convert.ToInt32(txtRefNo.Text);
				int latestSalesNo = SalesBLL.CheckIsLastSaleToTheCustomer(refNo);
				if(latestSalesNo == 0)
				{

				}
				else
				{
					Messages.ShowInformationMessage("Sales vouchers found for this customer which created after this sales voucher. So can not modify. \n Ref. No : " + latestSalesNo.ToString());
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion

		#region Button Events

		private void btnSearchVehicleNo_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtVehicleNo.Text.Length > 0)
				{
					SearchVehicleNo();
					cboProduct.Focus();
				}
				else
				{
					ClearFields();
					Messages.ShowInformationMessage("Please enter vehicle number.");
					txtVehicleNo.Focus();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("SearchVehicleNo_Click: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void btnSearchCustomer_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtCustomerName.Text.Length > 0)
				{
					SearchCustomerName();
					cboProduct.Focus();
				}
				else
				{
					ClearFields();
					Messages.ShowInformationMessage("Please enter customer name.");
					txtCustomerName.Focus();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("SearchCustomer_Click: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			try
			{
				ClearFields();
				txtVehicleNo.Focus();

			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Clear_Click: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			try
			{
				Close();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Close_Click: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtVehicleNo.Text.Trim().Length == 0 && txtCustomerName.Text.Trim().Length == 0)
				{
					Messages.ShowInformationMessage("Customer details is not entered.");
					txtVehicleNo.Focus();
					return;
				}
				if (Convert.ToInt32(txtQty.Text) * Convert.ToDecimal(txtRate.Text) < Convert.ToDecimal(txtDiscount.Text))
				{
					Messages.ShowInformationMessage("You cannot give dicount more than the bill amount.");
					txtDiscount.Focus();
					return;
				}
				if (Convert.ToDecimal(lblTotalValue.Text) == 0 && Convert.ToDecimal(txtReceivedAmount.Text) == 0)
				{
					Messages.ShowInformationMessage("Invalid entry. Voucher amount and received amount are zero.");
					txtQty.Focus();
					return;
				}
				if (dtpSalesDate.Value.Date < GeneralBLL.GetServerDateAndTime().Date && !Messages.ShowConfirmation("Do you want to enter sales voucher for previous date?"))
				{
					return;
				}
				if (Convert.ToInt32(txtQty.Text) == 0 && Convert.ToDecimal(txtReceivedAmount.Text) > 0 && !Messages.ShowConfirmation("Quantity is zero. Are you going to enter a settlement entry?"))
				{
					txtQty.Focus();
					return;
				}
				if (Convert.ToDecimal(lblExcessAmountValue.Text) > 0)
				{
					Messages.ShowInformationMessage("Excess amount. Cannot proceed.");
					txtReceivedAmount.Focus();
					return;
				}
				if(Convert.ToDecimal(lblSelectedDueValue.Text) > 0 && Convert.ToDecimal(lblExcessAmountValue.Text) != 0)
				{
					Messages.ShowInformationMessage("Excess/Short in amount. Cannot proceed.");
					txtReceivedAmount.Focus();
					return;
				}
				Cursor.Current = Cursors.WaitCursor;
				if (Convert.ToInt32(txtVehicleNo.Tag) == 0)
				{
					Customer customer = new Customer();
					customer.CustomerId = 0;
					customer.CustomerName = txtCustomerName.Text.Trim();
					customer.VehicleNumber = txtVehicleNo.Text.Trim();
					customer.IsInsertUpdateDelete = InsertUpdateDeleteMode.InsertMode;
					txtVehicleNo.Tag = CustomerBLL.InsertUpdateCustomer(ref customer);
					GeneralBLL.InsertEventLog("New customer [" + (txtCustomerName.Text.Trim().Length > 0 ? txtCustomerName.Text.Trim() : txtVehicleNo.Text.Trim()) + "] created.", EventLogType.SalesVoucher, EventLogMode.Insert, Convert.ToInt32(txtVehicleNo.Tag));
				}
				SalesVoucher salesVoucher = new SalesVoucher();
				salesVoucher.CustomerId = Convert.ToInt32(txtVehicleNo.Tag);
				salesVoucher.ModelId = (cboProduct.SelectedItem as nComboboxItem).Value;
				salesVoucher.SalesDate = dtpSalesDate.Value;
				salesVoucher.Quantity = Convert.ToInt32(txtQty.Text);
				salesVoucher.Rate = Convert.ToDecimal(txtRate.Text);
				salesVoucher.Discount = Convert.ToDecimal(txtDiscount.Text);
				salesVoucher.NetAmount = Convert.ToDecimal(lblTotalValue.Text);
				salesVoucher.ReceivedAmount = Convert.ToDecimal(txtReceivedAmount.Text);
				salesVoucher.CreatedBy = ActiveUserSession.UserId;
				foreach(DataGridViewRow row in dgvSalesHistory.Rows)
				{
					if (Convert.ToBoolean(row.Cells[(int)GridColsSalesVoucherHistory.Select].Value))
					{
						salesVoucher.SettlementList.Add(new SalesVoucherSettlement()
						{
							SalesId = Convert.ToInt32(row.Cells[(int)GridColsSalesVoucherHistory.SalesId].Value),
							Amount = Convert.ToDecimal(row.Cells[(int)GridColsSalesVoucherHistory.Pending].Value)
						});
					}
				}
				salesVoucher.SalesId = SalesBLL.InsertSalesVoucher(ref salesVoucher);
				GeneralBLL.InsertEventLog("Sales voucher saved", EventLogType.SalesVoucher, EventLogMode.Insert, salesVoucher.SalesId);
				ClearFields();
				Messages.ShowInformationMessage("Sales voucher saved successfully.\nSales voucher reference no: " + salesVoucher.SalesNo.ToString());
				txtVehicleNo.Focus();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Save_Click: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				FillSalesDetailsUsingRefNo();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Search_Click: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		#endregion

		#region Other Control Events

		private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (Convert.ToInt32((cboProduct.SelectedItem as nComboboxItem).Value) > 0)
				{
					txtRate.Text = ProductBLL.GetProductModelRate(Convert.ToInt32((cboProduct.SelectedItem as nComboboxItem).Value)).ToString("F");
					CalculateAmount();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Product_SelectedIndexChanged: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void txtQty_Leave(object sender, EventArgs e)
		{
			try
			{
				if (txtQty.Text.Length == 0)
				{
					txtQty.Text = "0";
				}
				CalculateAmount();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Qty_Leave: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void txtDiscount_Leave(object sender, EventArgs e)
		{
			try
			{
				CalculateAmount();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Discount_Leave: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void txtVehicleNo_Leave(object sender, EventArgs e)
		{
			try
			{
				if (txtVehicleNo.Text.Trim().Length > 0)
				{
					SearchVehicleNo();
				}
				if (txtVehicleNo.Text.Trim().Length == 0 && txtCustomerName.Text.Trim().Length == 0)
				{
					txtVehicleNo.Tag = 0;
					SetCustomerDetailsArea();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("VehicleNo_Leave: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void txtCustomerName_Leave(object sender, EventArgs e)
		{
			try
			{
				if (txtCustomerName.Text.Trim().Length > 0)
				{
					SearchCustomerName();
				}
				if (txtVehicleNo.Text.Trim().Length == 0 && txtCustomerName.Text.Trim().Length == 0)
				{
					txtVehicleNo.Tag = 0;
					SetCustomerDetailsArea();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("CustomerName_Leave: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void txtReceivedAmount_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalculateAmount();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("ReceivedAmount_TextChanged: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void chkShowAll_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				SetSalesVoucherHistoryGrid();
				if (Convert.ToInt32(txtVehicleNo.Tag) > 0)
				{
					FillSalesVoucherHistoryGrid();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("ShowAll_CheckedChanged: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void dgvSalesHistory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex >= 0 && e.ColumnIndex == (int)GridColsSalesVoucherHistory.Select)
				{
					dgvSalesHistory.CommitEdit(DataGridViewDataErrorContexts.Commit);
					decimal selectedDueTotal = 0.00M;
					foreach (DataGridViewRow row in dgvSalesHistory.Rows)
					{
						if ((bool)row.Cells[(int)GridColsSalesVoucherHistory.Select].EditedFormattedValue)
						{
							selectedDueTotal += Convert.ToDecimal(row.Cells[(int)GridColsSalesVoucherHistory.Pending].EditedFormattedValue);
						}
					}
					lblSelectedDueValue.Text = selectedDueTotal.ToString("F");
					CalculateAmount();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("SalesHistory_CellContentClick: " + ex.Message, EventLogType.SalesVoucher, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void dgvSalesHistory_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (dgvSalesHistory.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
			{
				dgvSalesHistory.EndEdit();
			}
		}

		#endregion
	}
}
