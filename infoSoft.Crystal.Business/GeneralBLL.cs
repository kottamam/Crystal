#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Business class for general purpose details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Models;
using tv.Crystal.Data;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace tv.Crystal.Business
{
    public class GeneralBLL
    {
        /// <summary>
        /// To get latest application version
        /// </summary>
        /// <returns>Latest version details</returns>
        public static DataTable GetApplicationVersion()
        {
            SqlConnection cnVersion = new SqlConnection(tvConnection.ConnectionString);
            try
            {
                cnVersion.Open();
                // Calling data method for getting latest application version
                return GeneralDAL.GetApplicationVersion(cnVersion);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (cnVersion.State == ConnectionState.Open || cnVersion != null)
                {
                    cnVersion.Dispose();
                    cnVersion.Close();
                }
            }
        }

        /// <summary>
        /// Method for inserting event log
        /// </summary>
        /// <param name="eventDescription">Event description</param>
        /// <param name="eventType">Event type id</param>
        /// <param name="eventMode">Event mode</param>
        /// <param name="extra1">Extra values if any</param>
        public static void InsertEventLog(string eventDescription, EventLogType eventType, EventLogMode eventMode, int? extra1 = null)
        {
            try
            {
                using (SqlConnection cnEventLog = new SqlConnection(tvConnection.ConnectionString))
                {
                    cnEventLog.Open();
                    using (SqlTransaction tranEventLog = cnEventLog.BeginTransaction())
                    {
                        try
                        {
                            EventLog currentEvent = GeneralMethods.SetEventLog(eventDescription, GeneralBLL.GetServerDateAndTime(), eventType, eventMode, extra1);
                            GeneralDAL.InsertEventLog(tranEventLog, ref currentEvent);
                            tranEventLog.Commit();
                        }
                        catch (Exception ex)
                        {
                            if (tranEventLog != null)
                                tranEventLog.Rollback();
                            throw ex;
                        }
                        finally
                        {
                            if (cnEventLog != null && cnEventLog.State == ConnectionState.Open)
                            {
                                cnEventLog.Close();
                                cnEventLog.Dispose();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method which returns sql server's datetime value
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerDateAndTime()
        {
            SqlConnection cnServer = new SqlConnection(tvConnection.ConnectionString);
            try
            {
                if (ActiveUserSession.CrystalMaintenanceDate != null)
                {
                    return Convert.ToDateTime(ActiveUserSession.CrystalMaintenanceDate);
                }
                else
                {
                    cnServer.Open();
                    return GeneralDAL.GetServerDateAndTime(cnServer);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (cnServer.State == ConnectionState.Open || cnServer != null)
                {
                    cnServer.Close();
                    cnServer.Dispose();
                }
            }
        }

        /// <summary>
        /// To get all values from general settings table
        /// </summary>
        /// <returns>General setting details in tabular mode</returns>
        public static DataTable GetGeneralSettings()
        {
            SqlConnection cnGeneralSettings = new SqlConnection(tvConnection.ConnectionString);
            try
            {
                cnGeneralSettings.Open();
                // Calling data method for selecting all general setting details
                return GeneralDAL.GetGeneralSettings(cnGeneralSettings);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (cnGeneralSettings.State == ConnectionState.Open || cnGeneralSettings != null)
                {
                    cnGeneralSettings.Dispose();
                    cnGeneralSettings.Close();
                }
            }
        }
    }
}
