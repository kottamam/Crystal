#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Business class for counter details
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
    public class CounterBLL
    {
        /// <summary>
        /// To get the counter details
        /// </summary>
        /// <returns>Counter details</returns>
        public static DataTable GetCounterDetails()
        {
            SqlConnection cnCounter = new SqlConnection(tvConnection.ConnectionString);
            try
            {
                cnCounter.Open();
                // Calling data method for selecting all general setting details
                return CounterDAL.GetCounterDetails(cnCounter);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (cnCounter.State == ConnectionState.Open || cnCounter != null)
                {
                    cnCounter.Dispose();
                    cnCounter.Close();
                }
            }
        }
    }
}
