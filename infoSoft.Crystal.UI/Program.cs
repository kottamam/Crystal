#region Copyright

// ©Copyright 2015, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 14.06.2015
// Created By  : Noble
// Description : This class is defined for auto update and counter,Financial year checking and application start up.
//-----------------------------------------------------------//
// Last Modified On : 
// Last Modified By : 
// Modification Description : 

#endregion

#region Using directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.Deployment.Application;
using System.Globalization;
using System.Diagnostics;
using tv.Crystal.Business;
using tv.Crystal.Common.Models;
using tv.Crystal.Common.Constants;

#endregion

namespace tv.Crystal.UI
{
    static class Program
    {
        #region Private Methods

        /// <summary>
        /// To get counter details
        /// </summary>
        /// <returns>Counter settings found or not</returns>
        private static bool GetCounterSettings()
        {
            try
            {
                DataTable dtCounter = CounterBLL.GetCounterDetails();
                if (dtCounter.Rows.Count > 0)
                {
                    ActiveUserSession.CounterId = Convert.ToInt32(dtCounter.Rows[0]["CounterID"]);
                    ActiveUserSession.CounterName = dtCounter.Rows[0]["CounterName"].ToString();
                    ActiveUserSession.CounterDisplayName = dtCounter.Rows[0]["DisplayName"].ToString();
                    ActiveUserSession.PrinterName = dtCounter.Rows[0]["PrinterName"].ToString();
                    return true;
                }
                else
                {
                    Messages.ShowInformationMessage(Application.ProductName + " could not locate counter settings. Contact your IT Department.");
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// To get current financial year details
        /// </summary>
        /// <returns>Current financial year details found or not</returns>
        private static bool GetCurrentFinancialYearDetails()
        {
            try
            {
                DataTable dtFinancialYear = FinancialYearBLL.GetCurrentFinancialYearDetails();
                if (dtFinancialYear.Rows.Count > 0)
                {
                    ActiveUserSession.FYearId = Convert.ToInt32(dtFinancialYear.Rows[0]["FYearID"]);
                    ActiveUserSession.FYearStart = Convert.ToDateTime(dtFinancialYear.Rows[0]["FYearStart"]);
                    ActiveUserSession.FYearClose = Convert.ToDateTime(dtFinancialYear.Rows[0]["FYearClose"]);
                    return true;
                }
                else
                {
                    Messages.ShowInformationMessage(Application.ProductName + " could not locate financial year settings. Contact your IT Department.");
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Version checking
        /// </summary>
        /// <returns>Running latest application or not</returns>
        private static bool VersionChecking()
        {
            try
            {
                string version = string.Empty;  // variable for storing the version 
                Assembly appAssembly = Assembly.GetExecutingAssembly();
                AssemblyName appAssemblyName = appAssembly.GetName();
                string systemVersion = appAssemblyName.Version.ToString(); // variable for storing the version from assembly 

                // Calling business method for getting application version
                DataTable dtversion = GeneralBLL.GetApplicationVersion();
                if (dtversion.Rows.Count > 0)
                {
                    version = dtversion.Rows[0]["MajorVersion"].ToString().Trim() + "." + dtversion.Rows[0]["MinorVersion"].ToString().Trim() + "." + dtversion.Rows[0]["Build"].ToString().Trim() + "." + dtversion.Rows[0]["RevisionVersion"].ToString().Trim();
                }

                // Checking the version 
                if (systemVersion != version)
                {
                    Messages.ShowInformationMessage(Application.ProductName + " " + "version mismatch. Contact your IT department.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Check for another running instance of this application
        /// </summary>
        /// <returns>Is primary instance or not</returns>
        private static bool PrevInstance()
        {
            try
            {
                // Get the name of current process, i,e the process name of this current application
                string currPrsName = Process.GetCurrentProcess().ProcessName;

                // Get the name of all processes having the same name as this process name 
                Process[] allProcessWithThisName = Process.GetProcessesByName(currPrsName);

                // If more than one process is running return true, which means already previous instance of the application 
                // is running
                if (allProcessWithThisName.Length > 1)
                {
                    Messages.ShowInformationMessage("Cheque Book application is already running. You are not allowed to open more than one instance.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (GetCounterSettings() && PrevInstance() && GetCurrentFinancialYearDetails() && VersionChecking())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmLogin());
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                Messages.ShowExceptionMessage(ref ex);
            }
        }
    }
}
