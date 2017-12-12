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
using tv.Crystal.Data;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace tv.Crystal.Business
{
    public class PrivilegeBLL
    {
        /// <summary>
        /// To get user access rights of screen
        /// </summary>
        /// <param name="menuId">Menu id</param>
        /// <param name="roleId">Role id</param>
        /// <returns>User access rights</returns>
        public static DataTable GetUserAccessRightsByMenuId(int menuId, int roleId)
        {
            SqlConnection cnPrivilege = new SqlConnection(tvConnection.ConnectionString);
            try
            {
                cnPrivilege.Open();
                return PrivilegeDAL.GetUserAccessRightsByMenuId(cnPrivilege, menuId, roleId);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (cnPrivilege.State == ConnectionState.Open || cnPrivilege != null)
                {
                    cnPrivilege.Dispose();
                    cnPrivilege.Close();
                }
            }
        }

    }
}
