#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Data class for financial year details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using tv.Crystal.Common.SqlHelper;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace tv.Crystal.Data
{
    public class FinancialYearDAL
    {
        /// <summary>
        /// To get current financial year details
        /// </summary>
        /// <param name="cnFinancialYear">Connection object</param>
        /// <returns>Current financial year details</returns>
        public static DataTable GetCurrentFinancialYearDetails(SqlConnection cnFinancialYear)
        {
            try
            {
                DataTable dtFinancialYear = new DataTable(); // Datatable object 

                SqlHelper.FillDatatable(cnFinancialYear
                                        , CommandType.StoredProcedure
                                        , StoredProcedureConstants.GET_CURRENT_FINANCIAL_YEAR_DETAILS
                                        , dtFinancialYear
                                        , CrystalConstants.DEFAULT_COMMAND_TIME_OUT);

                return dtFinancialYear; // Returns datatable with financial year details
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
