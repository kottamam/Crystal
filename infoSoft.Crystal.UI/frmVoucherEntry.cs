#region Copyright

// ©Copyright 2015, tv Software Private Limited,  All rights reserved.

#endregion Copyright

#region Code history

// Created On   : 04.07.2015
// Created By   : Noble
// Description  : Screen for voucher entry
// -----------------------------------------//
// Modified By  : 
// Modified Date: 
// Description  : 

#endregion Code history

#region Using directives

using tv.Crystal.Business;
using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Models;
using tv.Crystal.UI.CustomControls;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using tv.Crystal.Common.Models.Properties;

#endregion

namespace tv.Crystal.UI
{
    public partial class frmVoucherEntry : tv.Crystal.UI.CustomControls.BaseForm
    {
        #region Constructor

        public frmVoucherEntry()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Variables

        VoucherType selectedVoucherType;
        DataTable dtAccountSuggetions;
        DataTable dtAccountGridSuggetions;
        DataTable dtCurrency;
        VoucherEntry.UserAccessRights userAccessRight;

        private enum GridColsVoucherDetails
        {
            SlNo,
            Check,
            DetailsId,
            MasterId,
            PostingAccountId,
            AccountId,
            AccountName,
            Amount,
            Currency,
            Narration,
            ChequeNo,
            ChequeDate
        }

        #endregion

        #region Popup

        PopupControl popupControl = new PopupControl();   //Object for usercontrol
        DataTable dtPopup = new DataTable();
        private nPopup popup;                                     //Popup object.

        #endregion

        #region Popup Methods

