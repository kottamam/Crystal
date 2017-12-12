using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tv.Crystal.Common.Constants;

namespace tv.Crystal.Common.Models
{
    public class ReceiptMaster
    {
        #region Public methods

        public int ReceiptEntryId
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
        } = VoucherType.Receipt_Voucher;

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
