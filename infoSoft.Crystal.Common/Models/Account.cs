#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 24.06.2015
// Created By  : Noble
// Description : This class includes member and accessor methods for account object.
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
    public class Account
    {
        #region Constructor

        public Account()
        {
            IsAccountLedger = false;
            AccountName = string.Empty;
            AccountId = 0;
            AccountParent = 0;
            Opening = 0.00M;
            OpeningType = false;
            FYearId = ActiveUserSession.FYearId;
            IsInsertUpdateDelete = InsertUpdateDeleteMode.InsertMode;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Type of account; Account group or Account ledger
        /// </summary>
        public bool IsAccountLedger
        {
            get;
            set;
        }

        /// <summary>
        /// Name of account group/account ledger
        /// </summary>
        public string AccountName
        {
            get;
            set;
        }

        /// <summary>
        /// Id of account group/ledger; Used for modification.
        /// </summary>
        public int AccountId
        {
            get;
            set;
        }

        /// <summary>
        /// Account parent of current account
        /// </summary>
        public int AccountParent
        {
            get;
            set;
        }

        /// <summary>
        /// Opening value of selected financial year
        /// </summary>
        public decimal Opening
        {
            get;
            set;
        }

        /// <summary>
        /// Opening amount type; Debit or Credit
        /// </summary>
        public bool OpeningType
        {
            get;
            set;
        }

        /// <summary>
        /// Selected financial year id
        /// </summary>
        public int FYearId
        {
            get;
            set;
        }

        /// <summary>
        /// Insert/update/delete
        /// </summary>
        public InsertUpdateDeleteMode IsInsertUpdateDelete
        {
            get;
            set;
        }

        #endregion
    }
}
