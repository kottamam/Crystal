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
							if(salesVoucher.SettlementList.Count > 0)
							{
								foreach(SalesVoucherSettlement settlement in salesVoucher.SettlementList)
								{
									settlement.ReferenceSalesId = salesVoucher.SalesId;
									SalesDAL.UpdateSalesVoucherSettlementAmount(tranSalesVoucher, settlement);
								}
							}
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

		/// <summary>
		/// To get the sales voucher history
		/// </summary>
		/// <param name="customerId">Customer id</param>
		/// <param name="showAll">Show all or not</param>
		/// <returns>Sales voucher history</returns>
		public static DataTable GetSalesVoucherHistory(int customerId, bool showAll)
		{
			DataTable dtSalesVoucherHistory;

			using (SqlConnection cnCustomer = new SqlConnection(tvConnection.ConnectionString))
			{
				cnCustomer.Open();

				try
				{
					//Calling data method for getting sales voucher history
					dtSalesVoucherHistory = SalesDAL.GetSalesVoucherHistory(cnCustomer, customerId, showAll);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (cnCustomer.State == ConnectionState.Open || cnCustomer != null)
					{
						cnCustomer.Dispose();
						cnCustomer.Close();
					}
				}

				return dtSalesVoucherHistory; // Return datatable with sales voucher history
			}
		}

		/// <summary>
		/// To get sales details to generate report
		/// </summary>
		/// <param name="fromDate">From date</param>
		/// <param name="toDate">To date</param>
		/// <param name="customerId">Customer Id</param>
		/// <param name="modelId">Model Id</param>
		/// <param name="userId">User Id</param>
		/// <returns>Sales details</returns>
		public static DataTable GetSalesVoucherReportDetailed(DateTime fromDate, DateTime toDate, int customerId, int modelId, int userId)
		{
			DataTable dtSalesVoucher;

			using (SqlConnection cnCustomer = new SqlConnection(tvConnection.ConnectionString))
			{
				cnCustomer.Open();

				try
				{
					//Calling data method for getting sales details to generate report
					dtSalesVoucher = SalesDAL.GetSalesVoucherReportDetailed(cnCustomer, fromDate, toDate, customerId, modelId, userId);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (cnCustomer.State == ConnectionState.Open || cnCustomer != null)
					{
						cnCustomer.Dispose();
						cnCustomer.Close();
					}
				}

				return dtSalesVoucher; // Return datatable with sales details
			}
		}

		/// <summary>
		/// To check is last sales to the customer
		/// </summary>
		/// <param name="salesNo">Sales No</param>
		/// <returns>Last sales no</returns>
		public static int CheckIsLastSaleToTheCustomer(int salesNo)
		{
			int lastSalesNo;
			using (SqlConnection cnCustomer = new SqlConnection(tvConnection.ConnectionString))
			{
				cnCustomer.Open();

				try
				{
					//Calling data method for getting last sales no
					lastSalesNo = SalesDAL.CheckIsLastSaleToTheCustomer(cnCustomer, salesNo);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (cnCustomer.State == ConnectionState.Open || cnCustomer != null)
					{
						cnCustomer.Dispose();
						cnCustomer.Close();
					}
				}

				return lastSalesNo;
			}
		}

		/// <summary>
		/// To get sales voucher details by sales no
		/// </summary>
		/// <param name="salesNo"></param>
		/// <returns></returns>
		public static DataTable GetSalesVoucherDetailsBySalesNo(int salesNo)
		{
			DataTable dtSalesVoucherDetails;

			using (SqlConnection cnSalesVoucher = new SqlConnection(tvConnection.ConnectionString))
			{
				cnSalesVoucher.Open();

				try
				{
					//Calling data method for getting sales voucher details
					dtSalesVoucherDetails = SalesDAL.GetSalesVoucherDetailsBySalesNo(cnSalesVoucher, salesNo);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (cnSalesVoucher.State == ConnectionState.Open || cnSalesVoucher != null)
					{
						cnSalesVoucher.Dispose();
						cnSalesVoucher.Close();
					}
				}

				return dtSalesVoucherDetails; // Return datatable with sales voucher details
			}
		}

		/// <summary>
		/// To delete sales voucher
		/// </summary>
		/// <param name="salesId">Sales Id</param>
		/// <param name="userId">User Id</param>
		public static void DeleteSalesVoucher(int salesId, int userId)
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
							// Calling data method for delete sales voucher
							SalesDAL.DeleteSalesVoucher(tranSalesVoucher, salesId, userId);
							tranSalesVoucher.Commit();
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
