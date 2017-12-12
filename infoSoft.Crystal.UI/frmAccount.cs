#region Copyright

// ©Copyright 2015, tv Software Private Limited,  All rights reserved.

#endregion Copyright

#region Code history

// Created On   : 20.06.2015
// Created By   : Noble
// Description  : Screen for creating account and account group
// -----------------------------------------//
// Modified By  : 
// Modified Date: 
// Description  : 

#endregion Code history

#region Using directives

using tv.Crystal.Business;
using tv.Crystal.Common.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using tv.Crystal.Common.Models;

#endregion

namespace tv.Crystal.UI
{
    public partial class frmAccount : tv.Crystal.UI.CustomControls.BaseForm
    {
        #region Constructor

        public frmAccount()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        TreeNode currentSearchResultNode = null;
        private Boolean blnEditMode = false;		// Variable indicating edit mode
        private Boolean blnAddMode = false;			// Variable indicating add mode
        int accountGroupCount = 0;
        int accountLedgerCount = 0;
        AutoCompleteStringCollection colValues;

        #endregion

        #region Form Events

        /// <summary>
        /// On form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAccount_Load(object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SplitterPanel panel1 = splitContainer.Panel1;
                SplitterPanel panel2 = splitContainer.Panel2;
                splitContainer.Panel1MinSize = this.Width * 20 / 100;
                splitContainer.Panel2MinSize = this.Width * 60 / 100;
                BindAccountGroup();
                BindAccountTreeView();
                ClearFields();
                RefreshButtons();
                colValues = new AutoCompleteStringCollection();
                txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                DataTable dtSource = AccountBLL.GetAccountNames(txtSearch.Text.Trim());
                foreach (DataRow item in dtSource.Rows)
                {
                    colValues.Add(item["AccountName"].ToString());
                }
                txtSearch.AutoCompleteCustomSource = colValues;
            }
            catch (Exception ex)
            {
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
        private void frmAccount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    switch (splitContainer.ActiveControl.Name)
                    {
                        case "tvwAccount":
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
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// To bind account groups
        /// </summary>
        private void BindAccountGroup()
        {
            try
            {
                cboAccountGroup.Nodes.Clear();
                DataTable dtAccountGroups = AccountBLL.GetAccountGroups();
                cboAccountGroup.Nodes.Add("", "Select account parent", 0).Tag = 0;
                if (dtAccountGroups.Rows.Count > 0)
                {
                    IEnumerable<DataRow> drAccountGroup = from r in dtAccountGroups.AsEnumerable() where r.Field<int>("AccountParent") == 0 select (r);
                    DataTable dtPrimaryGroups = drAccountGroup.CopyToDataTable<DataRow>();
                    if (dtPrimaryGroups.Rows.Count > 0)
                    {
                        foreach (DataRow drPrimaryGroups in dtPrimaryGroups.Rows)
                        {
                            ComboTreeNode parent = cboAccountGroup.Nodes.Add("G" + drPrimaryGroups["AccountID"].ToString(), drPrimaryGroups["AccountName"].ToString(), 2);
                            parent.Tag = Convert.ToInt32(drPrimaryGroups["AccountID"]);
                            BindSubAccountGroups(parent, Convert.ToInt32(drPrimaryGroups["AccountID"]), ref dtAccountGroups);
                        }
                    }
                    dtPrimaryGroups.Dispose();
                    dtAccountGroups.Dispose();
                }
                cboAccountGroup.ExpandAll();
                cboAccountGroup.SelectedNode = cboAccountGroup.Nodes[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To bind sub account groups under the parent node
        /// </summary>
        /// <param name="parent">Parent node</param>
        /// <param name="parentId">Account parent id</param>
        private void BindSubAccountGroups(ComboTreeNode parent, int parentId, ref DataTable dtAccountGroups)
        {
            try
            {
                IEnumerable<DataRow> drAccountGroup = from r in dtAccountGroups.AsEnumerable() where r.Field<int>("AccountParent") == parentId select (r);
                if (drAccountGroup.Count() > 0)
                {
                    DataTable dtPrimaryGroups = drAccountGroup.CopyToDataTable<DataRow>();
                    if (dtPrimaryGroups.Rows.Count > 0)
                    {
                        foreach (DataRow drPrimaryGroups in dtPrimaryGroups.Rows)
                        {
                            ComboTreeNode subParent = parent.Nodes.Add("G" + drPrimaryGroups["AccountID"].ToString(), drPrimaryGroups["AccountName"].ToString(), 2);
                            subParent.Tag = Convert.ToInt32(drPrimaryGroups["AccountID"]);
                            BindSubAccountGroups(subParent, Convert.ToInt32(drPrimaryGroups["AccountID"]), ref dtAccountGroups);
                        }
                    }
                    dtPrimaryGroups.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// For clearing controls in the form
        /// </summary>
        private void ClearFields()
        {
            try
            {
                txtAccountName.Text = string.Empty;
                txtAccountName.Tag = "0";
                txtSearch.Text = string.Empty;
                cboAccountGroup.SelectedNode = cboAccountGroup.Nodes[0];
                cboAccountGroup.Tag = "0";
                txtOpening.Text = "0.00";
                cboOpeningType.SelectedIndex = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To bind account tree view
        /// </summary>
        private void BindAccountTreeView()
        {
            try
            {
                TreeNode rootNode = tvwAccount.Nodes.Add("0", "Account Groups & Ledgers", 0);
                rootNode.Tag = 0;
                DataTable dtAccounts = AccountBLL.GetAccounts(-1, -1);
                if (dtAccounts.Rows.Count > 0)
                {
                    IEnumerable<DataRow> drAccountGroup = from r in dtAccounts.AsEnumerable() where r.Field<int>("AccountParent") == 0 select (r);
                    DataTable dtPrimaryGroups = drAccountGroup.CopyToDataTable<DataRow>();
                    if (dtPrimaryGroups.Rows.Count > 0)
                    {
                        foreach (DataRow drPrimaryGroups in dtPrimaryGroups.Rows)
                        {
                            TreeNode parent = rootNode.Nodes.Add((Convert.ToBoolean(drPrimaryGroups["IsAccountLedger"]) ? "A" : "G") + drPrimaryGroups["AccountID"], drPrimaryGroups["AccountName"].ToString(), Convert.ToBoolean(drPrimaryGroups["IsAccountLedger"]) ? 3 : 1);
                            parent.Tag = Convert.ToInt32(drPrimaryGroups["AccountID"]);
                            BindAccountLedgerTreeView(parent, Convert.ToInt32(drPrimaryGroups["AccountID"]), ref dtAccounts);
                        }
                    }
                    dtPrimaryGroups.Dispose();
                    dtAccounts.Dispose();
                    IEnumerable<DataRow> drAccountGroupCount = from r in dtAccounts.AsEnumerable() where r.Field<bool>("IsAccountLedger") == true select (r);
                    accountLedgerCount = drAccountGroupCount.Count();
                    accountGroupCount = dtAccounts.Rows.Count - accountLedgerCount;
                }
                tvwAccount.ExpandAll();
                tvwAccount.Select();
                lblAccountCount.Text = accountLedgerCount + " Account(s) defined under " + accountGroupCount + " groups";
                tvwAccount.SelectedNode = tvwAccount.Nodes[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To bind ledger account under account parent
        /// </summary>
        /// <param name="parent">Account group node</param>
        /// <param name="parentId">Account group id</param>
        /// <param name="dtAccounts">Accounts details</param>
        private void BindAccountLedgerTreeView(TreeNode parent, int parentId, ref DataTable dtAccounts)
        {
            try
            {
                IEnumerable<DataRow> drAccountLedger = from r in dtAccounts.AsEnumerable() where r.Field<int>("AccountParent") == parentId select (r);
                if (drAccountLedger.Count() > 0)
                {
                    DataTable dtAccountLedger = drAccountLedger.CopyToDataTable<DataRow>();
                    if (dtAccountLedger.Rows.Count > 0)
                    {
                        foreach (DataRow drLedger in dtAccountLedger.Rows)
                        {
                            TreeNode ledgerNode = parent.Nodes.Add((Convert.ToBoolean(drLedger["IsAccountLedger"]) ? "A" : "G") + drLedger["AccountID"], drLedger["AccountName"].ToString(), Convert.ToBoolean(drLedger["IsAccountLedger"]) ? 3 : 1);
                            ledgerNode.Tag = Convert.ToInt32(drLedger["AccountID"]);
                            BindAccountLedgerTreeView(ledgerNode, Convert.ToInt32(drLedger["AccountID"]), ref dtAccounts);
                        }
                    }
                    dtAccountLedger.Dispose();
                }
            }
            catch (Exception)
            {
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
                        tvwAccount.Focus();
                        string search = txtSearch.Text;
                        tvwAccount.SelectedNode = nodeStart;
                        currentSearchResultNode = nodeStart;
                        txtSearch.Text = search;
                        // Setting the focus and text for search when the selection comes to the root node
                        if (string.Compare(tvwAccount.SelectedNode.Name, "0", true) == 0)
                        {
                            btnSearch.Focus();
                            tvwAccount.Select();
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
                        SearchNodes(tvwAccount.Nodes[0]);
                    }
                    else
                    {
                        txtSearch.Clear();
                        tvwAccount.SelectedNode = tvwAccount.Nodes[0];
                        currentSearchResultNode = null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
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
                    tipAccount.SetToolTip(btnNew, "Click here to save account details");
                    btnModify.Text = "&Cancel";
                    tipAccount.SetToolTip(btnModify, "Click here to cancel");
                    btnClose.Enabled = false;
                    btnDelete.Enabled = false;
                    btnModify.Enabled = true;
                    txtAccountName.Enabled = true;
                    tvwAccount.Enabled = false;
                    gbxSearch.Enabled = false;
                    gbxType.Enabled = true;
                    cboAccountGroup.Enabled = true;
                    radAccount.Enabled = false;
                    radAccountGroup.Enabled = false;
                    txtOpening.Enabled = true;
                    cboOpeningType.Enabled = true;
                    txtAccountName.Focus();
                    if (blnAddMode)
                    {
                        radAccount.Enabled = true;
                        radAccountGroup.Enabled = true;
                        radAccount.Checked = false;
                        radAccountGroup.Checked = true;
                        cboAccountGroup.Enabled = true;
                        radAccountGroup.Focus();
                    }
                }
                else
                {
                    btnNew.Text = "&New";
                    tipAccount.SetToolTip(btnNew, "Click here to create new account");
                    btnModify.Text = "&Modify";
                    tipAccount.SetToolTip(btnModify, "Click here to modify the account");
                    txtAccountName.Enabled = false;
                    tvwAccount.Enabled = true;
                    gbxSearch.Enabled = true;
                    gbxType.Enabled = false;
                    cboAccountGroup.Enabled = false;
                    radAccount.Enabled = false;
                    radAccountGroup.Enabled = false;
                    btnDelete.Enabled = true;
                    btnClose.Enabled = true;
                    txtOpening.Enabled = false;
                    cboOpeningType.Enabled = false;
                    if (string.Compare(tvwAccount.SelectedNode.Name, "0", true) == 0)
                    {
                        btnDelete.Enabled = false;
                        btnModify.Enabled = false;
                        radAccount.Checked = false;
                        radAccountGroup.Checked = false;
                    }
                    tvwAccount.Select();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// For setting account details to the controls
        /// </summary>
        private void SetAccountDetailsToControls()
        {
            try
            {
                // Calling business method for getting account details by account id
                DataTable dtAccounts = AccountBLL.GetAccountDetailsByAccountId(Convert.ToInt32(tvwAccount.SelectedNode.Tag), Convert.ToInt32(ActiveUserSession.FYearId));
                if (dtAccounts.Rows.Count > 0)
                {
                    txtAccountName.Text = dtAccounts.Rows[0]["AccountName"].ToString().Trim();
                    txtAccountName.Tag = Convert.ToInt32(dtAccounts.Rows[0]["AccountID"]);
                    cboAccountGroup.Tag = dtAccounts.Rows[0]["AccountParent"].ToString();
                    cboAccountGroup.SelectedNode = cboAccountGroup.Nodes.FindNode("G" + dtAccounts.Rows[0]["AccountParent"].ToString(), true);
                    txtOpening.Text = Convert.ToDecimal(dtAccounts.Rows[0]["Opening"]).ToString("F");
                    cboOpeningType.SelectedIndex = Convert.ToBoolean(dtAccounts.Rows[0]["OpeningType"].ToString()) ? 1 : 0;
                    // Checking the account type
                    if (Convert.ToBoolean(dtAccounts.Rows[0]["IsAccountLedger"]))
                    {
                        radAccount.Checked = true;
                        radAccountGroup.Checked = false;
                    }
                    else
                    {
                        radAccount.Checked = false;
                        radAccountGroup.Checked = true;
                    }

                }
                else
                {
                    ClearFields();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Tree View Events

        /// <summary>
        /// Before tree view item slected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwAccount_BeforeSelect(object sender, TreeViewCancelEventArgs e)
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
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// After tree view item selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvwAccount_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                txtAccountName.Tag = e.Node.Tag;
                if (string.Compare(tvwAccount.SelectedNode.Name, "0", true) == 0)
                {
                    // For clearing controls in the form
                    ClearFields();
                    radAccountGroup.Checked = false;
                    radAccountGroup.Checked = false;
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
                        SetAccountDetailsToControls();
                    }
                }
            }
            catch (Exception ex)
            {
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
                tvwAccount.ExpandAll();
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
                    SearchNodes(tvwAccount.Nodes[0]);
                }
                else
                {
                    if (currentSearchResultNode.NextVisibleNode == null)
                    {
                        if (Messages.ShowConfirmation("The search has reached the end of list.\n Do you want to search from the beginning?"))
                        {
                            SearchNodes(tvwAccount.Nodes[0]);
                        }
                        else
                        {
                            txtSearch.Focus();
                            txtSearch.SelectAll();
                            tvwAccount.SelectedNode = tvwAccount.Nodes[0];
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
                Messages.ShowExceptionMessage(ref ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
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
                    if (txtAccountName.Text.Trim().Length == 0)
                    {
                        Messages.ShowInformationMessage("Please enter account " + (radAccountGroup.Checked ? "group " : string.Empty) + " name.");
                        txtAccountName.Focus();
                        return;
                    }
                    if (AccountBLL.CheckDuplicateAccountName(Convert.ToInt32(txtAccountName.Tag), txtAccountName.Text.Trim()) > 0)
                    {
                        Messages.ShowInformationMessage("Another account exist with the given name. Please check the account name.");
                        txtAccountName.Focus();
                        return;
                    }
                    if (radAccount.Checked && Convert.ToInt32(cboAccountGroup.SelectedNode.Tag) == 0)
                    {
                        Messages.ShowInformationMessage("Invalid account group selection. Please select valid account group.");
                        cboAccountGroup.Focus();
                        cboAccountGroup.DroppedDown = true;
                        return;
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    // Setting department details to the object
                    Account account = new Account();
                    account.AccountId = Convert.ToInt32(txtAccountName.Tag);
                    account.AccountName = txtAccountName.Text.Trim();
                    account.AccountParent = Convert.ToInt32(cboAccountGroup.SelectedNode.Tag);
                    account.IsAccountLedger = radAccount.Checked;
                    account.Opening = Convert.ToDecimal(txtOpening.Text);
                    account.OpeningType = cboOpeningType.SelectedIndex == 1;
                    account.FYearId = ActiveUserSession.FYearId;
                    if (blnAddMode)
                    {
                        account.IsInsertUpdateDelete = InsertUpdateDeleteMode.InsertMode;
                        int accountId = AccountBLL.InsertUpdateAccountDetails(ref account);
                        GeneralBLL.InsertEventLog("New account " + (radAccountGroup.Checked ? "group " : "ledger ") + "[" + txtAccountName.Text + "] created.", EventLogType.Account, EventLogMode.Insert, accountId);
                        tvwAccount.ExpandAll();
                        if (radAccountGroup.Checked)
                        {
                            TreeNode newNode = tvwAccount.Nodes.Find("G" + cboAccountGroup.SelectedNode.Tag.ToString(), true)[0].Nodes.Add("G" + accountId.ToString(), txtAccountName.Text.Trim(), 1);
                            newNode.Tag = accountId;
                            tvwAccount.SelectedNode = newNode;
                            accountGroupCount++;
                        }
                        else
                        {
                            TreeNode newNode = tvwAccount.Nodes.Find("G" + cboAccountGroup.SelectedNode.Tag.ToString(), true)[0].Nodes.Add("A" + accountId.ToString(), txtAccountName.Text.Trim(), 3);
                            newNode.Tag = accountId;
                            tvwAccount.SelectedNode = newNode;
                            accountLedgerCount++;
                        }
                        lblAccountCount.Text = accountLedgerCount + " Account(s) defined under " + accountGroupCount + " groups";
                        Messages.ShowInformationMessage("Account " + (radAccountGroup.Checked ? "group " : "ledger ") + "[" + txtAccountName.Text + "] created successfully.");
                    }
                    else
                    {
                        if (Convert.ToInt32(txtAccountName.Tag) == Convert.ToInt32(cboAccountGroup.SelectedNode.Tag))
                        {
                            Messages.ShowInformationMessage("Invalid account group selection. Please select valid account group.");
                            cboAccountGroup.Focus();
                            cboAccountGroup.DroppedDown = true;
                            return;
                        }
                        account.IsInsertUpdateDelete = InsertUpdateDeleteMode.UpdateMode;
                        int accountId = AccountBLL.InsertUpdateAccountDetails(ref account);
                        GeneralBLL.InsertEventLog("Account " + (radAccountGroup.Checked ? "group " : "ledger ") + "[" + txtAccountName.Text + "] updated.", EventLogType.Account, EventLogMode.Update, Convert.ToInt32(txtAccountName.Tag));
                        if (Convert.ToInt32(cboAccountGroup.Tag) == Convert.ToInt32(cboAccountGroup.SelectedNode.Tag))
                        {
                            tvwAccount.SelectedNode.Text = txtAccountName.Text.Trim();
                        }
                        else
                        {
                            tvwAccount.SelectedNode.Remove();
                            tvwAccount.ExpandAll();
                            if (radAccountGroup.Checked)
                            {
                                TreeNode newNode = tvwAccount.Nodes.Find("G" + cboAccountGroup.SelectedNode.Tag.ToString(), true)[0].Nodes.Add("G" + accountId.ToString(), txtAccountName.Text.Trim(), 1);
                                newNode.Tag = accountId;
                                tvwAccount.SelectedNode = newNode;
                            }
                            else
                            {
                                TreeNode newNode = tvwAccount.Nodes.Find("G" + cboAccountGroup.SelectedNode.Tag.ToString(), true)[0].Nodes.Add("A" + accountId.ToString(), txtAccountName.Text.Trim(), 3);
                                newNode.Tag = accountId;
                                tvwAccount.SelectedNode = newNode;
                            }
                        }
                        Messages.ShowInformationMessage("Account " + (radAccountGroup.Checked ? "group " : "ledger ") + "[" + txtAccountName.Text + "] updated successfully.");
                    }
                    blnAddMode = false;
                    blnEditMode = false;
                    BindAccountGroup();
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
                Messages.ShowExceptionMessage(ref ex);
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
                    if (string.Compare(tvwAccount.SelectedNode.Name, "0", true) == 0)
                    {
                        ClearFields();
                    }
                    blnEditMode = false;

                    if (blnAddMode)
                    {
                        blnAddMode = false;
                    }
                }
                else
                {
                    blnEditMode = true;
                }
                // Refreshing buttons in the form according to various modes
                RefreshButtons();
                if (string.Compare(tvwAccount.SelectedNode.Name, "0", true) == 0)
                {
                    btnDelete.Enabled = false;
                    btnModify.Enabled = false;
                    radAccountGroup.Checked = false;
                    radAccount.Checked = false;
                    cboAccountGroup.SelectedNode = cboAccountGroup.Nodes[0];
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

        #region Radio Button Events

        /// <summary>
        /// Account group type selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radAccountGroup_Click(object sender, EventArgs e)
        {
            try
            {
                radAccount.Checked = false;
                txtOpening.Text = "0.00";
                txtOpening.Enabled = false;
                cboAccountGroup.SelectedNode = cboAccountGroup.Nodes[0];
                cboAccountGroup.Enabled = false;
                cboOpeningType.SelectedIndex = 0;
                cboOpeningType.Enabled = false;
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// Account type selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radAccount_Click(object sender, EventArgs e)
        {
            try
            {
                radAccountGroup.Checked = false;
                txtOpening.Text = "0.00";
                txtOpening.Enabled = true;
                cboAccountGroup.Enabled = true;
                cboOpeningType.Enabled = true;
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion
    }
}
