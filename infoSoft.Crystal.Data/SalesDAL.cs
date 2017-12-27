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

	}
}
