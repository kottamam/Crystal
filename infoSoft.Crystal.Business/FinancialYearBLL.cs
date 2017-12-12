#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Business class for financial year details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using tv.Crystal.Data;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace tv.Crystal.Business
{
    public class FinancialYearBLL
    {
        /// <summary>
        /// To get current financial year detials
        /// </summary>
        /// <returns>Current financial year details</returns>
        public static DataTable GetCurrentFinancialYearDetails()
        {
            SqlConnection cnFinancialYear = new SqlConnection(tvConnection.ConnectionString);
            try
            {
                cnFinancialYear.Open();
                // Calling data method for getting current financial year details
                return FinancialYearDAL.GetCurrentFinancialYearDetails(cnFinancialYear);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (cnFinancialYear.State == ConnectionState.Open || cnFinancialYear != null)
                {
                    cnFinancialYear.Dispose();
                    cnFinancialYear.Close();
                }
            }
        }
    }
}
