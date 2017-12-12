#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Business class for user details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using directives

using tv.Crystal.Common.Constants;
using tv.Crystal.Data;
using System;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace tv.Crystal.Business
{
    public class UserBLL
    {
        /// <summary>
        /// Username and password verification method which returns a datatable
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>datatable with user information</returns>
        public static DataTable AuthenticateLogin(string userName, string password)
        {
            try
            {
                DataTable dtLogin;					//Creating datatable
                using (SqlConnection cnLogin = new SqlConnection(tvConnection.ConnectionString))
                {
                    cnLogin.Open();
                    try
                    {
                        //Calling data method for details of given user
                        dtLogin = UserDAL.AuthenticateLogin(cnLogin, userName, password);
                        cnLogin.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cnLogin.State == ConnectionState.Open || cnLogin != null)
                        {
                            cnLogin.Dispose();
                            cnLogin.Close();
                        }
                    }
                    return dtLogin;// Return datatable with user details
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method which returns permitted menu items for a given role and module as a datatable 
        /// </summary>
        /// <param name="roleId">Role identification</param>
        /// <param name="moduleId">Module identification</param>
        /// <returns>data table with permitted menu details for given user role</returns>
        public static DataTable GetUserRoleMenuItemPermissions(int roleId, int moduleId)
        {
            DataTable dtMenu = null;	// Data table for menu
            try
            {
                using (SqlConnection cnRole = new SqlConnection(tvConnection.ConnectionString))
                {
                    cnRole.Open();
                    try
                    {
                        dtMenu = UserDAL.GetUserRoleMenuItemPermissions(cnRole, roleId, moduleId);
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cnRole.State == ConnectionState.Open || cnRole != null)
                        {
                            cnRole.Close();
                            cnRole.Dispose();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtMenu;
        }
    }
}
