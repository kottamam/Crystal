#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Data class for general purpose details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Models;
using tv.Crystal.Common.SqlHelper;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace tv.Crystal.Data
{
    public class GeneralDAL
    {
        /// <summary>
        /// To get latest application version
        /// </summary>
        /// <param name="cnVersion">Connection object</param>
        /// <returns>Latest application version</returns>
        public static DataTable GetApplicationVersion(SqlConnection cnVersion)
        {
            try
            {
                DataTable dtApplicationVersion = new DataTable(); // Datatable object 

                SqlHelper.FillDatatable(cnVersion
                                        , CommandType.StoredProcedure
                                        , StoredProcedureConstants.GET_APPLICATION_VERSION
                                        , dtApplicationVersion
                                        , CrystalConstants.DEFAULT_COMMAND_TIME_OUT);

                return dtApplicationVersion; // Returns datatable with application version details
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inserts eventlog
        /// </summary>
        /// <param name="tranEvent">Transaction object</param>
        /// <param name="currentEvent">eventlog object</param>
        public static void InsertEventLog(SqlTransaction tranEvent, ref EventLog currentEvent)
        {
            SqlParameter parEventId = new SqlParameter("@EventID", currentEvent.EventId);
            parEventId.Direction = ParameterDirection.Input;
            SqlParameter parEventDescription = new SqlParameter("@EventDescription", currentEvent.EventDescription);
            SqlParameter parEventTypeId = new SqlParameter("@EventTypeID", (int)currentEvent.EventTypeId);
            SqlParameter parEventMode = new SqlParameter("@EventMode", (int)currentEvent.EventMode);
            SqlParameter parCounterId = new SqlParameter("@CounterID", currentEvent.CounterId);
            SqlParameter parUserId = new SqlParameter("@UserID", currentEvent.UserId);
            SqlParameter parExtra1 = new SqlParameter("@Extra1", currentEvent.Extra1);

            SqlParameter[] parameter = { 
		                                 parEventId
                                         , parEventDescription
                                         , parEventTypeId
                                         , parEventMode
                                         , parCounterId
                                         , parUserId
                                         , parExtra1
		                                };

            SqlHelper.ExecuteNonQuery(tranEvent
                                    , CommandType.StoredProcedure
                                    , StoredProcedureConstants.INSERT_EVENT_LOG
                                    , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                                    , parameter);
        }

        /// <summary>
        /// Method for getting sql server's datetime
        /// </summary>
        /// <param name="cnServer"></param>
        /// <returns>Datetime of SQL Server</returns>
        public static DateTime GetServerDateAndTime(SqlConnection cnServer)
        {
            try
            {
                return (DateTime)SqlHelper.ExecuteScalar(cnServer
                                                        , CommandType.StoredProcedure
                                                        , StoredProcedureConstants.GET_SERVER_DATE_AND_TIME
                                                        , CrystalConstants.DEFAULT_COMMAND_TIME_OUT);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To get all values from general settings table
        /// </summary>
        /// <param name="cnGeneralSettings">Database connection object</param>
        /// <returns>General setting details in tabular mode</returns>
        public static DataTable GetGeneralSettings(SqlConnection cnGeneralSettings)
        {
            try
            {
                DataTable dtGeneralSettings = new DataTable(); // Datatable object 

                SqlHelper.FillDatatable(cnGeneralSettings, CommandType.StoredProcedure,
                      StoredProcedureConstants.GET_GENERAL_SETTINGS, dtGeneralSettings, CrystalConstants.DEFAULT_COMMAND_TIME_OUT);

                return dtGeneralSettings; // Returns datatable with general setting details
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
