#region Copyright
// ©Copyright 2017, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 16.12.2017
// Created By   : Noble
// Description  : Business class for sales details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Models;
using tv.Crystal.Data;

#endregion

namespace tv.Crystal.Business
{
	public class SalesBLL
	{
		/// <summary>
		/// To insert sales voucher
		/// </summary>
		/// <param name="salesVoucher">Sales vouher details</param>
		/// <returns>Sales voucher id</returns>
		public static int InsertSalesVoucher(ref SalesVoucher salesVoucher)
		{
			try
			{
				using (SqlConnection cnSalesVoucher = new SqlConnection(tvConnection.ConnectionString))
				{
					cnSalesVoucher.Open();

					using (SqlTransaction tranSalesVoucher = cnSalesVoucher.BeginTransaction())
					{
						try
						{
							// Calling data method for inserting/updating sales voucher
							salesVoucher.SalesId = SalesDAL.InsertSalesVoucher(tranSalesVoucher, ref salesVoucher);
							tranSalesVoucher.Commit();
							return salesVoucher.SalesId;
						}
						catch (Exception ex)
						{
							if (tranSalesVoucher != null)
								tranSalesVoucher.Rollback();
							throw ex;
						}
						finally
						{
							if (cnSalesVoucher != null && cnSalesVoucher.State == ConnectionState.Open)
							{
								cnSalesVoucher.Close();
								cnSalesVoucher.Dispose();
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
