#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 14.06.2015
// Created By  : Noble
// Description : This class includes member and accessor methods for acive user.
//-----------------------------------------------------------------------------------------------------------------------------------------------------//
// Last Modified On         : 
// Last Modified By         : 
// Modification Description : 

#endregion

#region Using directives


#endregion

using System;
namespace tv.Crystal.Common.Models
{
    public class ActiveUserSession
    {
        #region Constructor

        public ActiveUserSession()
        {
            CrystalMaintenanceDate = null;
            CompanyId = 0;
            CompanyName = string.Empty;
            CompanyNameForPrint = string.Empty;
            CompanyAddress1 = string.Empty;
            CompanyAddress2 = string.Empty;
            CompanyAddress3 = string.Empty;
            CompanyPhone = string.Empty;
            CompanyEmail = string.Empty;
            CounterId = 0;
            CounterName = string.Empty;
            CounterDisplayName = string.Empty;
            CurrencyNoOfDecimalPlaces = 2;
            FYearId = 0;
            ServerDateTime = DateTime.Now;
            PrinterName = string.Empty;
            UserId = 0;
            UserName = string.Empty;
            UserFullName = string.Empty;
            UserRoleId = 0;
        }

        #endregion

        #region Public Properties

        public static DateTime? CrystalMaintenanceDate
        {
            get;
            set;
        }

        public static int CompanyId
        {
            get;
            set;
        }

        public static string CompanyName
        {
            get;
            set;
        }

        public static string CompanyNameForPrint
        {
            get;
            set;
        }

        public static string CompanyAddress1
        {
            get;
            set;
        }

        public static string CompanyAddress2
        {
            get;
            set;
        }

        public static string CompanyAddress3
        {
            get;
            set;
        }

        public static string CompanyPhone
        {
            get;
            set;
        }

        public static string CompanyEmail
        {
            get;
            set;
        }

        public static int CounterId
        {
            get;
            set;
        }

        public static string CounterName
        {
            get;
            set;
        }

        public static string CounterDisplayName
        {
            get;
            set;
        }

        public static int CurrencyNoOfDecimalPlaces
        {
            get;
            set;
        }

        public static int FYearId
        {
            get;
            set;
        }
        
        public static DateTime FYearStart
        {
            get;
            set;
        }

        public static DateTime FYearClose
        {
            get;
            set;
        }

        public static string PrinterName
        {
            get;
            set;
        }

        public static DateTime ServerDateTime
        {
            get;
            set;
        }

        public static int UserId
        {
            get;
            set;
        }
        
        public static string UserName
        {
            get;
            set;
        }

        public static string UserFullName
        {
            get;
            set;
        }

        public static int UserRoleId
        {
            get;
            set;
        }

        #endregion
    }
}
