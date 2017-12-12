#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 21.06.2015
// Created By   : Noble
// Description  : Data class for account details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Models;
using tv.Crystal.Common.SqlHelper;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace tv.Crystal.Data
{
    public class AccountDAL
    {
        /// <summary>
        /// To get account groups
        /// </summary>
        /// <param name="cnAccounts">Connection object</param>
        /// <returns>Account groups</returns>
        public static DataTable GetAccountGroups(SqlConnection cnAccounts)
        {
            DataTable dtAccountGroups = new DataTable();

            try
            {
                SqlHelper.FillDatatable(cnAccounts
                       , CommandType.StoredProcedure
                       , StoredProcedureConstants.GET_ACCOUNT_GROUPS
                       , dtAccountGroups
                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtAccountGroups;
        }

        /// <summary>
        /// To get account groups and ledgers
        /// </summary>
        /// <param name="cnAccounts">Connection object</param>
        /// <param name="accountParent">Account parent</param>
        /// <param name="isAccountLedger">Account type</param>
        /// <param name="accountName">Account Name</param>
        /// <returns>Account groups and ledger</returns>
        public static DataTable GetAccounts(SqlConnection cnAccounts, int accountParent, int isAccountLedger)
        {
            DataTable dtAccounts = new DataTable();

            try
            {
                SqlParameter parAccountParent = new SqlParameter("@AccountParent", accountParent);
                SqlParameter parIsAccountLedger = new SqlParameter("@IsAccountLedger", isAccountLedger);

                SqlHelper.FillDatatable(cnAccounts
                       , CommandType.StoredProcedure
                       , StoredProcedureConstants.GET_ACCOUNTS
                       , dtAccounts
                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                       , parAccountParent
                       , parIsAccountLedger);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtAccounts;
        }

        /// <summary>
        /// To get account names matching the parameter
        /// </summary>
        /// <param name="cnAccounts">Connection object</param>
        /// <param name="accountName">Account name parameter</param>
        /// <returns>Accounts</returns>
        public static DataTable GetAccountNames(SqlConnection cnAccounts, string accountName)
        {
            DataTable dtAccounts = new DataTable();

            try
            {
                SqlParameter parAccountName = new SqlParameter("@AccountName", accountName);

                SqlHelper.FillDatatable(cnAccounts
                       , CommandType.StoredProcedure
                       , StoredProcedureConstants.GET_ACCOUNT_NAMES
                       , dtAccounts
                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                       , parAccountName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtAccounts;
        }

        /// <summary>
        /// To get bank and cash accounts
        /// </summary>
        /// <param name="cnAccounts">Connection object</param>
        /// <returns>Bank and cash accounts</returns>
        public static DataTable GetBankCashAccounts(SqlConnection cnAccounts)
        {
            DataTable dtAccounts = new DataTable();

            try
            {
                SqlHelper.FillDatatable(cnAccounts
                       , CommandType.StoredProcedure
                       , StoredProcedureConstants.GET_BANK_CASH_ACCOUNTS
                       , dtAccounts
                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtAccounts;
        }

        /// <summary>
        /// To get bank and cash accounts by account name
        /// </summary>
        /// <param name="cnAccounts">Connection object</param>
        /// <param name="accountName">Account name prefix</param>
        /// <returns>Bank and cash accounts</returns>
        public static DataTable GetBankCashAccountsByAccountName(SqlConnection cnAccounts, string accountName)
        {
            DataTable dtAccounts = new DataTable();

            try
            {
                SqlParameter parAccountName = new SqlParameter("@AccountName", accountName);

                SqlHelper.FillDatatable(cnAccounts
                       , CommandType.StoredProcedure
                       , StoredProcedureConstants.GET_BANK_CASH_ACCOUNTS_BY_ACCOUNT_NAME
                       , dtAccounts
                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                       , parAccountName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtAccounts;
        }

        /// <summary>
        /// To get accounts by account name
        /// </summary>
        /// <param name="cnAccounts">Connection objects</param>
        /// <param name="accountName">Account name prefix</param>
        /// <returns>Accounts</returns>
        public static DataTable GetAccountsByAccountName(SqlConnection cnAccounts, string accountName)
        {
            DataTable dtAccounts = new DataTable();

            try
            {
                SqlParameter parAccountName = new SqlParameter("@AccountName", accountName);

                SqlHelper.FillDatatable(cnAccounts
                       , CommandType.StoredProcedure
                       , StoredProcedureConstants.GET_ACCOUNTS_BY_ACCOUNT_NAME
                       , dtAccounts
                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                       , parAccountName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtAccounts;
        }
        
        /// <summary>
        /// To get account details of an account
        /// </summary>
        /// <param name="cnAccounts">Connection object</param>
        /// <param name="accountId">Account id</param>
        /// <param name="fYearId">Financila year id</param>
        /// <returns>Account details</returns>
        public static DataTable GetAccountDetailsByAccountId(SqlConnection cnAccounts, int accountId, int fYearId)
        {
            DataTable dtAccounts = new DataTable();

            try
            {
                SqlParameter parAccountId = new SqlParameter("@AccountID", accountId);
                SqlParameter parFYearId = new SqlParameter("@FYearID", fYearId);

                SqlHelper.FillDatatable(cnAccounts
                       , CommandType.StoredProcedure
                       , StoredProcedureConstants.GET_ACCOUNT_DETAILS_BY_ACCOUNT_ID
                       , dtAccounts
                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                       , parAccountId
                       , parFYearId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtAccounts;
        }
        
        /// <summary>
        /// To check the duplicate account name
        /// </summary>
        /// <param name="cnAccounts">Connection object</param>
        /// <param name="accountId">Account id</param>
        /// <param name="accountName">Account name</param>
        /// <returns>Count of duplicate account</returns>
        public static int CheckDuplicateAccountName(SqlConnection cnAccounts, int accountId, string accountName)
        {
            try
            {
                SqlParameter parAccountID = new SqlParameter("@AccountID", accountId);
                SqlParameter parAccountName = new SqlParameter("@AccountName", accountName);

                return (int)SqlHelper.ExecuteScalar(cnAccounts
                                                       , CommandType.StoredProcedure
                                                       , StoredProcedureConstants.CHECK_DUPLICATE_ACCOUNT_NAME
                                                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                                                       , parAccountID
                                                       , parAccountName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To insert update account details
        /// </summary>
        /// <param name="tranAccount">Transaction object</param>
        /// <param name="account">Accout details</param>
        /// <returns>Account id</returns>
        public static int InsertUpdateAccountDetails(SqlTransaction tranAccount, ref Account account)
        {
            try
            {
                SqlParameter parAccountId = new SqlParameter("@AccountID", account.AccountId);
                parAccountId.Direction = ParameterDirection.InputOutput;
                SqlParameter parAccountName = new SqlParameter("@AccountName", account.AccountName);
                SqlParameter parIsAccountLedger = new SqlParameter("@IsAccountLedger", account.IsAccountLedger);
                SqlParameter parAccountParent = new SqlParameter("@AccountParent", account.AccountParent);
                SqlParameter parOpening = new SqlParameter("@Opening", account.Opening);
                SqlParameter parOpeningType = new SqlParameter("@OpeningType", account.OpeningType);
                SqlParameter parFYearId = new SqlParameter("@FYearID", account.FYearId);
                SqlParameter parIsInsertUpdateDelete = new SqlParameter("@IsInsertUpdateDelete", (int)account.IsInsertUpdateDelete);
                SqlParameter[] parameters = {
											  parAccountId
                                            , parAccountName
                                            , parIsAccountLedger
                                            , parAccountParent
                                            , parOpening
                                            , parOpeningType
                                            , parFYearId
                                            , parIsInsertUpdateDelete};

                SqlHelper.ExecuteNonQuery(tranAccount
                                        , CommandType.StoredProcedure
                                        , StoredProcedureConstants.INSERT_UPDATE_ACCOUNT_DETAILS
                                        , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                                        , parameters);

                return (Convert.ToInt32(parAccountId.Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To get currencies on the exchange date
        /// </summary>
        /// <param name="cnCurrency">Connection object</param>
        /// <param name="exchangeDate">Exchange date</param>
        /// <returns>Currencies</returns>
        public static DataTable GetCurrencyApplicableOnDate(SqlConnection cnCurrency, DateTime exchangeDate)
        {
            DataTable dtCurrency = new DataTable();

            try
            {
                SqlParameter parExchangeDate = new SqlParameter("@ExchangeDate", exchangeDate);

                SqlHelper.FillDatatable(cnCurrency
                       , CommandType.StoredProcedure
                       , StoredProcedureConstants.GET_CURRENCY_APPLICABLE_ON_DATE
                       , dtCurrency
                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                       , parExchangeDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtCurrency;
        }

        /// <summary>
        /// To check the account is a bank account or not
        /// </summary>
        /// <param name="cnAccounts">Connection object</param>
        /// <param name="accountId">Account id</param>
        /// <returns>Is bank account or not</returns>
        public static bool CheckIsBankAccount(SqlConnection cnAccounts, int accountId)
        {
            try
            {
                SqlParameter parAccountID = new SqlParameter("@AccountID", accountId);

                return (bool)SqlHelper.ExecuteScalar(cnAccounts
                                                       , CommandType.StoredProcedure
                                                       , StoredProcedureConstants.CHECK_IS_BANK_ACCOUNT
                                                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                                                       , parAccountID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To insert/update contra entry
        /// </summary>
        /// <param name="tranAccount">Transaction object</param>
        /// <param name="contraMaster">Contra master details</param>
        /// <param name="dtContraDetails">Contra details info</param>
        /// <returns>Voucher No</returns>
        public static string InsertUpdateContraEntry(SqlTransaction tranAccount, ref ContraMaster contraMaster, ref DataTable dtContraDetails)
        {
            try
            {
                SqlParameter parContraEntryId = new SqlParameter("@ContraEntryID", contraMaster.ContraEntryId);
                parContraEntryId.SqlDbType = SqlDbType.Int;
                parContraEntryId.Direction = ParameterDirection.InputOutput;
                SqlParameter parFYearId = new SqlParameter("@FYearID", contraMaster.FYearId);
                SqlParameter parCounterId = new SqlParameter("@CounterID", contraMaster.CounterId);
                SqlParameter parInvoiceNo = new SqlParameter("@InvoiceNo", contraMaster.InvoiceNo);
                SqlParameter parVoucherNo = new SqlParameter("@VoucherNo", contraMaster.VoucherNo);
                parVoucherNo.SqlDbType = SqlDbType.VarChar;
                parVoucherNo.Size = 10;
                parVoucherNo.Direction = ParameterDirection.InputOutput;
                SqlParameter parVoucherDate = new SqlParameter("@VoucherDate", contraMaster.VoucherDate);
                SqlParameter parAccountId = new SqlParameter("@AccountID", contraMaster.AccountId);
                SqlParameter parVoucherTypeId = new SqlParameter("@VoucherTypeID", (int)contraMaster.VoucherTypeId);
                SqlParameter parEntryType = new SqlParameter("@EntryType", Convert.ToBoolean(contraMaster.EntryType));
                SqlParameter parAmount = new SqlParameter("@Amount", contraMaster.Amount);
                SqlParameter parNarration = new SqlParameter("@Narration", contraMaster.Narration);
                SqlParameter parChequeNo = new SqlParameter("@ChequeNo", contraMaster.ChequeNo);
                SqlParameter parChequeDate = new SqlParameter("@ChequeDate", contraMaster.ChequeDate);
                SqlParameter parUserId = new SqlParameter("@UserID", contraMaster.UserId);
                SqlParameter parIsInsertUpdateDelete = new SqlParameter("@IsInsertUpdateDelete", (int)contraMaster.IsInsertUpdateDelete);

                SqlParameter parContraDetails = new SqlParameter("@ContraDetails", dtContraDetails);
                parContraDetails.SqlDbType = SqlDbType.Structured;
                parContraDetails.TypeName = "dbo.udttContraDetails";

                SqlParameter[] parameters = {parContraEntryId
                                            , parFYearId
                                            , parCounterId
                                            , parInvoiceNo
                                            , parVoucherNo
                                            , parVoucherDate
                                            , parAccountId
                                            , parVoucherTypeId
                                            , parEntryType
                                            , parAmount
                                            , parNarration
                                            , parChequeNo
                                            , parChequeDate
                                            , parUserId
                                            , parIsInsertUpdateDelete
                                            , parContraDetails};

                SqlHelper.ExecuteNonQuery(tranAccount
                                        , CommandType.StoredProcedure
                                        , StoredProcedureConstants.INSERT_UPDATE_CONTRA_ENTRY
                                        , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                                        , parameters);

                contraMaster.ContraEntryId = Convert.ToInt32(parContraEntryId.Value);
                return (Convert.ToString(parVoucherNo.Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To insert/update receipt entry
        /// </summary>
        /// <param name="tranAccount">Transaction object</param>
        /// <param name="receiptMaster">Receipt master details</param>
        /// <param name="dtReceiptDetails">Receipt details info</param>
        /// <returns>Voucher No</returns>
        public static string InsertUpdateReceiptEntry(SqlTransaction tranAccount, ref ReceiptMaster receiptMaster, ref DataTable dtReceiptDetails)
        {
            try
            {
                SqlParameter parReceiptEntryId = new SqlParameter("@ReceiptEntryID", receiptMaster.ReceiptEntryId);
                parReceiptEntryId.SqlDbType = SqlDbType.Int;
                parReceiptEntryId.Direction = ParameterDirection.InputOutput;
                SqlParameter parFYearId = new SqlParameter("@FYearID", receiptMaster.FYearId);
                SqlParameter parCounterId = new SqlParameter("@CounterID", receiptMaster.CounterId);
                SqlParameter parInvoiceNo = new SqlParameter("@InvoiceNo", receiptMaster.InvoiceNo);
                SqlParameter parVoucherNo = new SqlParameter("@VoucherNo", receiptMaster.VoucherNo);
                parVoucherNo.SqlDbType = SqlDbType.VarChar;
                parVoucherNo.Size = 10;
                parVoucherNo.Direction = ParameterDirection.InputOutput;
                SqlParameter parVoucherDate = new SqlParameter("@VoucherDate", receiptMaster.VoucherDate);
                SqlParameter parAccountId = new SqlParameter("@AccountID", receiptMaster.AccountId);
                SqlParameter parVoucherTypeId = new SqlParameter("@VoucherTypeID", (int)receiptMaster.VoucherTypeId);
                SqlParameter parAmount = new SqlParameter("@Amount", receiptMaster.Amount);
                SqlParameter parNarration = new SqlParameter("@Narration", receiptMaster.Narration);
                SqlParameter parUserId = new SqlParameter("@UserID", receiptMaster.UserId);
                SqlParameter parIsInsertUpdateDelete = new SqlParameter("@IsInsertUpdateDelete", (int)receiptMaster.IsInsertUpdateDelete);

                SqlParameter parContraDetails = new SqlParameter("@ReceiptDetails", dtReceiptDetails);
                parContraDetails.SqlDbType = SqlDbType.Structured;
                parContraDetails.TypeName = "dbo.udttReceiptDetails";

                SqlParameter[] parameters = {parReceiptEntryId
                                            , parFYearId
                                            , parCounterId
                                            , parInvoiceNo
                                            , parVoucherNo
                                            , parVoucherDate
                                            , parAccountId
                                            , parVoucherTypeId
                                            , parAmount
                                            , parNarration
                                            , parUserId
                                            , parIsInsertUpdateDelete
                                            , parContraDetails};

                SqlHelper.ExecuteNonQuery(tranAccount
                                        , CommandType.StoredProcedure
                                        , StoredProcedureConstants.INSERT_UPDATE_RECEIPT_ENTRY
                                        , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                                        , parameters);

                receiptMaster.ReceiptEntryId = Convert.ToInt32(parReceiptEntryId.Value);
                return (Convert.ToString(parVoucherNo.Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
