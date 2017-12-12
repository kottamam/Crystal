#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 21.06.2015
// Created By   : Noble
// Description  : Business class for account details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Models;
using tv.Crystal.Data;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace tv.Crystal.Business
{
    public class AccountBLL
    {

        /// <summary>
        /// To get account groups
        /// </summary>
        /// <returns>Account groups</returns>
        public static DataTable GetAccountGroups()
        {
            DataTable dtAccountGroups; // Creating datatable for selecting account groups

            using (SqlConnection cnAccounts = new SqlConnection(tvConnection.ConnectionString))
            {
                cnAccounts.Open();

                try
                {
                    //Calling data method for getting account groupss
                    dtAccountGroups = AccountDAL.GetAccountGroups(cnAccounts);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cnAccounts.State == ConnectionState.Open || cnAccounts != null)
                    {
                        cnAccounts.Dispose();
                        cnAccounts.Close();
                    }
                }

                return dtAccountGroups; // Return datatable with account groups
            }
        }

        /// <summary>
        /// To get account groups and ledgers
        /// </summary>
        /// <param name="accountParent">Account parent</param>
        /// <param name="isAccountLedger">Accout type</param>
        /// <param name="accountName">Accout Name</param>
        /// <returns>Account groups and ledgers</returns>
        public static DataTable GetAccounts(int accountParent, int isAccountLedger)
        {
            DataTable dtAccounts;

            using (SqlConnection cnAccounts = new SqlConnection(tvConnection.ConnectionString))
            {
                cnAccounts.Open();

                try
                {
                    //Calling data method for getting account groups and ledgers
                    dtAccounts = AccountDAL.GetAccounts(cnAccounts, accountParent, isAccountLedger);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cnAccounts.State == ConnectionState.Open || cnAccounts != null)
                    {
                        cnAccounts.Dispose();
                        cnAccounts.Close();
                    }
                }

                return dtAccounts; // Return datatable with account groups and ledger
            }
        }
        
        /// <summary>
        /// To get account details of an account
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <param name="fYearId">Financial year id</param>
        /// <returns>Account details of an account</returns>
        public static DataTable GetAccountDetailsByAccountId(int accountId, int fYearId)
        {
            DataTable dtAccounts;

            using (SqlConnection cnAccounts = new SqlConnection(tvConnection.ConnectionString))
            {
                cnAccounts.Open();

                try
                {
                    //Calling data method for getting account details of an account
                    dtAccounts = AccountDAL.GetAccountDetailsByAccountId(cnAccounts, accountId, fYearId);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cnAccounts.State == ConnectionState.Open || cnAccounts != null)
                    {
                        cnAccounts.Dispose();
                        cnAccounts.Close();
                    }
                }

                return dtAccounts; // Return datatable with account groups and ledger
            }
        }

        /// <summary>
        /// To get account names matching the parameter
        /// </summary>
        /// <param name="accountName">Account name</param>
        /// <returns>Accounts</returns>
        public static DataTable GetAccountNames(string accountName)
        {
            DataTable dtAccounts;

            using (SqlConnection cnAccounts = new SqlConnection(tvConnection.ConnectionString))
            {
                cnAccounts.Open();

                try
                {
                    //Calling data method for getting account details of an account
                    dtAccounts = AccountDAL.GetAccountNames(cnAccounts, accountName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cnAccounts.State == ConnectionState.Open || cnAccounts != null)
                    {
                        cnAccounts.Dispose();
                        cnAccounts.Close();
                    }
                }

                return dtAccounts; // Return datatable with account groups and ledger
            }
        }

        /// <summary>
        /// To get bank and cash accounts
        /// </summary>
        /// <returns>Bank and cash accounts</returns>
        public static DataTable GetBankCashAccounts()
        {
            DataTable dtAccounts;

            using (SqlConnection cnAccounts = new SqlConnection(tvConnection.ConnectionString))
            {
                cnAccounts.Open();

                try
                {
                    //Calling data method for getting bank and cash account details
                    dtAccounts = AccountDAL.GetBankCashAccounts(cnAccounts);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cnAccounts.State == ConnectionState.Open || cnAccounts != null)
                    {
                        cnAccounts.Dispose();
                        cnAccounts.Close();
                    }
                }

                return dtAccounts; // Return datatable with bank and cash accounts
            }
        }

        /// <summary>
        /// To get cash and bank accounts by account name
        /// </summary>
        /// <param name="accountName">Account name prefix</param>
        /// <returns>Cash and bank accounts</returns>
        public static DataTable GetBankCashAccountsByAccountName(string accountName)
        {
            DataTable dtAccounts;

            using (SqlConnection cnAccounts = new SqlConnection(tvConnection.ConnectionString))
            {
                cnAccounts.Open();

                try
                {
                    //Calling data method for getting bank and cash account details
                    dtAccounts = AccountDAL.GetBankCashAccountsByAccountName(cnAccounts, accountName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cnAccounts.State == ConnectionState.Open || cnAccounts != null)
                    {
                        cnAccounts.Dispose();
                        cnAccounts.Close();
                    }
                }

                return dtAccounts; // Return datatable with bank and cash accounts
            }
        }

        /// <summary>
        /// To get accounts by account name
        /// </summary>
        /// <param name="accountName">Account name prefix</param>
        /// <returns>Accounts</returns>
        public static DataTable GetAccountsByAccountName(string accountName)
        {
            DataTable dtAccounts;

            using (SqlConnection cnAccounts = new SqlConnection(tvConnection.ConnectionString))
            {
                cnAccounts.Open();

                try
                {
                    dtAccounts = AccountDAL.GetAccountsByAccountName(cnAccounts, accountName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cnAccounts.State == ConnectionState.Open || cnAccounts != null)
                    {
                        cnAccounts.Dispose();
                        cnAccounts.Close();
                    }
                }
                return dtAccounts;
            }
        }

        /// <summary>
        /// To check the duplicate account name
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <param name="accountName">Account name</param>
        /// <returns>Count of duplicate account</returns>
        public static int CheckDuplicateAccountName(int accountId, string accountName)
        {
            using (SqlConnection cnAccounts = new SqlConnection(tvConnection.ConnectionString))
            {
                cnAccounts.Open();

                try
                {
                    //Calling data method for getting account groups and ledgers
                    return AccountDAL.CheckDuplicateAccountName(cnAccounts, accountId, accountName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cnAccounts.State == ConnectionState.Open || cnAccounts != null)
                    {
                        cnAccounts.Dispose();
                        cnAccounts.Close();
                    }
                }
            }
        }

        /// <summary>
        /// To insert/Update account
        /// </summary>
        /// <param name="account">Account details</param>
        /// <returns>Account id</returns>
        public static int InsertUpdateAccountDetails(ref Account account)
        {
            try
            {
                using (SqlConnection cnAccount = new SqlConnection(tvConnection.ConnectionString))
                {
                    cnAccount.Open();

                    using (SqlTransaction tranAccount = cnAccount.BeginTransaction())
                    {
                        try
                        {
                            // Calling data method for inserting/updating/deleting accounts
                            account.AccountId = AccountDAL.InsertUpdateAccountDetails(tranAccount, ref account);
                            tranAccount.Commit();
                        }
                        catch (Exception ex)
                        {
                            if (tranAccount != null)
                                tranAccount.Rollback();
                            throw ex;
                        }
                        finally
                        {
                            if (cnAccount != null && cnAccount.State == ConnectionState.Open)
                            {
                                cnAccount.Close();
                                cnAccount.Dispose();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return account.AccountId; // Return account id
        }
        
        /// <summary>
        /// To get currencies on the exchange date
        /// </summary>
        /// <param name="exchangeDate">Exchange date</param>
        /// <returns>Currencies</returns>
        public static DataTable GetCurrencyApplicableOnDate(DateTime exchangeDate)
        {
            DataTable dtCurrency;
            using (SqlConnection cnCurrency = new SqlConnection(tvConnection.ConnectionString))
            {
                cnCurrency.Open();
                try
                {
                    dtCurrency = AccountDAL.GetCurrencyApplicableOnDate(cnCurrency, exchangeDate);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cnCurrency.State == ConnectionState.Open || cnCurrency != null)
                    {
                        cnCurrency.Dispose();
                        cnCurrency.Close();
                    }
                }
                return dtCurrency;
            }
        }

        /// <summary>
        /// To check the account is bank account or not
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <returns>Is bank account or not</returns>
        public static bool CheckIsBankAccount(int accountId)
        {
            using (SqlConnection cnAccounts = new SqlConnection(tvConnection.ConnectionString))
            {
                cnAccounts.Open();

                try
                {
                    return AccountDAL.CheckIsBankAccount(cnAccounts, accountId);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (cnAccounts.State == ConnectionState.Open || cnAccounts != null)
                    {
                        cnAccounts.Dispose();
                        cnAccounts.Close();
                    }
                }
            }
        }

        /// <summary>
        /// To insert/update contra entry
        /// </summary>
        /// <param name="contraMaster">Contra master info</param>
        /// <param name="dtContraDetails">Contra details info</param>
        /// <returns>Voucher No</returns>
        public static string InsertUpdateContraEntry(ref ContraMaster contraMaster, ref DataTable dtContraDetails)
        {
            try
            {
                using (SqlConnection cnAccount = new SqlConnection(tvConnection.ConnectionString))
                {
                    cnAccount.Open();
                    using (SqlTransaction tranAccount = cnAccount.BeginTransaction())
                    {
                        try
                        {
                            contraMaster.VoucherNo = AccountDAL.InsertUpdateContraEntry(tranAccount, ref contraMaster, ref dtContraDetails);
                            tranAccount.Commit();
                        }
                        catch (Exception ex)
                        {
                            if (tranAccount != null)
                                tranAccount.Rollback();
                            throw ex;
                        }
                        finally
                        {
                            if (cnAccount != null && cnAccount.State == ConnectionState.Open)
                            {
                                cnAccount.Close();
                                cnAccount.Dispose();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return contraMaster.VoucherNo;
        }

        /// <summary>
        /// To insert/update receipt entry
        /// </summary>
        /// <param name="receiptMaster">Receipt master info</param>
        /// <param name="dtReceiptDetails">Receipt details info</param>
        /// <returns>Voucher No</returns>
        public static string InsertUpdateReceiptEntry(ref ReceiptMaster receiptMaster, ref DataTable dtReceiptDetails)
        {
            try
            {
                using (SqlConnection cnAccount = new SqlConnection(tvConnection.ConnectionString))
                {
                    cnAccount.Open();
                    using (SqlTransaction tranAccount = cnAccount.BeginTransaction())
                    {
                        try
                        {
                            receiptMaster.VoucherNo = AccountDAL.InsertUpdateReceiptEntry(tranAccount, ref receiptMaster, ref dtReceiptDetails);
                            tranAccount.Commit();
                        }
                        catch (Exception ex)
                        {
                            if (tranAccount != null)
                                tranAccount.Rollback();
                            throw ex;
                        }
                        finally
                        {
                            if (cnAccount != null && cnAccount.State == ConnectionState.Open)
                            {
                                cnAccount.Close();
                                cnAccount.Dispose();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return receiptMaster.VoucherNo;
        }
    }
}
