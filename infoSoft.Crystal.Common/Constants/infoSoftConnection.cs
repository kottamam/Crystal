#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Defined for database connection string
// ----------------------------------------------------//
// Modified By  : 
// Modified Date: 
// Description  : 

#endregion

#region User directives

using System.Configuration;

#endregion

namespace tv.Crystal.Common.Constants
{
    public class tvConnection
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[CrystalConstants.CONNECTION_KEY].ConnectionString; }
        }
    }
}
