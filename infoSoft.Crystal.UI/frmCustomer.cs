#region Copyright

// ©Copyright 2017, tv Software Private Limited,  All rights reserved.

#endregion Copyright

#region Code history

// Created On   : 25.11.2017
// Created By   : Noble
// Description  : Screen for create customer
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
	public partial class frmCustomer : BaseForm
	{
		#region Constructor

		public frmCustomer()
		{
			InitializeComponent();
		}

		#endregion Constructor

		#region Private Variables

		TreeNode currentSearchResultNode = null;
		private Boolean blnEditMode = false;        // Variable indicating edit mode
		private Boolean blnAddMode = false;         // Variable indicating add mode
		AutoCompleteStringCollection colValues;

		#endregion

		#region Form Events

		/// <summary>
		/// On form load
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmCustomer_Load(object sender, System.EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				SplitterPanel panel1 = splitContainer.Panel1;
				SplitterPanel panel2 = splitContainer.Panel2;
				splitContainer.Panel1MinSize = this.Width * 20 / 100;
				splitContainer.Panel2MinSize = this.Width * 60 / 100;
				BindCustomerTreeView();
				ClearFields();
				RefreshButtons();
				colValues = new AutoCompleteStringCollection();
				txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
				txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
				DataTable dtSource = CustomerBLL.GetCustomerList();
				foreach (DataRow item in dtSource.Rows)
				{
					colValues.Add(item["Customer"].ToString());
				}
				txtSearch.AutoCompleteCustomSource = colValues;
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		/// <summary>
		/// On form key down
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmCustomer_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					switch (splitContainer.ActiveControl.Name)
					{
						case "tvwCustomer":
							// if active control is tvwAccount and it is null then focus to new Button
							if (txtSearch.Text.Trim().Length == 0)
							{
								btnNew.Focus();
							}
							//if it is not null then focus performClick
							else
							{
								btnSearch.PerformClick();
							}
							break;
						case "txtSearch":
							btnSearch.PerformClick();
							break;
						default:
							SelectNextControl(splitContainer.ActiveControl, true, true, true, true);
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
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// To bind customer tree view
		/// </summary>
		private void BindCustomerTreeView()
		{
			try
			{
				TreeNode rootNode = tvwCustomer.Nodes.Add("0", "Customers", 0);
				rootNode.Tag = 0;
				DataTable dtCustomers = CustomerBLL.GetCustomerList();
				if (dtCustomers.Rows.Count > 0)
				{
					foreach (DataRow drCustomer in dtCustomers.Rows)
					{
						TreeNode parent = rootNode.Nodes.Add("C" + drCustomer["CustomerID"], drCustomer["Customer"].ToString(), 3);
						parent.Tag = Convert.ToInt32(drCustomer["CustomerID"]);
					}
					dtCustomers.Dispose();
				}
				tvwCustomer.ExpandAll();
				tvwCustomer.Select();
				lblCustomerCount.Text = dtCustomers.Rows.Count + " Customer(s) defined.";
				tvwCustomer.SelectedNode = tvwCustomer.Nodes[0];
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				throw ex;
			}
		}

		/// <summary>
		/// For clearing controls in the form
		/// </summary>
		private void ClearFields()
		{
			try
			{
				txtCustomerName.Text = string.Empty;
				txtCustomerName.Tag = 0;
				txtVehicleNo.Text = string.Empty;
				txtAddress1.Text = string.Empty;
				txtAddress2.Text = string.Empty;
				txtPhone.Text = string.Empty;
				txtMobile.Text = string.Empty;
				txtSearch.Text = string.Empty;
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				throw ex;
			}
		}

		/// <summary>
		/// Refreshing buttons in the form according to edit mode and add mode  
		/// </summary>
		private void RefreshButtons()
		{
			try
			{
				if (blnEditMode)
				{
					btnNew.Text = "&Save";
					tipCustomer.SetToolTip(btnNew, "Click here to save account details");
					btnModify.Text = "&Cancel";
					tipCustomer.SetToolTip(btnModify, "Click here to cancel");
					btnClose.Enabled = false;
					btnDelete.Enabled = false;
					btnModify.Enabled = true;
					txtCustomerName.Enabled = true;
					tvwCustomer.Enabled = false;
					gbxSearch.Enabled = false;
					txtVehicleNo.Enabled = true;
					txtAddress1.Enabled = true;
					txtAddress2.Enabled = true;
					txtPhone.Enabled = true;
					txtMobile.Enabled = true;
					txtCustomerName.Focus();
					//if (blnAddMode)
					//{
					//	radAccount.Enabled = true;
					//	radAccountGroup.Enabled = true;
					//	radAccount.Checked = false;
					//	radAccountGroup.Checked = true;
					//	cboAccountGroup.Enabled = true;
					//	radAccountGroup.Focus();
					//}
				}
				else
				{
					btnNew.Text = "&New";
					tipCustomer.SetToolTip(btnNew, "Click here to create new account");
					btnModify.Text = "&Modify";
					tipCustomer.SetToolTip(btnModify, "Click here to modify the account");
					txtCustomerName.Enabled = false;
					tvwCustomer.Enabled = true;
					gbxSearch.Enabled = true;
					txtVehicleNo.Enabled = false;
					txtAddress1.Enabled = false;
					txtAddress2.Enabled = false;
					txtPhone.Enabled = false;
					txtMobile.Enabled = false;
					btnDelete.Enabled = true;
					btnClose.Enabled = true;
					if (string.Compare(tvwCustomer.SelectedNode.Name, "0", true) == 0)
					{
						btnDelete.Enabled = false;
						btnModify.Enabled = false;
					}
					tvwCustomer.Select();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				throw ex;
			}
		}
		
		/// <summary>
		/// For setting customer details to the controls
		/// </summary>
		private void SetCustomerDetailsToControls()
		{
			try
			{
				// Calling business method for getting customer details by customer id
				DataTable dtCustomer = CustomerBLL.GetCustomerDetails(Convert.ToInt32(tvwCustomer.SelectedNode.Tag));
				if (dtCustomer.Rows.Count > 0)
				{
					txtCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString().Trim();
					txtCustomerName.Tag = Convert.ToInt32(dtCustomer.Rows[0]["CustomerID"]);
					txtVehicleNo.Text = dtCustomer.Rows[0]["VehicleNo"].ToString().Trim();
					txtAddress1.Text = dtCustomer.Rows[0]["Address1"].ToString().Trim();
					txtAddress2.Text = dtCustomer.Rows[0]["Address2"].ToString().Trim();
					txtPhone.Text = dtCustomer.Rows[0]["Phone"].ToString().Trim();
					txtMobile.Text = dtCustomer.Rows[0]["Mobile"].ToString().Trim();
				}
				else
				{
					ClearFields();
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				throw;
			}
		}

		/// <summary>
		/// To search account in tree view
		/// </summary>
		/// <param name="nodeStart">Current node</param>
		private void SearchNodes(TreeNode nodeStart)
		{
			try
			{
				do
				{
					// Compare the node text and search text
					if (nodeStart.Text.ToUpper().Contains(txtSearch.Text.ToString().ToUpper().Trim()))
					{
						tvwCustomer.Focus();
						string search = txtSearch.Text;
						tvwCustomer.SelectedNode = nodeStart;
						currentSearchResultNode = nodeStart;
						txtSearch.Text = search;
						// Setting the focus and text for search when the selection comes to the root node
						if (string.Compare(tvwCustomer.SelectedNode.Name, "0", true) == 0)
						{
							btnSearch.Focus();
							tvwCustomer.Select();
						}
						return;
					}
					nodeStart = nodeStart.NextVisibleNode;
				}
				while (nodeStart != null);

				// if the node is null then search reached the end of treeview
				if (nodeStart == null)
				{
					if (Messages.ShowConfirmation("The search has reached the end of list.\n Do you want to search from the beginning?"))
					{
						SearchNodes(tvwCustomer.Nodes[0]);
					}
					else
					{
						txtSearch.Clear();
						tvwCustomer.SelectedNode = tvwCustomer.Nodes[0];
						currentSearchResultNode = null;
					}
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				throw;
			}
		}


		#endregion

		#region Treeview Events

		/// <summary>
		/// Before tree view item selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwCustomer_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			try
			{
				if (e.Node.Level == 0)
				{
					e.Node.SelectedImageIndex = 0;
				}
				else
				{
					e.Node.SelectedImageIndex = e.Node.ImageIndex + 1;
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		/// <summary>
		/// After tree view item selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwCustomer_AfterSelect(object sender, TreeViewEventArgs e)
		{
			try
			{
				txtCustomerName.Tag = e.Node.Tag;
				if (string.Compare(tvwCustomer.SelectedNode.Name, "0", true) == 0)
				{
					// For clearing controls in the form
					ClearFields();
					btnModify.Enabled = false;
					btnDelete.Enabled = false;
				}
				else
				{
					btnModify.Enabled = true;
					btnDelete.Enabled = true;
					if (!blnEditMode)
					{
						// For setting account details to object
						SetCustomerDetailsToControls();
					}
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		#endregion

		#region Button Events

		/// <summary>
		/// On tree view search button click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			try
			{
				tvwCustomer.ExpandAll();
				if (txtSearch.Text.Trim().Length == 0)
				{
					Messages.ShowInformationMessage("Please enter text to search.");
					txtSearch.Focus();
					return;
				}
				Cursor.Current = Cursors.WaitCursor;
				// If currentnode is null then search from beginning
				if (currentSearchResultNode == null)
				{
					// For search a node in treeview
					SearchNodes(tvwCustomer.Nodes[0]);
				}
				else
				{
					if (currentSearchResultNode.NextVisibleNode == null)
					{
						if (Messages.ShowConfirmation("The search has reached the end of list.\n Do you want to search from the beginning?"))
						{
							SearchNodes(tvwCustomer.Nodes[0]);
						}
						else
						{
							txtSearch.Focus();
							txtSearch.SelectAll();
							tvwCustomer.SelectedNode = tvwCustomer.Nodes[0];
							currentSearchResultNode = null;
						}
					}
					else
					{
						// For search a node in treeview
						SearchNodes(currentSearchResultNode.NextVisibleNode);
					}
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		/// <summary>
		/// On close button click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnClose_Click(object sender, EventArgs e)
		{
			try
			{
				Close();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		/// <summary>
		/// On new button click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNew_Click(object sender, EventArgs e)
		{
			try
			{
				if (blnEditMode)
				{
					if (txtCustomerName.Text.Trim().Length == 0 && txtVehicleNo.Text.Trim().Length == 0)
					{
						Messages.ShowInformationMessage("Please enter customer name or vehicle number.");
						txtCustomerName.Focus();
						return;
					}
					if (txtCustomerName.Text.Trim().Length > 0 && CustomerBLL.CheckDuplicateCustomerName(Convert.ToInt32(txtCustomerName.Tag), txtCustomerName.Text.Trim()) > 0)
					{
						Messages.ShowInformationMessage("Another customer exist with the given name. Please check the customer name.");
						txtCustomerName.Focus();
						return;
					}
					if (txtVehicleNo.Text.Trim().Length > 0 && CustomerBLL.CheckDuplicateVehicleNo(Convert.ToInt32(txtCustomerName.Tag), txtVehicleNo.Text.Trim()) > 0)
					{
						Messages.ShowInformationMessage("Another customer exist with the given name. Please check the customer name.");
						txtCustomerName.Focus();
						return;
					}
					Cursor.Current = Cursors.WaitCursor;
					// Setting customer details to the object
					Customer customer = new Customer();
					customer.CustomerId = Convert.ToInt32(txtCustomerName.Tag);
					customer.CustomerName = txtCustomerName.Text.Trim();
					customer.VehicleNumber = txtVehicleNo.Text.Trim();
					customer.Address1 = txtAddress1.Text.Trim();
					customer.Address2 = txtAddress2.Text.Trim();
					customer.Phone = txtPhone.Text.Trim();
					customer.Mobile = txtMobile.Text.Trim();
					if (blnAddMode)
					{
						customer.IsInsertUpdateDelete = InsertUpdateDeleteMode.InsertMode;
						int customerId = CustomerBLL.InsertUpdateCustomer(ref customer);
						GeneralBLL.InsertEventLog("New customer [" + (txtCustomerName.Text.Trim().Length > 0 ? txtCustomerName.Text.Trim() : txtVehicleNo.Text.Trim()) + "] created.", EventLogType.Customer, EventLogMode.Insert, customerId);
						tvwCustomer.ExpandAll();

						TreeNode newNode = tvwCustomer.Nodes[0].Nodes.Add("C" + customerId.ToString(), txtCustomerName.Text.Trim(), 3);
						newNode.Tag = customerId;
						tvwCustomer.SelectedNode = newNode;
						lblCustomerCount.Text = tvwCustomer.Nodes[0].Nodes.Count + " Customer(s) defined.";
						Messages.ShowInformationMessage("Customer [" + (txtCustomerName.Text.Trim().Length > 0 ? txtCustomerName.Text.Trim() : txtVehicleNo.Text.Trim()) + "] created successfully.");
					}
					else
					{
						customer.IsInsertUpdateDelete = InsertUpdateDeleteMode.UpdateMode;
						int customerId = CustomerBLL.InsertUpdateCustomer(ref customer);
						GeneralBLL.InsertEventLog("Customer [" + (txtCustomerName.Text.Trim().Length > 0 ? txtCustomerName.Text.Trim() : txtVehicleNo.Text.Trim()) + "] updated.", EventLogType.Customer, EventLogMode.Update, Convert.ToInt32(txtCustomerName.Tag));
						if (Convert.ToInt32(txtCustomerName.Tag) == Convert.ToInt32(tvwCustomer.SelectedNode.Tag))
						{
							tvwCustomer.SelectedNode.Text = (txtCustomerName.Text.Trim().Length > 0 ? txtCustomerName.Text.Trim() : txtVehicleNo.Text.Trim());
						}
						else
						{
							tvwCustomer.SelectedNode.Remove();
							tvwCustomer.ExpandAll();
							TreeNode newNode = tvwCustomer.Nodes[0].Nodes.Add("C" + customerId.ToString(), txtCustomerName.Text.Trim(), 3);
							newNode.Tag = customerId;
							tvwCustomer.SelectedNode = newNode;
						}
						Messages.ShowInformationMessage("Account [" + (txtCustomerName.Text.Trim().Length > 0 ? txtCustomerName.Text.Trim() : txtVehicleNo.Text.Trim()) + "] updated successfully.");
					}
					blnAddMode = false;
					blnEditMode = false;
				}
				else
				{
					blnEditMode = true;
					blnAddMode = true;
					ClearFields();
				}
				RefreshButtons();
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		/// <summary>
		/// On modify button click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, EventArgs e)
		{
			try
			{
				if (blnEditMode)
				{
					if (string.Compare(tvwCustomer.SelectedNode.Name, "0", true) == 0)
					{
						ClearFields();
					}
					blnEditMode = false;

					if (blnAddMode)
					{
						blnAddMode = false;
						SetCustomerDetailsToControls();
					}
				}
				else
				{
					blnEditMode = true;
				}
				// Refreshing buttons in the form according to various modes
				RefreshButtons();
				if (string.Compare(tvwCustomer.SelectedNode.Name, "0", true) == 0)
				{
					btnDelete.Enabled = false;
					btnModify.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		/// <summary>
		/// On delete button click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if(Convert.ToInt32(txtCustomerName.Tag) > 0)
				{
					if(Messages.ShowConfirmation("Do you want to delete Customer [" + (txtCustomerName.Text.Trim().Length > 0 ? txtCustomerName.Text.Trim() : txtVehicleNo.Text.Trim()) + "]?"))
					{
						CustomerBLL.DeleteCustomer(Convert.ToInt32(txtCustomerName.Tag), ActiveUserSession.UserId);
						string infoMsg = "Customer [" + (txtCustomerName.Text.Trim().Length > 0 ? txtCustomerName.Text.Trim() : txtVehicleNo.Text.Trim()) + "] deleted.";
						GeneralBLL.InsertEventLog(infoMsg, EventLogType.Customer, EventLogMode.Delete, Convert.ToInt32(txtCustomerName.Tag));
						TreeNode newNode = tvwCustomer.Nodes[0].Nodes.Find("C" + txtCustomerName.Tag.ToString(), true)[0];
						tvwCustomer.Nodes[0].Nodes.Remove(newNode);
						tvwCustomer.SelectedNode = tvwCustomer.Nodes[0];
						lblCustomerCount.Text = tvwCustomer.Nodes[0].Nodes.Count + " Customer(s) defined.";
						Messages.ShowInformationMessage(infoMsg);
					}
				}
				else
				{
					Messages.ShowInformationMessage("Please select a customer to delete.");
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Customer: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		#endregion

	}
}
