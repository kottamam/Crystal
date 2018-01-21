#region Copyright
// ©Copyright 2017, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 09.12.2017
// Created By   : Noble
// Description  : Data class for sales details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using Directives

using System;
using System.Data;
using System.Data.SqlClient;
using tv.Crystal.Common.Models;
using tv.Crystal.Common.Constants;
using tv.Crystal.Common.SqlHelper;

#endregion

namespace tv.Crystal.Data
{
	public class SalesDAL
	{
		/// <summary>
		/// To insert sales voucher
		/// </summary>
		/// <param name="tranSalesVoucher">Transaction Object</param>
		/// <param name="salesVoucher">Sales voucher details</param>
		/// <returns>Sales voucher id</returns>
		public static int InsertSalesVoucher(SqlTransaction tranSalesVoucher, ref SalesVoucher salesVoucher)
		{
			try
			{
				SqlParameter parSalesId = new SqlParameter("@SalesId", salesVoucher.SalesId);
				parSalesId.Direction = ParameterDirection.InputOutput;
				SqlParameter parSalesNo = new SqlParameter("@SalesNo", salesVoucher.SalesNo);
				parSalesNo.Direction = ParameterDirection.InputOutput;
				SqlParameter parCustomerId = new SqlParameter("@CustomerID", salesVoucher.CustomerId);
				SqlParameter parModelId = new SqlParameter("@ModelId", salesVoucher.ModelId);
				SqlParameter parSalesDate = new SqlParameter("@SalesDate", salesVoucher.SalesDate);
				SqlParameter parQuantity = new SqlParameter("@Quantity", salesVoucher.Quantity);
				SqlParameter parRate = new SqlParameter("@Rate", salesVoucher.Rate);
				SqlParameter parDiscount = new SqlParameter("@Discount", salesVoucher.Discount);
				SqlParameter parNetAmount = new SqlParameter("@NetAmount", salesVoucher.NetAmount);
				SqlParameter parReceivedAmount = new SqlParameter("@ReceivedAmount", salesVoucher.ReceivedAmount);
				SqlParameter parCreatedBy = new SqlParameter("@CreatedBy", salesVoucher.CreatedBy);
				SqlParameter[] parameters = {
											  parSalesId
											, parSalesNo
											, parCustomerId
											, parModelId
											, parSalesDate
											, parQuantity
											, parRate
											, parDiscount
											, parNetAmount
											, parReceivedAmount
											, parCreatedBy};

				SqlHelper.ExecuteNonQuery(tranSalesVoucher
										, CommandType.StoredProcedure
										, StoredProcedureConstants.INSERT_SALES_VOUCHER
										, CrystalConstants.DEFAULT_COMMAND_TIME_OUT
										, parameters);

				salesVoucher.SalesId = Convert.ToInt32(parSalesId.Value);
				salesVoucher.SalesNo = Convert.ToInt32(parSalesNo.Value);
				return (Convert.ToInt32(parSalesId.Value));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// To update sales voucher settlement amount
		/// </summary>
		/// <param name="tranSalesVoucher">Transaction object</param>
		/// <param name="salesVoucherSettlment">Settlment details</param>
		public static void UpdateSalesVoucherSettlementAmount(SqlTransaction tranSalesVoucher, SalesVoucherSettlement salesVoucherSettlment)
		{
			try
			{
				SqlParameter parSalesId = new SqlParameter("@SalesId", salesVoucherSettlment.SalesId);
				SqlParameter parAmount = new SqlParameter("@Amount", salesVoucherSettlment.Amount);
				SqlParameter parReferenceSalesId = new SqlParameter("@ReferenceSalesId", salesVoucherSettlment.ReferenceSalesId);
				SqlParameter[] parameters = {
											  parSalesId
											, parAmount
											, parReferenceSalesId};

				SqlHelper.ExecuteNonQuery(tranSalesVoucher
										, CommandType.StoredProcedure
										, StoredProcedureConstants.UPDATE_SALES_VOUCHER_SETTLEMENT_AMOUNT
										, CrystalConstants.DEFAULT_COMMAND_TIME_OUT
										, parameters);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// To get sales voucher history
		/// </summary>
		/// <param name="cnSalesVoucher">Connection object</param>
		/// <param name="customerId">Customer id</param>
		/// <param name="showAll">Show all or not</param>
		/// <returns>Sales voucher history</returns>
		public static DataTable GetSalesVoucherHistory(SqlConnection cnSalesVoucher, int customerId, bool showAll)
		{
			DataTable dtSalesVoucherHistory = new DataTable();

			try
			{
				SqlParameter parCustomerId = new SqlParameter("@CustomerId", customerId);
				SqlParameter parShowAll = new SqlParameter("@ShowAll", showAll);

				SqlHelper.FillDatatable(cnSalesVoucher
					   , CommandType.StoredProcedure
					   , StoredProcedureConstants.GET_SALES_VOUCHER_HISTORY
					   , dtSalesVoucherHistory
					   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
					   , parCustomerId
					   , parShowAll);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtSalesVoucherHistory;
		}

		/// <summary>
		/// To get sales details to generate report
		/// </summary>
		/// <param name="cnSalesVoucher">Connection object</param>
		/// <param name="fromDate">From date</param>
		/// <param name="toDate">TO date</param>
		/// <param name="customerId">Customer Id</param>
		/// <param name="modelId">Model Id</param>
		/// <param name="userId">User Id</param>
		/// <returns>Sales details based on the parameters</returns>
		public static DataTable GetSalesVoucherReportDetailed(SqlConnection cnSalesVoucher, DateTime fromDate, DateTime toDate, int customerId, int modelId, int userId)
		{
			DataTable dtSalesReport = new DataTable();

			try
			{
				SqlParameter parFromDate = new SqlParameter("@FromDate", fromDate);
				SqlParameter parToDate = new SqlParameter("@ToDate", toDate);
				SqlParameter parCustomerId = new SqlParameter("@CustomerId", customerId);
				SqlParameter parModelId = new SqlParameter("@ModelId", modelId);
				SqlParameter parUserId = new SqlParameter("@UserId", userId);

				SqlHelper.FillDatatable(cnSalesVoucher
					   , CommandType.StoredProcedure
					   , StoredProcedureConstants.GET_SALES_VOUCHER_REPORT_DETAILED
					   , dtSalesReport
					   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
					   , parFromDate
					   , parToDate
					   , parCustomerId
					   , parModelId
					   , parUserId);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtSalesReport;
		}

		/// <summary>
		/// To check is last sales to the customer
		/// </summary>
		/// <param name="cnSalesVoucher">Connection object</param>
		/// <param name="salesNo">Sales No</param>
		/// <returns>Last Sales No</returns>
		public static int CheckIsLastSaleToTheCustomer(SqlConnection cnSalesVoucher, int salesNo)
		{
			try
			{
				SqlParameter parSalesNo = new SqlParameter("@SalesNo", salesNo);

				return (int)SqlHelper.ExecuteScalar(cnSalesVoucher
							, CommandType.StoredProcedure
							, StoredProcedureConstants.CHECK_IS_LAST_SALE_TO_THE_CUSTOMER
							, parSalesNo);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// To get sales voucher details by sales no
		/// </summary>
		/// <param name="cnSalesVoucher">Connection object</param>
		/// <param name="salesNo">Sales no</param>
		/// <returns>Sales voucher details</returns>
		public static DataTable GetSalesVoucherDetailsBySalesNo(SqlConnection cnSalesVoucher, int salesNo)
		{
			DataTable dtSalesVoucherDetails = new DataTable();

			try
			{
				SqlParameter parSalesNo = new SqlParameter("@SalesNo", salesNo);

				SqlHelper.FillDatatable(cnSalesVoucher
					   , CommandType.StoredProcedure
					   , StoredProcedureConstants.GET_SALES_VOUCHER_DETAILS_BY_SALES_NO
					   , dtSalesVoucherDetails
					   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
					   , parSalesNo);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtSalesVoucherDetails;
		}

		/// <summary>
		/// To delete sales voucher
		/// </summary>
		/// <param name="tranSalesVoucher">Transaction object</param>
		/// <param name="salesId">Sales Id</param>
		/// <param name="userId">User Id</param>
		public static void DeleteSalesVoucher(SqlTransaction tranSalesVoucher, int salesId, int userId)
		{
			try
			{
				SqlParameter parSalesId = new SqlParameter("@SalesID", salesId);
				SqlParameter parUserId = new SqlParameter("@UserID", userId);
				SqlParameter[] parameters = {
											  parSalesId
											, parUserId};

				SqlHelper.ExecuteNonQuery(tranSalesVoucher
										, CommandType.StoredProcedure
										, StoredProcedureConstants.DELETE_SALES_VOUCHER
										, CrystalConstants.DEFAULT_COMMAND_TIME_OUT
										, parameters);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