        /// <summary>
        /// click event for controls in popup user control
        /// </summary>
        public void PopupControl()
        {
            try
            {
                foreach (Control control in popupControl.Controls["pnlButtons"].Controls.OfType<Button>())
                {
                    control.Click += new EventHandler(PopupControl_Click);
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// click event for controls in popup user control
        /// </summary>
        public void PopupControl_Click(object sender, EventArgs e)
        {
            try
            {
                string ControlName = ((Control)sender).Name;
                switch (ControlName)
                {
                    case "btnSelect":
                        if (splitContainer.ActiveControl == txtPrimaryAccount)
                        {
                            splitContainer.ActiveControl.Focus();
                            txtPrimaryAccount.Text = popupControl.SelectedItem[1].ToString();
                            txtPrimaryAccount.Tag = new TagObject() { ObjectId = Convert.ToInt32(popupControl.SelectedItem[0]), ObjectName = popupControl.SelectedItem[1].ToString() };
                            dgvVoucherDetails.CurrentCell = dgvVoucherDetails[(int)GridColsVoucherDetails.AccountName, dgvVoucherDetails.RowCount - 1];
                            dgvVoucherDetails.Focus();
                        }
                        else if (splitContainer.ActiveControl == dgvVoucherDetails && dgvVoucherDetails.CurrentCell.ColumnIndex == (int)GridColsVoucherDetails.AccountName)
                        {
                            splitContainer.ActiveControl.Focus();
                            dgvVoucherDetails.EndEdit(DataGridViewDataErrorContexts.Commit);
                            dgvVoucherDetails[(int)GridColsVoucherDetails.AccountName, dgvVoucherDetails.CurrentRow.Index].Value = popupControl.SelectedItem[1];
                            dgvVoucherDetails[(int)GridColsVoucherDetails.AccountName, dgvVoucherDetails.CurrentRow.Index].Tag = popupControl.SelectedItem[1];
                            dgvVoucherDetails[(int)GridColsVoucherDetails.AccountId, dgvVoucherDetails.CurrentRow.Index].Value = popupControl.SelectedItem[0];
                            dgvVoucherDetails.CurrentCell = dgvVoucherDetails[(int)GridColsVoucherDetails.Amount, dgvVoucherDetails.CurrentRow.Index];
                        }
                        this.Activate(); // Close user control and activate main form							
                        break;
                    case "btnCancel":
                        splitContainer.ActiveControl.Focus();
                        if (splitContainer.ActiveControl.GetType() == typeof(TextBox))
                        {
                            ((TextBox)splitContainer.ActiveControl).SelectAll();
                        }
                        this.Activate(); // Close user control and activate main form					
                        break;
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

        #region Form Events

        /// <summary>
        /// On form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmVoucherEntry_Load(object sender, EventArgs e)
        {
            try
            {
                SplitterPanel panel1 = splitContainer.Panel1;
                SplitterPanel panel2 = splitContainer.Panel2;
                splitContainer.Panel1MinSize = this.Width * 15 / 100;
                splitContainer.Panel2MinSize = this.Width * 70 / 100;
                PopupControl();
                userAccessRight = new VoucherEntry.UserAccessRights();
                SetUserPrivileges();
                RePostionControls();
                SetGrid();
                ClearFileds();
                SetControls(VoucherType.Contra_Voucher);
                txtVoucherDate.RangeValidate = true;
                txtVoucherDate.RangeFrom = ActiveUserSession.FYearStart.Date;
                txtVoucherDate.RangeTo = ActiveUserSession.FYearClose.Date;
                mcVoucherDate.MinDate = ActiveUserSession.FYearStart.Date;
                mcVoucherDate.MaxDate = ActiveUserSession.FYearClose.Date;
                BindBankAndCashSuggestionForPrimaryAccount();
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

        private void frmVoucherEntry_Click(object sender, EventArgs e)
        {
            try
            {
                mcVoucherDate.Visible = false;
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void frmVoucherEntry_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (splitContainer.ActiveControl == txtPrimaryAccount)
                    {
                        DataTable dtAccounts = AccountBLL.GetBankCashAccountsByAccountName(txtPrimaryAccount.Text.Trim());
                        if (dtAccounts.Rows.Count > 0)
                        {
                            int[] sizeArray = new int[2];
                            sizeArray[0] = 0;
                            sizeArray[1] = 515;
                            popup = new nPopup(popupControl, splitContainer.ActiveControl);
                            //PopupControl();
                            if (dtAccounts.Rows.Count == 1)
                            {
                                txtPrimaryAccount.Text = dtAccounts.Rows[0].ItemArray[1].ToString();
                                txtPrimaryAccount.Tag = new TagObject() { ObjectId = Convert.ToInt32(dtAccounts.Rows[0].ItemArray[0]), ObjectName = dtAccounts.Rows[0].ItemArray[1].ToString() };
                                dgvVoucherDetails.CurrentCell = dgvVoucherDetails[(int)GridColsVoucherDetails.AccountName, dgvVoucherDetails.RowCount - 1];
                                dgvVoucherDetails.Focus();
                            }
                            else
                            {
                                dtAccounts.Columns["AccountName"].ColumnName = "Account Name"; //Space between sub heading AccountName of pop up
                                popupControl.FillPopup(dtAccounts, sizeArray, "Accounts"); //For filling popup								
                                popup.Show();		                                       //To show popup
                            }
                        }
                        else
                        {
                            Messages.ShowInformationMessage("Accounts not defined.");
                            e.Handled = true;
                            return;
                        }
                    }
                    else if (splitContainer.ActiveControl != null && splitContainer.ActiveControl != dgvVoucherDetails && splitContainer.ActiveControl != rtbNarration)
                    {
                        SelectNextControl(splitContainer.ActiveControl, true, true, true, true);
                    }
                    else if (splitContainer.ActiveControl == rtbNarration && Control.ModifierKeys == Keys.Control)
                    {
                        SelectNextControl(splitContainer.ActiveControl, true, true, true, true);
                    }
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
        /// To set controls according to the entry type
        /// </summary>
        /// <param name="entryType">Entry type</param>
        private void SetControls(VoucherType entryType)
        {
            try
            {
                if (CheckIsFreshForm())
                {
                    selectedVoucherType = entryType;
                    SetGrid();
                    ClearFileds();
                    if (entryType == VoucherType.Contra_Voucher)          //Contra entry
                    {
                        this.btnContra.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                        this.btnReceipt.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        this.btnPayment.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        this.btnJournal.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        lblVoucherDescriptionTitle.Text = "Contra Entry";
                        lblVoucherDescriptionDetails.Text = "Contra entry is an adjustment entry between banker and customer. When we do transaction by cash or we transfer balance from one bank a/c to another bank a/c is called contra entry.";

                        radDeposit.Visible = true;
                        radWithdrawal.Visible = true;

                        dtAccountSuggetions = AccountBLL.GetBankCashAccounts();
                        dtAccountGridSuggetions = dtAccountSuggetions.Copy();
                        BindBankAndCashSuggestionForPrimaryAccount();
                        radDeposit.Focus();
                    }
                    else if (entryType == VoucherType.Receipt_Voucher)    //Receipt entry
                    {
                        this.btnContra.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        this.btnReceipt.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                        this.btnPayment.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        this.btnJournal.BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        lblVoucherDescriptionTitle.Text = "Receipt Entry";
                        lblVoucherDescriptionDetails.Text = "Any money received from debtors against sales invoices or on Account and for all transactions where money is received are accounted or entered using the Receipt Voucher.";

                        radDeposit.Visible = false;
                        radWithdrawal.Visible = false;

                        dtAccountSuggetions = AccountBLL.GetBankCashAccounts();
                        dtAccountGridSuggetions = AccountBLL.GetAccountsByAccountName(string.Empty);
                        txtPrimaryAccount.Focus();
                    }
                    else if (entryType == VoucherType.Payment_Voucher)    //Payment entry
                    {
                        this.btnContra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        this.btnReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                        this.btnJournal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        lblVoucherDescriptionTitle.Text = "Payment Entry";
                        lblVoucherDescriptionDetails.Text = "Any paid to creditors aginst purchase bills or any type of bill settlment against bills are considered as payment entry.";
                    }
                    else                        //Journal entry
                    {
                        this.btnContra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        this.btnReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        this.btnJournal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                        lblVoucherDescriptionTitle.Text = "Journal Entry";
                        lblVoucherDescriptionDetails.Text = "Journal entry is an entry to the journal and it is an adjustment entry.";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To re-position the controls
        /// </summary>
        private void RePostionControls()
        {
            try
            {
                lblCreditTotal.Top = txtCreditTotal.Top;
                btnAddAccount.Top = txtPrimaryAccount.Top;
                btnSelectDate.Top = txtVoucherDate.Top - 4;
                lblRemove.TabStop = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To bing currency combo in grid
        /// </summary>
        private void BindCurrencyInGrid()
        {
            try
            {
                if (userAccessRight.MultipleCurrencyAllowed)
                {
                    dtCurrency = AccountBLL.GetCurrencyApplicableOnDate(Convert.ToDateTime(txtVoucherDate.Tag));
                }
                else
                {
                    dtCurrency = (from r in AccountBLL.GetCurrencyApplicableOnDate(Convert.ToDateTime(txtVoucherDate.Tag)).AsEnumerable() where r.Field<int>("ExchangeRateID") == 1 select (r)).CopyToDataTable<DataRow>();
                }
                DataRow dtRowCurrency = dtCurrency.NewRow();
                dtRowCurrency["CurrencyName"] = string.Empty;
                dtRowCurrency["ExchangeRateID"] = -1;
                dtRowCurrency["ExchangeRate"] = 0.00M;
                dtCurrency.Rows.InsertAt(dtRowCurrency, 0);
                DataGridViewComboBoxColumn colVoucherCurrency = (DataGridViewComboBoxColumn)dgvVoucherDetails.Columns["colVoucherCurrency"];
                colVoucherCurrency.DataSource = dtCurrency;
                colVoucherCurrency.DisplayMember = "CurrencyName";
                colVoucherCurrency.ValueMember = "ExchangeRateID";
                CalculateNetAmount();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To bind bank and cash accounts as suggetions for primary acoount filed
        /// </summary>
        private void BindBankAndCashSuggestionForPrimaryAccount()
        {
            try
            {
                if (selectedVoucherType == VoucherType.Contra_Voucher || selectedVoucherType == VoucherType.Receipt_Voucher)
                {
                    AutoCompleteStringCollection autoCompleteBankAndCash = new AutoCompleteStringCollection();
                    txtPrimaryAccount.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txtPrimaryAccount.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    foreach (DataRow item in dtAccountSuggetions.Rows)
                    {
                        autoCompleteBankAndCash.Add(item["AccountName"].ToString());
                    }
                    txtPrimaryAccount.AutoCompleteCustomSource = autoCompleteBankAndCash;
                    errProvider.SetError(txtPrimaryAccount, "test");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To set the voucher entry details grid
        /// </summary>
        private void SetGrid()
        {
            try
            {
                dgvVoucherDetails.Rows.Clear();
                dgvVoucherDetails.Columns.Clear();

                // Creating Sl no column and adding into voucher details grid
                DataGridViewTextBoxColumn colVoucherSlNo = new DataGridViewTextBoxColumn();
                colVoucherSlNo.Name = "colVoucherSlNo";
                colVoucherSlNo.HeaderText = "Sl No";
                colVoucherSlNo.MinimumWidth = 20;
                colVoucherSlNo.FillWeight = 40;
                colVoucherSlNo.ReadOnly = true;
                colVoucherSlNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherSlNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherSlNo.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating check column and adding into voucher details grid
                DataGridViewTextBoxColumn colVoucherCheck = new DataGridViewTextBoxColumn();
                colVoucherCheck.Name = "colVoucherCheck";
                colVoucherCheck.HeaderText = "Check";
                colVoucherCheck.ReadOnly = true;
                colVoucherCheck.Visible = false;
                colVoucherCheck.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherCheck.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherCheck.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating details id column and adding into voucher details grid
                DataGridViewTextBoxColumn colVoucherDetailsId = new DataGridViewTextBoxColumn();
                colVoucherDetailsId.Name = "colVoucherDetailsId";
                colVoucherDetailsId.HeaderText = "Details id";
                colVoucherDetailsId.ReadOnly = true;
                colVoucherDetailsId.Visible = false;
                colVoucherDetailsId.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherDetailsId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherDetailsId.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating master id column and adding into voucher details grid
                DataGridViewTextBoxColumn colVoucherMasterId = new DataGridViewTextBoxColumn();
                colVoucherMasterId.Name = "colVoucherMasterId";
                colVoucherMasterId.HeaderText = "Master id";
                colVoucherMasterId.ReadOnly = true;
                colVoucherMasterId.Visible = false;
                colVoucherMasterId.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherMasterId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherMasterId.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating posting id column and adding into voucher details grid
                DataGridViewTextBoxColumn colVoucherPostingAccountId = new DataGridViewTextBoxColumn();
                colVoucherPostingAccountId.Name = "colVoucherPostingAccountId";
                colVoucherPostingAccountId.HeaderText = "Posting account id";
                colVoucherPostingAccountId.ReadOnly = true;
                colVoucherPostingAccountId.Visible = false;
                colVoucherPostingAccountId.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherPostingAccountId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherPostingAccountId.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating account id column and adding into voucher details grid
                DataGridViewTextBoxColumn colVoucherAccountId = new DataGridViewTextBoxColumn();
                colVoucherAccountId.Name = "colVoucherAccountId";
                colVoucherAccountId.HeaderText = "Account id";
                colVoucherAccountId.ReadOnly = true;
                colVoucherAccountId.Visible = false;
                colVoucherAccountId.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherAccountId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherAccountId.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating Account name column and adding into voucher details grid
                nDataGridViewTextBoxColumn colVoucherAccountName = new nDataGridViewTextBoxColumn();
                colVoucherAccountName.Name = "colVoucherAccountName";
                colVoucherAccountName.HeaderText = "Ledger Name";
                colVoucherAccountName.MinimumWidth = 250;
                colVoucherAccountName.FillWeight = 350;
                colVoucherAccountName.ReadOnly = false;
                colVoucherAccountName.MaxInputLength = 50;
                colVoucherAccountName.CellContentType = CellContentType.String;
                colVoucherAccountName.IsPopupColumn = true;
                colVoucherAccountName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherAccountName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherAccountName.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating amount column and adding into voucher details grid
                nDataGridViewTextBoxColumn colVoucherAmount = new nDataGridViewTextBoxColumn();
                colVoucherAmount.Name = "colVoucherAmount";
                colVoucherAmount.HeaderText = "Amount";
                colVoucherAmount.MinimumWidth = 100;
                colVoucherAmount.FillWeight = 120;
                colVoucherAmount.ReadOnly = false;
                colVoucherAmount.CellContentType = CellContentType.Amount;
                colVoucherAmount.MaxInputLength = 12;
                colVoucherAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colVoucherAmount.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating currency column and adding into voucher details grid
                DataGridViewComboBoxColumn colVoucherCurrency = new DataGridViewComboBoxColumn();
                colVoucherCurrency.Name = "colVoucherCurrency";
                colVoucherCurrency.HeaderText = "Currency";
                colVoucherCurrency.MinimumWidth = 60;
                colVoucherCurrency.FillWeight = 90;
                colVoucherCurrency.ReadOnly = false;
                colVoucherCurrency.DataPropertyName = "ExchangeRateID";
                colVoucherCurrency.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherCurrency.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherCurrency.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating narration column and adding into voucher details grid
                DataGridViewTextBoxColumn colVoucherNarration = new DataGridViewTextBoxColumn();
                colVoucherNarration.Name = "colVoucherNarration";
                colVoucherNarration.HeaderText = "Narration";
                colVoucherNarration.MinimumWidth = 100;
                colVoucherNarration.FillWeight = 200;
                colVoucherNarration.ReadOnly = false;
                colVoucherNarration.MaxInputLength = 100;
                colVoucherNarration.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherNarration.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherNarration.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating cheque no column and adding into voucher details grid
                DataGridViewTextBoxColumn colVoucherChequeNo = new DataGridViewTextBoxColumn();
                colVoucherChequeNo.Name = "colVoucherChequeNo";
                colVoucherChequeNo.HeaderText = "Cheque No";
                colVoucherChequeNo.MinimumWidth = 80;
                colVoucherChequeNo.FillWeight = 100;
                colVoucherChequeNo.ReadOnly = false;
                colVoucherChequeNo.MaxInputLength = 12;
                colVoucherChequeNo.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherChequeNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherChequeNo.SortMode = DataGridViewColumnSortMode.NotSortable;

                // Creating cheque date column and adding into voucher details grid
                nDataGridViewTextBoxColumn colVoucherChequeDate = new nDataGridViewTextBoxColumn();
                colVoucherChequeDate.Name = "colVoucherChequeDate";
                colVoucherChequeDate.HeaderText = "Cheque Date";
                colVoucherChequeDate.MinimumWidth = 80;
                colVoucherChequeDate.FillWeight = 100;
                colVoucherChequeDate.ReadOnly = false;
                colVoucherChequeDate.CellContentType = CellContentType.Date;
                colVoucherChequeDate.RangeValidate = true;
                colVoucherChequeDate.RangeFrom = ActiveUserSession.FYearStart;
                colVoucherChequeDate.RangeTo = ActiveUserSession.FYearClose;
                colVoucherChequeDate.MaxInputLength = 11;
                colVoucherChequeDate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherChequeDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoucherChequeDate.SortMode = DataGridViewColumnSortMode.NotSortable;

                dgvVoucherDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                                                                                                colVoucherSlNo,
                                                                                                colVoucherCheck,
                                                                                                colVoucherDetailsId,
                                                                                                colVoucherMasterId,
                                                                                                colVoucherPostingAccountId,
                                                                                                colVoucherAccountId,
                                                                                                colVoucherAccountName,
                                                                                                colVoucherAmount,
                                                                                                colVoucherCurrency,
                                                                                                colVoucherNarration,
                                                                                                colVoucherChequeNo,
                                                                                                colVoucherChequeDate});
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// generate the serial no for the grid here
        /// </summary>
        private void GenerateSlNo()
        {
            try
            {
                int rowNo = 1;
                foreach (DataGridViewRow row in dgvVoucherDetails.Rows)
                {
                    row.Cells["colVoucherSlNo"].Value = rowNo;
                    rowNo++;
                    if (row.Index == dgvVoucherDetails.Rows.Count - 1)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// To clear and re initialize control
        /// </summary>
        private void ClearFileds()
        {
            try
            {
                ActiveUserSession.ServerDateTime = GeneralBLL.GetServerDateAndTime();
                txtVoucherDate.Text = ActiveUserSession.ServerDateTime.ToString("dd/MMM/yyyy");
                txtVoucherDate.Tag = ActiveUserSession.ServerDateTime.ToShortDateString();
                mcVoucherDate.SelectionStart = ActiveUserSession.ServerDateTime.Date;
                radDeposit.Checked = true;
                BindCurrencyInGrid();
                txtPrimaryAccount.Text = string.Empty;
                txtPrimaryAccount.Tag = new TagObject();
                txtCreditTotal.Text = "0.00";
                rtbNarration.Text = string.Empty;
                dgvVoucherDetails.ClearSelection();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Validate data in vaoucher details grid row
        /// </summary>
        /// <param name="rowIndex">Row index</param>
        private bool ValidateGridRow(int rowIndex)
        {
            try
            {
                bool isValid = true;
                if (dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherAccountName"].FormattedValue == null || dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherAccountName"].FormattedValue.ToString().Trim() == "")
                {
                    dgvVoucherDetails.Rows[rowIndex].HeaderCell.Value = "X";
                    dgvVoucherDetails.Rows[rowIndex].HeaderCell.Style.ForeColor = Color.Red;
                    dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherCheck"].Value = "x";
                    isValid = false;
                }
                else if (dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherAmount"].Value == null || dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherAmount"].Value.ToString().Trim() == "")
                {
                    dgvVoucherDetails.Rows[rowIndex].HeaderCell.Value = "X";
                    dgvVoucherDetails.Rows[rowIndex].HeaderCell.Style.ForeColor = Color.Red;
                    dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherCheck"].Value = "x";
                    isValid = false;
                }
                else if (dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherCurrency"].FormattedValue == null || dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherCurrency"].FormattedValue.ToString().Trim() == "")
                {
                    dgvVoucherDetails.Rows[rowIndex].HeaderCell.Value = "X";
                    dgvVoucherDetails.Rows[rowIndex].HeaderCell.Style.ForeColor = Color.Red;
                    dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherCheck"].Value = "x";
                    isValid = false;
                }
                else
                {
                    dgvVoucherDetails.Rows[rowIndex].HeaderCell.Value = string.Empty;
                    dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherCheck"].Value = string.Empty;
                    isValid = true;
                }
                if (dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherAccountName"].EditedFormattedValue.ToString() != dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherAccountName"].Tag.ToString())
                {
                    this.dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherAccountName"].ErrorText = "Invalid account name. Please select account from list.";
                    isValid = false;
                }
                else
                {
                    this.dgvVoucherDetails.Rows[rowIndex].Cells["colVoucherAccountName"].ErrorText = string.Empty;
                }
                return isValid;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To calculate net amount
        /// </summary>
        private void CalculateNetAmount()
        {
            try
            {
                decimal totalAmount = 0;
                decimal currencyExchangeRate = 0;
                foreach (DataGridViewRow row in dgvVoucherDetails.Rows)
                {
                    if (row.Cells["colVoucherAmount"].Value != null && row.Cells["colVoucherAmount"].Value.ToString() != string.Empty)
                    {
                        if (row.Cells["colVoucherCurrency"].Value != null && Convert.ToInt32(row.Cells["colVoucherCurrency"].Value) >= 0)
                        {
                            currencyExchangeRate = (from r in dtCurrency.AsEnumerable() where r.Field<int>("ExchangeRateID") == Convert.ToInt32(row.Cells["colVoucherCurrency"].Value) select r.Field<decimal>("ExchangeRate")).SingleOrDefault();
                            totalAmount += (Convert.ToDecimal(row.Cells["colVoucherAmount"].Value.ToString()) * currencyExchangeRate);
                        }
                        else
                        {
                            totalAmount += Convert.ToDecimal(row.Cells["colVoucherAmount"].Value.ToString());
                        }
                    }
                }
                txtCreditTotal.Text = Math.Round(totalAmount, ActiveUserSession.CurrencyNoOfDecimalPlaces).ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To initialize values in row
        /// </summary>
        /// <param name="rowIndex"></param>
        private void InitailaizeGridRow(int rowIndex)
        {
            try
            {
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.AccountId].Value = 0;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.AccountName].Value = string.Empty;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.AccountName].Tag = string.Empty;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.Amount].Value = 0.00M;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.Check].Value = string.Empty;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.ChequeDate].Value = string.Empty;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.ChequeNo].Value = string.Empty;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.Currency].Value = -1;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.DetailsId].Value = 0;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.MasterId].Value = 0;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.Narration].Value = string.Empty;
                dgvVoucherDetails.Rows[rowIndex].Cells[(int)GridColsVoucherDetails.PostingAccountId].Value = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To set user privileges
        /// </summary>
        private void SetUserPrivileges()
        {
            try
            {
                DataTable dtPrivileges = PrivilegeBLL.GetUserAccessRightsByMenuId(((FormProperties)Tag).MenuId, ActiveUserSession.UserRoleId);
                foreach (DataRow row in dtPrivileges.Rows)
                {
                    switch (Convert.ToInt32(row["AccessRightID"]))
                    {
                        case (int)UserAccessRights.MultipleCurrencyAllowed:
                            userAccessRight.MultipleCurrencyAllowed = Convert.ToBoolean(row["PermissionStatus"]);
                            break;
                        case (int)UserAccessRights.NegativeCashTransactionAllowed:
                            userAccessRight.NegativeCashTransactionAllowed = Convert.ToBoolean(row["PermissionStatus"]);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To insert/update contra entry
        /// </summary>
        private void InsertUpdateContraEntry()
        {
            try
            {
                ContraMaster contraMaster = new ContraMaster();
                contraMaster.AccountId = ((TagObject)txtPrimaryAccount.Tag).ObjectId;
                contraMaster.VoucherDate = Convert.ToDateTime(txtVoucherDate.Tag);
                contraMaster.Narration = rtbNarration.Text.Trim().Length > 0 ? rtbNarration.Text.Trim() : null;
                contraMaster.Amount = Convert.ToDecimal(txtCreditTotal.Text);
                contraMaster.EntryType = radDeposit.Checked ? ContraEntryType.Deposit : ContraEntryType.Withdrawal;
                contraMaster.CounterId = ActiveUserSession.CounterId;
                contraMaster.FYearId = ActiveUserSession.FYearId;
                contraMaster.VoucherTypeId = VoucherType.Contra_Voucher;
                contraMaster.UserId = ActiveUserSession.UserId;
                contraMaster.IsInsertUpdateDelete = InsertUpdateDeleteMode.InsertMode;

                DataTable dtContraDetails = new DataTable();
                dtContraDetails.Columns.Add("ContraDetailsID", typeof(int));
                dtContraDetails.Columns.Add("ContraEntryID", typeof(int));
                dtContraDetails.Columns.Add("SequenceNo", typeof(int));
                dtContraDetails.Columns.Add("AccountID", typeof(int));
                dtContraDetails.Columns.Add("Amount", typeof(decimal));
                dtContraDetails.Columns.Add("ExchangeRateID", typeof(int));
                dtContraDetails.Columns.Add("Narration", typeof(string));
                dtContraDetails.Columns.Add("ChequeNo", typeof(string));
                dtContraDetails.Columns.Add("ChequeDate", typeof(DateTime));

                foreach (DataGridViewRow row in dgvVoucherDetails.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        dtContraDetails.Rows.Add(0      //Contra details id
                                                , 0      //Contra entry id
                                                , dgvVoucherDetails.Rows.IndexOf(row) + 1      //Sequence no
                                                , Convert.ToInt32(row.Cells["colVoucherAccountId"].Value ?? 0)
                                                , Convert.ToDecimal(row.Cells["colVoucherAmount"].Value ?? 0)
                                                , Convert.ToInt32(row.Cells["colVoucherCurrency"].Value ?? 1)
                                                , (row.Cells["colVoucherNarration"].Value?.ToString() ?? string.Empty).Length <= 0 ? null : row.Cells["colVoucherNarration"].Value.ToString()
                                                , (row.Cells["colVoucherChequeNo"].Value?.ToString() ?? string.Empty).Length <= 0 ? null : row.Cells["colVoucherChequeNo"].Value.ToString()
                                                , (row.Cells["colVoucherChequeDate"].Value?.ToString() ?? string.Empty).Length <= 0 ? null : (DateTime?)Convert.ToDateTime(row.Cells["colVoucherChequeDate"].Value));
                    }
                }

                AccountBLL.InsertUpdateContraEntry(ref contraMaster, ref dtContraDetails);
                GeneralBLL.InsertEventLog("New contra voucher entry with voucher No : " + contraMaster.VoucherNo + " saved.", EventLogType.Voucher, EventLogMode.Insert, contraMaster.ContraEntryId);
                SetGrid();
                ClearFileds();
                Messages.ShowInformationMessage("Voucher saved successfully.\nVoucher No : " + contraMaster.VoucherNo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void InsertUpdateReceiptEntry()
        {
            try
            {
                ReceiptMaster receiptMaster = new ReceiptMaster();
                receiptMaster.AccountId = ((TagObject)txtPrimaryAccount.Tag).ObjectId;
                receiptMaster.VoucherDate = Convert.ToDateTime(txtVoucherDate.Tag);
                receiptMaster.Narration = rtbNarration.Text.Trim().Length > 0 ? rtbNarration.Text.Trim() : null;
                receiptMaster.Amount = Convert.ToDecimal(txtCreditTotal.Text);
                receiptMaster.CounterId = ActiveUserSession.CounterId;
                receiptMaster.FYearId = ActiveUserSession.FYearId;
                receiptMaster.VoucherTypeId = VoucherType.Receipt_Voucher;
                receiptMaster.UserId = ActiveUserSession.UserId;
                receiptMaster.IsInsertUpdateDelete = InsertUpdateDeleteMode.InsertMode;

                DataTable dtReceiptDetails = new DataTable();
                dtReceiptDetails.Columns.Add("ReceiptDetailsID", typeof(int));
                dtReceiptDetails.Columns.Add("ReceiptEntryID", typeof(int));
                dtReceiptDetails.Columns.Add("SequenceNo", typeof(int));
                dtReceiptDetails.Columns.Add("AccountID", typeof(int));
                dtReceiptDetails.Columns.Add("Amount", typeof(decimal));
                dtReceiptDetails.Columns.Add("ExchangeRateID", typeof(int));
                dtReceiptDetails.Columns.Add("Narration", typeof(string));
                dtReceiptDetails.Columns.Add("ChequeNo", typeof(string));
                dtReceiptDetails.Columns.Add("ChequeDate", typeof(DateTime));

                foreach (DataGridViewRow row in dgvVoucherDetails.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        dtReceiptDetails.Rows.Add(0      //Receipt details id
                                                , 0      //Receipt entry id
                                                , dgvVoucherDetails.Rows.IndexOf(row) + 1      //Sequence no
                                                , Convert.ToInt32(row.Cells["colVoucherAccountId"].Value ?? 0)
                                                , Convert.ToDecimal(row.Cells["colVoucherAmount"].Value ?? 0)
                                                , Convert.ToInt32(row.Cells["colVoucherCurrency"].Value ?? 1)
                                                , (row.Cells["colVoucherNarration"].Value?.ToString() ?? string.Empty).Length <= 0 ? null : row.Cells["colVoucherNarration"].Value.ToString()
                                                , (row.Cells["colVoucherChequeNo"].Value?.ToString() ?? string.Empty).Length <= 0 ? null : row.Cells["colVoucherChequeNo"].Value.ToString()
                                                , (row.Cells["colVoucherChequeDate"].Value?.ToString() ?? string.Empty).Length <= 0 ? null : (DateTime?)Convert.ToDateTime(row.Cells["colVoucherChequeDate"].Value));
                    }
                }

                AccountBLL.InsertUpdateReceiptEntry(ref receiptMaster, ref dtReceiptDetails);
                GeneralBLL.InsertEventLog("New receipt voucher entry with voucher No : " + receiptMaster.VoucherNo + " saved.", EventLogType.Voucher, EventLogMode.Insert, receiptMaster.ReceiptEntryId);
                SetGrid();
                ClearFileds();
                Messages.ShowInformationMessage("Voucher saved successfully.\nVoucher No : " + receiptMaster.VoucherNo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To check whether the form is clean. Else confirmation message will show.
        /// </summary>
        /// <returns>Continue or not</returns>
        private bool CheckIsFreshForm()
        {
            try
            {
                if (((TagObject)txtPrimaryAccount.Tag).ObjectId != 0
                    || dgvVoucherDetails.Rows.Count > 1
                    || Convert.ToInt32(dgvVoucherDetails.Rows[0].Cells["colVoucherAccountId"].Value) > 0
                    || rtbNarration.Text.Length > 0)
                {
                    return Messages.ShowConfirmation("The form will be cleared while chaning voucher entry type. Do you want to proceed?");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Button events

        /// <summary>
        /// On contra button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContra_Click(object sender, EventArgs e)
        {
            try
            {
                SetControls(VoucherType.Contra_Voucher);
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// On receipt button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                SetControls(VoucherType.Receipt_Voucher);
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// On payment button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPayment_Click(object sender, EventArgs e)
        {
            try
            {
                SetControls(VoucherType.Payment_Voucher);
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// On journal button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJournal_Click(object sender, EventArgs e)
        {
            try
            {
                SetControls(VoucherType.Journal_Voucher);
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        /// <summary>
        /// To select date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectDate_Click(object sender, EventArgs e)
        {
            try
            {
                mcVoucherDate.Visible = true;
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void btnSelectDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (splitContainer.ActiveControl == null || splitContainer.ActiveControl.Name != mcVoucherDate.Name)
                {
                    mcVoucherDate.Visible = false;
                }
            }
            catch (Exception ex)
            {
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
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ActiveUserSession.ServerDateTime = GeneralBLL.GetServerDateAndTime();
                if (Convert.ToDateTime(txtVoucherDate.Tag).Date > ActiveUserSession.ServerDateTime.Date)
                {
                    Messages.ShowInformationMessage("Invalid voucher date. You are not allowed to enter voucher for future date.");
                    txtVoucherDate.Focus();
                    txtVoucherDate.SelectAll();
                    return;
                }
                if (((TagObject)txtPrimaryAccount.Tag).ObjectId == 0 || txtPrimaryAccount.Text.Trim().Length == 0 || txtPrimaryAccount.Text.Trim() != ((TagObject)txtPrimaryAccount.Tag).ObjectName.Trim())
                {
                    Messages.ShowInformationMessage("Invalid account selection. Please select a valid account from list.");
                    txtPrimaryAccount.Focus();
                    txtPrimaryAccount.SelectAll();
                    return;
                }
                if (dgvVoucherDetails.Rows.Count <= 1)
                {
                    Messages.ShowInformationMessage("Insufficient details. Please enter valid details.");
                    dgvVoucherDetails.CurrentCell = dgvVoucherDetails[(int)GridColsVoucherDetails.AccountName, 0];
                    dgvVoucherDetails.Focus();
                    return;
                }
                for (int rowIndex = 0; rowIndex < dgvVoucherDetails.RowCount; rowIndex++)
                {
                    if (!dgvVoucherDetails.Rows[rowIndex].IsNewRow)
                    {
                        bool isValidRow = ValidateGridRow(rowIndex);
                        if (!isValidRow)
                        {
                            Messages.ShowInformationMessage("Invalid entries found. Please correct it and proceed.");
                            dgvVoucherDetails.CurrentCell = dgvVoucherDetails[(int)GridColsVoucherDetails.AccountName, rowIndex];
                            dgvVoucherDetails.Focus();
                            return;
                        }
                    }
                }
                if (Convert.ToDecimal(txtCreditTotal.Text) == 0)
                {
                    Messages.ShowInformationMessage("Cannot save voucher with amount 0. Please check the entry details.");
                    dgvVoucherDetails.CurrentCell = dgvVoucherDetails[(int)GridColsVoucherDetails.AccountName, 0];
                    dgvVoucherDetails.Focus();
                    return;
                }
                if (selectedVoucherType == VoucherType.Contra_Voucher)
                {
                    InsertUpdateContraEntry();
                }
                else if(selectedVoucherType == VoucherType.Receipt_Voucher)
                {
                    InsertUpdateReceiptEntry();
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                SetGrid();
                ClearFileds();
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

        #region Other Control Events

        private void mcVoucherDate_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                txtVoucherDate.ForeColor = CrystalConstants.NORMAL_TEXT_COLOR;
                txtVoucherDate.Text = e.Start.ToString("dd/MMM/yyyy");
                txtVoucherDate.Tag = e.Start.ToString("dd/MMM/yyyy");
                mcVoucherDate.Visible = false;
                BindCurrencyInGrid();
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void mcVoucherDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (splitContainer.ActiveControl == null || splitContainer.ActiveControl.Name != btnSelectDate.Name)
                {
                    mcVoucherDate.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dgvVoucherDetails.RowCount > 1)
                {
                    if (!dgvVoucherDetails.CurrentRow.IsNewRow && Messages.ShowConfirmation("Do you want to remove selected row?"))
                    {
                        dgvVoucherDetails.Rows.RemoveAt(dgvVoucherDetails.CurrentRow.Index);
                        GenerateSlNo();
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void rtbNarration_Enter(object sender, EventArgs e)
        {
            try
            {
                rtbNarration.BackColor = ColorTranslator.FromHtml(CrystalConstants.CONTROL_FOCUS_COLOR);
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void rtbNarration_Leave(object sender, EventArgs e)
        {
            try
            {
                rtbNarration.BackColor = ColorTranslator.FromHtml(CrystalConstants.CONTROL_NORMAL_COLOR);
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

        #region Grid Events

        private void dgvVoucherDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (e.Control is TextBox)
                {
                    TextBox txtAccountName = e.Control as TextBox;
                    if (dgvVoucherDetails.CurrentCell.ColumnIndex == (int)GridColsVoucherDetails.AccountName)
                    {
                        if (txtAccountName != null)
                        {
                            AutoCompleteStringCollection autoCompleteBankAndCash = new AutoCompleteStringCollection();
                            txtAccountName.AutoCompleteMode = AutoCompleteMode.Suggest;
                            txtAccountName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            foreach (DataRow item in dtAccountGridSuggetions.Rows)
                            {
                                autoCompleteBankAndCash.Add(item["AccountName"].ToString());
                            }
                            txtAccountName.AutoCompleteCustomSource = autoCompleteBankAndCash;
                        }
                    }
                    else
                    {
                        txtAccountName.AutoCompleteCustomSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void dgvVoucherDetails_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                GenerateSlNo();
                InitailaizeGridRow(e.RowIndex);
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void dgvVoucherDetails_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherAccountName"].Value != null)
                {
                    if (AccountBLL.CheckIsBankAccount(Convert.ToInt32(dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherAccountId"].Value.ToString())))
                    {
                        dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherChequeDate"].ReadOnly = false;
                        dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherChequeNo"].ReadOnly = false;
                    }
                    else
                    {
                        dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherChequeDate"].ReadOnly = true;
                        dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherChequeNo"].ReadOnly = true;
                        dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherChequeDate"].Value = string.Empty;
                        dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherChequeNo"].Value = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void dgvVoucherDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    if (dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherAccountName"].Value != null && dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherAccountName"].Value.ToString() != "")
                    {
                        if (dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherCurrency"].Value == null || dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherCurrency"].Value.ToString() == "-1")
                        {
                            dgvVoucherDetails.Rows[e.RowIndex].Cells["colVoucherCurrency"].Value = 1;
                        }
                    }
                    CalculateNetAmount();
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void dgvVoucherDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                {
                    object value = dgvVoucherDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (!((DataGridViewComboBoxColumn)dgvVoucherDetails.Columns[e.ColumnIndex]).Items.Contains(value))
                    {
                        e.ThrowException = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void dgvVoucherDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && Control.ModifierKeys == Keys.None)
                {
                    dgvVoucherDetails.EndEdit(DataGridViewDataErrorContexts.Commit);
                    if (dgvVoucherDetails.CurrentCell.ColumnIndex == (int)GridColsVoucherDetails.AccountName)
                    {
                        TextBox txt;
                        DataTable dtAccounts = null;
                        if (selectedVoucherType == VoucherType.Contra_Voucher)
                        {
                            dtAccounts = AccountBLL.GetBankCashAccountsByAccountName(dgvVoucherDetails.CurrentCell.EditedFormattedValue.ToString());
                        }
                        else if (selectedVoucherType == VoucherType.Receipt_Voucher)
                        {
                            dtAccounts = AccountBLL.GetAccountsByAccountName(dgvVoucherDetails.CurrentCell.EditedFormattedValue.ToString());
                        }
                        if (dtAccounts.Rows.Count > 0)
                        {
                            int[] sizeArray = new int[2];
                            sizeArray[0] = 0;
                            sizeArray[1] = 515;
                            popup = new nPopup(popupControl, splitContainer.ActiveControl);
                            if (dtAccounts.Rows.Count == 1)
                            {
                                dgvVoucherDetails.EndEdit(DataGridViewDataErrorContexts.Commit);
                                dgvVoucherDetails[(int)GridColsVoucherDetails.AccountId, dgvVoucherDetails.CurrentRow.Index].Value = dtAccounts.Rows[0]["AccountID"].ToString();
                                dgvVoucherDetails[(int)GridColsVoucherDetails.AccountName, dgvVoucherDetails.CurrentRow.Index].Value = dtAccounts.Rows[0]["AccountName"].ToString();
                                dgvVoucherDetails[(int)GridColsVoucherDetails.AccountName, dgvVoucherDetails.CurrentRow.Index].Tag = dtAccounts.Rows[0]["AccountName"].ToString();
                                dgvVoucherDetails.CurrentCell = dgvVoucherDetails[(int)GridColsVoucherDetails.Amount, dgvVoucherDetails.CurrentRow.Index];
                                if (splitContainer.ActiveControl.GetType() == typeof(TextBox))
                                {
                                    txt = (TextBox)splitContainer.ActiveControl;
                                    txt.Focus();
                                    txt.SelectAll();
                                }
                            }
                            else
                            {
                                dtAccounts.Columns["AccountName"].ColumnName = "Account Name"; //Space between sub heading AccountName of pop up
                                popupControl.FillPopup(dtAccounts, sizeArray, "Accounts"); //For filling popup								
                                popup.Show();		                                       //To show popup
                            }
                        }
                        else
                        {
                            Messages.ShowInformationMessage("Accounts not defined.");
                            if (splitContainer.ActiveControl.GetType() == typeof(TextBox))
                            {
                                txt = (TextBox)splitContainer.ActiveControl;
                                txt.Focus();
                                txt.SelectAll();
                            }
                            e.Handled = true;
                            return;
                        }
                        e.Handled = true;
                    }
                    if (dgvVoucherDetails.CurrentCell == dgvVoucherDetails.Rows[dgvVoucherDetails.Rows.Count - 1].Cells[(int)GridColsVoucherDetails.ChequeDate])
                    {
                        rtbNarration.Focus();
                        dgvVoucherDetails.ClearSelection();
                        e.Handled = true;
                    }
                }
                else if (e.KeyCode == Keys.Enter && Control.ModifierKeys == (Keys.Control | Keys.Shift))
                {
                    SelectNextControl(splitContainer.ActiveControl, true, true, true, true);
                    dgvVoucherDetails.ClearSelection();
                }
                else if (e.KeyCode == Keys.Enter && Control.ModifierKeys == Keys.Control)
                {
                    if (dgvVoucherDetails.CurrentCell.ColumnIndex == dgvVoucherDetails.ColumnCount - 1)
                    {
                        SelectNextControl(splitContainer.ActiveControl, true, true, true, true);
                    }
                }
                else if (e.KeyCode == Keys.Back)
                {
                    if (dgvVoucherDetails.CurrentCell == dgvVoucherDetails.Rows[0].Cells[(int)GridColsVoucherDetails.SlNo])
                    {
                        txtPrimaryAccount.Focus();
                        dgvVoucherDetails.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        private void dgvVoucherDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                ValidateGridRow(e.RowIndex);
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

        #region TextBox Events

        private void txtVoucherDate_Leave(object sender, EventArgs e)
        {
            try
            {
                mcVoucherDate.SelectionStart = Convert.ToDateTime(txtVoucherDate.Tag);
                BindCurrencyInGrid();
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }

        #endregion

    }
}
