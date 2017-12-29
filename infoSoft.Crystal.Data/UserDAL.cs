#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 14.06.2015
// Created By   : Noble
// Description  : Data class for user details
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
    public class UserDAL
    {
        /// <summary>
        /// Verifies username and password and return the details of given username. Note that even if the password is wrong result will be returned, 
        /// but Validity variable will be zero to indicate an incorrect password
        /// </summary>
        /// <param name="cnLogin">database connection object</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public static DataTable AuthenticateLogin(SqlConnection cnLogin, string username, string password)
        {
            DataTable dtLogin = new DataTable();
            SqlParameter parUserName = new SqlParameter("@Username", username);
            SqlParameter parPassword = new SqlParameter("@Password", password);
            SqlHelper.FillDatatable(cnLogin
                                        , CommandType.StoredProcedure
                                        , StoredProcedureConstants.AUTHENTICATE_LOGIN
                                        , dtLogin
                                        , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                                        , parUserName
                                        , parPassword);
            return dtLogin;
        }

        /// <summary>
        /// Method for getting permitted menu items for given user role and module
        /// </summary>
        /// <param name="cnRole">Connection object</param>
        /// <param name="roleId">User Role</param>
        /// <param name="moduleId">Module</param>
        /// <returns>Menu permissions for given user as datatable</returns>
        public static DataTable GetUserRoleMenuItemPermissions(SqlConnection cnRole, int roleId, int moduleId)
        {
            DataTable dtMenu = new DataTable();
            SqlParameter parRoleId = new SqlParameter("@RoleID", roleId);
            SqlParameter parModuleId = new SqlParameter("@ModuleID", moduleId);

            SqlHelper.FillDatatable(cnRole
                                    , CommandType.StoredProcedure
                                    , StoredProcedureConstants.GET_USER_ROLE_MENU_ITEM_PERMISSIONS
                                    , dtMenu
                                    , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                                    , parRoleId
                                    , parModuleId);

            return dtMenu;
		}

		/// <summary>
		/// To get user list
		/// </summary>
		/// <param name="cnUser">Connection Object</param>
		/// <returns>Users</returns>
		public static DataTable GetUserList(SqlConnection cnUser)
		{
			DataTable dtUsers = new DataTable();

			SqlHelper.FillDatatable(cnUser
									, CommandType.StoredProcedure
									, StoredProcedureConstants.GET_USER_LIST
									, dtUsers
									, CrystalConstants.DEFAULT_COMMAND_TIME_OUT);

			return dtUsers;
		}
	}
}
