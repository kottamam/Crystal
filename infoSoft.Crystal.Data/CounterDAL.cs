#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Data class for counter details
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
    public class CounterDAL
    {
        /// <summary>
        /// To get counter details
        /// </summary>
        /// <param name="cnCounter">Connection object</param>
        /// <returns>Counter details</returns>
        public static DataTable GetCounterDetails(SqlConnection cnCounter)
        {
            try
            {
                DataTable dtCounter = new DataTable(); // Datatable object 

                SqlHelper.FillDatatable(cnCounter
                                        , CommandType.StoredProcedure
                                        , StoredProcedureConstants.GET_COUNTER_DETAILS
                                        , dtCounter
                                        , CrystalConstants.DEFAULT_COMMAND_TIME_OUT);

                return dtCounter; // Returns datatable with counter details
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
