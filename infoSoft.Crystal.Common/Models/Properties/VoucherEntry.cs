#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 23.07.2015
// Created By  : Noble
// Description : This class includes member and accessor methods for voucher entry
//-----------------------------------------------------------------------------------------------------------------------------------------------------//
// Last Modified On         : 
// Last Modified By         : 
// Modification Description : 

#endregion

#region Using directives



#endregion

namespace tv.Crystal.Common.Models.Properties
{
    public class VoucherEntry
    {
        public class UserAccessRights
        {
            /// <summary>
            /// Indicate wether the users are allowed to enter voucher in mutiple currencies
            /// </summary>
            public bool MultipleCurrencyAllowed
            {
                get;
                set;
            } = false;

            /// <summary>
            /// Indicate wether the users are allowed to enter negative cash balance transaction.
            /// </summary>
            public bool NegativeCashTransactionAllowed
            {
                get;
                set;
            } = false;
        }
    }
}
