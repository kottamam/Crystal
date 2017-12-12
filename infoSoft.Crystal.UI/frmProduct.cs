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
	public partial class frmProduct : BaseForm
	{
		#region Constructor

		public frmProduct()
		{
			InitializeComponent();
		}

		#endregion Constructor

		#region Private Variables

		TreeNode currentSearchResultNode = null;
		AutoCompleteStringCollection colValues;

		#endregion

		#region Form Events

		/// <summary>
		/// On form load
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmProduct_Load(object sender, System.EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				SplitterPanel panel1 = splitContainer.Panel1;
				SplitterPanel panel2 = splitContainer.Panel2;
				splitContainer.Panel1MinSize = this.Width * 20 / 100;
				splitContainer.Panel2MinSize = this.Width * 60 / 100;
				BindProductTreeView();
				ClearFields();
				colValues = new AutoCompleteStringCollection();
				txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
				txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
				DataTable dtSource = ProductBLL.GetProductModelList();
				foreach (DataRow item in dtSource.Rows)
				{
					colValues.Add(item["ModelName"].ToString());
				}
				txtSearch.AutoCompleteCustomSource = colValues;
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Product: " + ex.Message, EventLogType.Application, EventLogMode.Error);
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
		private void frmProduct_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					switch (splitContainer.ActiveControl.Name)
					{
						case "tvwProduct":
							// if active control is tvwAccount and it is null then focus to new Button
							if (txtSearch.Text.Trim().Length == 0)
							{
								btnUpdate.Focus();
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
				GeneralBLL.InsertEventLog("Product: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// To bind Product tree view
		/// </summary>
		private void BindProductTreeView()
		{
			try
			{
				TreeNode rootNode = tvwProduct.Nodes.Add("0", "Products", 0);
				rootNode.Tag = 0;
				DataTable dtProducts = ProductBLL.GetProductModelList();
				if (dtProducts.Rows.Count > 0)
				{
					foreach (DataRow drProduct in dtProducts.Rows)
					{
						TreeNode parent = rootNode.Nodes.Add("P" + drProduct["ModelID"], drProduct["ModelName"].ToString(), 3);
						parent.Tag = Convert.ToInt32(drProduct["ModelID"]);
					}
					dtProducts.Dispose();
				}
				tvwProduct.ExpandAll();
				tvwProduct.Select();
				lblProductCount.Text = dtProducts.Rows.Count + " Product(s) defined.";
				tvwProduct.SelectedNode = tvwProduct.Nodes[0];
			}
			catch (Exception ex)
			{
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
				txtProductName.Text = string.Empty;
				txtProductName.Tag = 0;
				txtDescription.Text = string.Empty;
				txtRate.Text = "0.00";
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		
		/// <summary>
		/// For setting Product details to the controls
		/// </summary>
		private void SetProductDetailsToControls()
		{
			try
			{
				// Calling business method for getting Product details by Product id
				DataTable dtProduct = ProductBLL.GetProductModelDetails(Convert.ToInt32(tvwProduct.SelectedNode.Tag));
				if (dtProduct.Rows.Count > 0)
				{
					txtProductName.Text = dtProduct.Rows[0]["ModelName"].ToString().Trim();
					txtProductName.Tag = Convert.ToInt32(dtProduct.Rows[0]["ModelID"]);
					txtDescription.Text = dtProduct.Rows[0]["Description"].ToString().Trim();
					txtRate.Text = Convert.ToDecimal(dtProduct.Rows[0]["Rate"]).ToString("F");
				}
				else
				{
					ClearFields();
				}
			}
			catch (Exception ex)
			{
				throw ex;
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
						tvwProduct.Focus();
						string search = txtSearch.Text;
						tvwProduct.SelectedNode = nodeStart;
						currentSearchResultNode = nodeStart;
						txtSearch.Text = search;
						// Setting the focus and text for search when the selection comes to the root node
						if (string.Compare(tvwProduct.SelectedNode.Name, "0", true) == 0)
						{
							btnSearch.Focus();
							tvwProduct.Select();
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
						SearchNodes(tvwProduct.Nodes[0]);
					}
					else
					{
						txtSearch.Clear();
						tvwProduct.SelectedNode = tvwProduct.Nodes[0];
						currentSearchResultNode = null;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		#endregion

		#region Treeview Events

		/// <summary>
		/// Before tree view item selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwProduct_BeforeSelect(object sender, TreeViewCancelEventArgs e)
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
				GeneralBLL.InsertEventLog("Product: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		/// <summary>
		/// After tree view item selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwProduct_AfterSelect(object sender, TreeViewEventArgs e)
		{
			try
			{
				txtProductName.Tag = e.Node.Tag;
				if (string.Compare(tvwProduct.SelectedNode.Name, "0", true) == 0)
				{
					// For clearing controls in the form
					ClearFields();
					btnUpdate.Enabled = false;
					txtRate.Enabled = false;
				}
				else
				{
					// For setting account details to object
					SetProductDetailsToControls();
					btnUpdate.Enabled = true;
					txtRate.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Product: " + ex.Message, EventLogType.Application, EventLogMode.Error);
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
				tvwProduct.ExpandAll();
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
					SearchNodes(tvwProduct.Nodes[0]);
				}
				else
				{
					if (currentSearchResultNode.NextVisibleNode == null)
					{
						if (Messages.ShowConfirmation("The search has reached the end of list.\n Do you want to search from the beginning?"))
						{
							SearchNodes(tvwProduct.Nodes[0]);
						}
						else
						{
							txtSearch.Focus();
							txtSearch.SelectAll();
							tvwProduct.SelectedNode = tvwProduct.Nodes[0];
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
				GeneralBLL.InsertEventLog("Product: " + ex.Message, EventLogType.Application, EventLogMode.Error);
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
				GeneralBLL.InsertEventLog("Product: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
		}

		/// <summary>
		/// On new button click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				if(Convert.ToInt32(txtProductName.Tag) > 0)
				{
					if(Messages.ShowConfirmation("Do you want to update the rate?"))
					{
						ProductBLL.UpdateProductModelRate(Convert.ToInt32(txtProductName.Tag), Convert.ToDecimal(txtRate.Text));
						GeneralBLL.InsertEventLog("Product [" + txtProductName.Text.Trim() + "] rate updated to " + txtRate.Text.Trim() + ".", EventLogType.Product, EventLogMode.Update, Convert.ToInt32(txtProductName.Tag));
						Messages.ShowInformationMessage("Product rate updated.");
					}
				}
				else
				{
					Messages.ShowInformationMessage("Select a product to update rate.");
				}
			}
			catch (Exception ex)
			{
				GeneralBLL.InsertEventLog("Product: " + ex.Message, EventLogType.Application, EventLogMode.Error);
				Messages.ShowExceptionMessage(ref ex);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
			//try
			//{
			//	if (blnEditMode)
			//	{
			//		if (txtProductName.Text.Trim().Length == 0 && txtVehicleNo.Text.Trim().Length == 0)
			//		{
			//			Messages.ShowInformationMessage("Please enter Product name or vehicle number.");
			//			txtProductName.Focus();
			//			return;
			//		}
			//		if (txtProductName.Text.Trim().Length > 0 && ProductBLL.CheckDuplicateProductName(Convert.ToInt32(txtProductName.Tag), txtProductName.Text.Trim()) > 0)
			//		{
			//			Messages.ShowInformationMessage("Another Product exist with the given name. Please check the Product name.");
			//			txtProductName.Focus();
			//			return;
			//		}
			//		if (txtVehicleNo.Text.Trim().Length > 0 && ProductBLL.CheckDuplicateVehicleNo(Convert.ToInt32(txtProductName.Tag), txtVehicleNo.Text.Trim()) > 0)
			//		{
			//			Messages.ShowInformationMessage("Another Product exist with the given name. Please check the Product name.");
			//			txtProductName.Focus();
			//			return;
			//		}
			//		Cursor.Current = Cursors.WaitCursor;
			//		// Setting Product details to the object
			//		Product Product = new Product();
			//		Product.ProductId = Convert.ToInt32(txtProductName.Tag);
			//		Product.ProductName = txtProductName.Text.Trim();
			//		Product.VehicleNumber = txtVehicleNo.Text.Trim();
			//		Product.Address1 = txtAddress1.Text.Trim();
			//		Product.Address2 = txtAddress2.Text.Trim();
			//		Product.Phone = txtPhone.Text.Trim();
			//		Product.Mobile = txtMobile.Text.Trim();
			//		if (blnAddMode)
			//		{
			//			Product.IsInsertUpdateDelete = InsertUpdateDeleteMode.InsertMode;
			//			int ProductId = ProductBLL.InsertUpdateProduct(ref Product);
			//			GeneralBLL.InsertEventLog("New Product [" + (txtProductName.Text.Trim().Length > 0 ? txtProductName.Text.Trim() : txtVehicleNo.Text.Trim()) + "] created.", EventLogType.Product, EventLogMode.Insert, ProductId);
			//			tvwProduct.ExpandAll();

			//			TreeNode newNode = tvwProduct.Nodes[0].Nodes.Add("P" + ProductId.ToString(), txtProductName.Text.Trim(), 3);
			//			newNode.Tag = ProductId;
			//			tvwProduct.SelectedNode = newNode;
			//			lblProductCount.Text = tvwProduct.Nodes[0].Nodes.Count + " Product(s) defined.";
			//			Messages.ShowInformationMessage("Product [" + (txtProductName.Text.Trim().Length > 0 ? txtProductName.Text.Trim() : txtVehicleNo.Text.Trim()) + "] created successfully.");
			//		}
			//		else
			//		{
			//			Product.IsInsertUpdateDelete = InsertUpdateDeleteMode.UpdateMode;
			//			int ProductId = ProductBLL.InsertUpdateProduct(ref Product);
			//			GeneralBLL.InsertEventLog("Product [" + (txtProductName.Text.Trim().Length > 0 ? txtProductName.Text.Trim() : txtVehicleNo.Text.Trim()) + "] updated.", EventLogType.Product, EventLogMode.Update, Convert.ToInt32(txtProductName.Tag));
			//			if (Convert.ToInt32(txtProductName.Tag) == Convert.ToInt32(tvwProduct.SelectedNode.Tag))
			//			{
			//				tvwProduct.SelectedNode.Text = (txtProductName.Text.Trim().Length > 0 ? txtProductName.Text.Trim() : txtVehicleNo.Text.Trim());
			//			}
			//			else
			//			{
			//				tvwProduct.SelectedNode.Remove();
			//				tvwProduct.ExpandAll();
			//				TreeNode newNode = tvwProduct.Nodes[0].Nodes.Add("P" + ProductId.ToString(), txtProductName.Text.Trim(), 3);
			//				newNode.Tag = ProductId;
			//				tvwProduct.SelectedNode = newNode;
			//			}
			//			Messages.ShowInformationMessage("Account [" + (txtProductName.Text.Trim().Length > 0 ? txtProductName.Text.Trim() : txtVehicleNo.Text.Trim()) + "] updated successfully.");
			//		}
			//		blnAddMode = false;
			//		blnEditMode = false;
			//	}
			//	else
			//	{
			//		blnEditMode = true;
			//		blnAddMode = true;
			//		ClearFields();
			//	}
			//	RefreshButtons();
			//}
			//catch (Exception ex)
			//{
			//	GeneralBLL.InsertEventLog("Product: " + ex.Message, EventLogType.Application, EventLogMode.Error);
			//	Messages.ShowExceptionMessage(ref ex);
			//}
			//finally
			//{
			//	Cursor.Current = Cursors.Default;
			//}
		}

			#endregion

		}
}
