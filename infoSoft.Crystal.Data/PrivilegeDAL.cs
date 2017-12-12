#region Copyright
// ©Copyright 2015, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 23.07.2015
// Created By   : Noble
// Description  : Data class for privilege details
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
    public class PrivilegeDAL
    {
        /// <summary>
        /// To get user access rights of screen
        /// </summary>
        /// <param name="cnPrivilege">Connection object</param>
        /// <param name="menuId">Menu Id</param>
        /// <param name="roleId">Role Id</param>
        /// <returns>User access rights</returns>
        public static DataTable GetUserAccessRightsByMenuId(SqlConnection cnPrivilege, int menuId, int roleId)
        {
            DataTable dtPrivilege = new DataTable();

            try
            {
                SqlParameter parMenuID = new SqlParameter("@MenuID", menuId);
                SqlParameter parRoleID = new SqlParameter("@RoleID", roleId);

                SqlHelper.FillDatatable(cnPrivilege
                       , CommandType.StoredProcedure
                       , StoredProcedureConstants.GET_USER_ACCESS_RIGHTS_BY_MENU_ID
                       , dtPrivilege
                       , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
                       , parMenuID
                       , parRoleID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtPrivilege;
        }
    }
}
