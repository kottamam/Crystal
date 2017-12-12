#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 09.08.2015
// Created By  : Noble
// Description : This class includes member and accessor methods for contra master.
//-----------------------------------------------------------------------------------------------------------------------------------------------------//
// Last Modified On         : 
// Last Modified By         : 
// Modification Description : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using System;

#endregion

namespace tv.Crystal.Common.Models
{
    public class ContraMaster
    {
        #region Public methods

        public int ContraEntryId
        {
            get;
            set;
        } = 0;

        public int FYearId
        {
            get;
            set;
        } = ActiveUserSession.FYearId;

        public int CounterId
        {
            get;
            set;
        } = ActiveUserSession.CounterId;

        public int InvoiceNo
        {
            get;
            set;
        } = 0;

        public string VoucherNo
        {
            get;
            set;
        } = string.Empty;

        public DateTime VoucherDate
        {
            get;
            set;
        } = ActiveUserSession.ServerDateTime;

        public int AccountId
        {
            get;
            set;
        } = 0;

        public VoucherType VoucherTypeId
        {
            get;
            set;
        } = VoucherType.Contra_Voucher;

        public ContraEntryType EntryType
        {
            get;
            set;
        } = ContraEntryType.Deposit;

        public decimal Amount
        {
            get;
            set;
        } = 0;

        public string Narration
        {
            get;
            set;
        } = null;

        public string ChequeNo
        {
            get;
            set;
        } = null;

        public DateTime? ChequeDate
        {
            get;
            set;
        } = null;

        public int UserId
        {
            get;
            set;
        } = ActiveUserSession.UserId;

        public InsertUpdateDeleteMode IsInsertUpdateDelete
        {
            get;
            set;
        }

        #endregion
    }
}
