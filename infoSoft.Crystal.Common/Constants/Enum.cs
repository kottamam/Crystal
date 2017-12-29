#region Copyright

// © Copyright 2015, tv Software Pvt Ltd. All rights reserved.
// Created: 2015 (or earlier) 

#endregion Copyright

#region Code History

// Created On  : 14.06.2015
// Created By  : Noble
// Description : Enum declarations used in different screeens
//------------------------------------//
// Modified On  : 
// Modified By  : 
// Description  : 

#endregion Code History

#region Using Directives

#endregion

namespace tv.Crystal.Common.Constants
{
    #region General

    /// <summary>
    ///  Creating enums for Insert or Update or Delete mode
    /// </summary>
    public enum InsertUpdateDeleteMode
    {
        InsertMode = 0,
        UpdateMode = 1,
        DeleteMode = 2,
    }

    /// <summary>
    /// Indication for user access right types
    /// </summary>
    public enum UserAccessRights
    {
        NewEntryAllowed = 1,
        ModificationAllowed = 2,
        DeletionAllowed = 3,
        ViewAllowed = 4,
        MultipleCurrencyAllowed = 5,
        NegativeCashTransactionAllowed
    }

    /// <summary>
    /// Event log type
    /// </summary>
    public enum EventLogType
    {
        Application = 1,
        Login = 2,
		Customer = 3,
		Product = 4,
		SalesVoucher = 5,
		Reports = 6,
        Account = 7,
        Voucher = 8
    }

    /// <summary>
    /// Event log mode
    /// </summary>
    public enum EventLogMode
    {
        General = 0,
        Insert = 1,
        Update = 2,
        Delete = 3,
		Error = 4
    }

    #endregion

    #region Voucher Entry

    /// <summary>
    /// Voucher type indications
    /// </summary>
    public enum VoucherType
    {
        Opening_Balance = 1,
        Opening_Stock = 2,
        Contra_Voucher = 3,
        Payment_Voucher = 4,
        Receipt_Voucher = 5,
        Journal_Voucher = 6,
        PDC_Payable = 7,
        PDC_Receivable = 8,
        PDC_Clearance = 9,
        Purchase_Order = 10,
        Material_Receipt = 11,
        Rejection_Out = 12,
        Purchase_Invoice = 13,
        Purchase_Return = 14,
        Sales_Quotation = 15,
        Sales_Order = 16,
        Delivery_Note = 17,
        Rejection_In = 18,
        Sales_Invoice = 19,
        Sales_Return = 20,
        Service_Voucher = 21,
        Credit_Note = 22,
        Debit_Note = 23,
        Stock_Journal = 24,
        Physical_Stock = 25,
        Daily_Salary_Voucher = 26,
        Monthly_Salary_Voucher = 27,
        Advance_Payment = 28
    }

    /// <summary>
    /// Contra entry type indication
    /// </summary>
    public enum ContraEntryType
    {
        Deposit = 0,
        Withdrawal = 1
    }

    #endregion
}
