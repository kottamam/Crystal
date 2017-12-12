#region Copyright

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
				GeneralBLL.InsertEventLog("Sales Voucher: " + ex.Message, EventLogType.Application, EventLogMode.Error);
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
								btnSearchVehicleNo.PerformClick();
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
				GeneralBLL.InsertEventLog("Sales Voucher: " + ex.Message, EventLogType.Application, EventLogMode.Error);
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
				dtpSalesDate.Value = GeneralBLL.GetServerDateAndTime();
				txtQty.Text = "0";
				txtDiscount.Text = "0.00";
				lblTotalValue.Text = "0.00";
				lblPreviousDueValue.Text = "0.00";
				lblNetAmountValue.Text = "0.00";
				txtSettledAmount.Text = "0.00";
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
				if(txtQty.Text.Length > 0)
				{
					qty = Convert.ToInt32(txtQty.Text);
				}
				rate = Convert.ToDecimal(txtRate.Text);
				if(txtDiscount.Text.Length > 0)
				{
					discount = Convert.ToDecimal(txtDiscount.Text);
				}
				total = (qty * rate) - discount;
				due = Convert.ToDecimal(lblPreviousDueValue.Text);
				lblTotalValue.Text = total.ToString("F");
				lblNetAmountValue.Text = (total - due).ToString("F");
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
					DataTable dtCustomerDetails = CustomerBLL.GetCustomerPendingAmountUsingVehicleNo(txtVehicleNo.Text.Trim());
					if (dtCustomerDetails.Rows.Count > 0)
					{
						txtVehicleNo.Tag = dtCustomerDetails.Rows[0]["CustomerID"];
						txtCustomerName.Text = (dtCustomerDetails.Rows[0]["CustomerName"] ?? string.Empty).ToString().Trim();
						lblPreviousDueValue.Text = Convert.ToDecimal(dtCustomerDetails.Rows[0]["PendingAmount"]).ToString("F");
						CalculateAmount();
					}
					else
					{
						txtVehicleNo.Tag = 0;
						txtCustomerName.Text = string.Empty;
					}
					cboProduct.Focus();
				}
				else
				{
					txtVehicleNo.Tag = 0;
					txtCustomerName.Text = string.Empty;
					Messages.ShowInformationMessage("Please enter vehicle number.");
					txtVehicleNo.Focus();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Sales Voucher: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void btnSearchCustomer_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtCustomerName.Text.Length > 0)
				{
					DataTable dtCustomerDetails = CustomerBLL.GetCustomerPendingAmountUsingName(txtCustomerName.Text.Trim());
					if (dtCustomerDetails.Rows.Count > 0)
					{
						txtVehicleNo.Tag = dtCustomerDetails.Rows[0]["CustomerID"];
						txtVehicleNo.Text = (dtCustomerDetails.Rows[0]["VehicleNo"] ?? string.Empty).ToString().Trim();
						lblPreviousDueValue.Text = Convert.ToDecimal(dtCustomerDetails.Rows[0]["PendingAmount"]).ToString("F");
						CalculateAmount();
					}
					else
					{
						txtVehicleNo.Tag = 0;
						txtVehicleNo.Text = string.Empty;
					}
					cboProduct.Focus();
				}
				else
				{
					txtVehicleNo.Tag = 0;
					txtVehicleNo.Text = string.Empty;
					Messages.ShowInformationMessage("Please enter customer name.");
					txtCustomerName.Focus();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Sales Voucher: " + ex.Message, EventLogType.Application, EventLogMode.Error);
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
				GeneralBLL.InsertEventLog("Sales Voucher: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		private void txtQty_Leave(object sender, EventArgs e)
		{
			try
			{
				CalculateAmount();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Sales Voucher: " + ex.Message, EventLogType.Application, EventLogMode.Error);
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
				GeneralBLL.InsertEventLog("Sales Voucher: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		#endregion

	}
}
