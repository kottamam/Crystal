#region Copyright
// ©Copyright 2017, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 25.11.2017
// Created By   : Noble
// Description  : Data class for customer details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using Directives

using System;
using System.Data;
using System.Data.SqlClient;
using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Models;
using tv.Crystal.Common.SqlHelper;

#endregion

namespace tv.Crystal.Data
{
	public class CustomerDAL
	{
		/// <summary>
		/// To get customer list
		/// </summary>
		/// <param name="cnCustomers">Connection object</param>
		/// <returns>Customer list</returns>
		public static DataTable GetCustomerList(SqlConnection cnCustomers)
		{
			DataTable dtCustomers = new DataTable();

			try
			{
				SqlHelper.FillDatatable(cnCustomers
					   , CommandType.StoredProcedure
					   , StoredProcedureConstants.GET_CUSTOMER_LIST
					   , dtCustomers
					   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtCustomers;
		}

		/// <summary>
		/// To get customer details
		/// </summary>
		/// <param name="cnCustomers">Connection object</param>
		/// <param name="customerId">Customer id</param>
		/// <returns>Customer details</returns>
		public static DataTable GetCustomerDetails(SqlConnection cnCustomers, int customerId)
		{
			DataTable dtCustomer = new DataTable();

			try
			{
				SqlParameter parCustomerId = new SqlParameter("@CustomerID", customerId);

				SqlHelper.FillDatatable(cnCustomers
					   , CommandType.StoredProcedure
					   , StoredProcedureConstants.GET_CUSTOMER_DETAILS
					   , dtCustomer
					   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
					   , parCustomerId);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtCustomer;
		}

		/// <summary>
		/// To check duplicate customer name
		/// </summary>
		/// <param name="cnCustomers">Connection object</param>
		/// <param name="customerId">Customer id</param>
		/// <param name="customerName">Customer Name</param>
		/// <returns>Count of duplicate customer name</returns>
		public static int CheckDuplicateCustomerName(SqlConnection cnCustomers, int customerId, string customerName)
		{
			try
			{
				SqlParameter parCustomerID = new SqlParameter("@CustomerID", customerId);
				SqlParameter parCustomerName = new SqlParameter("@CustomerName", customerName);

				return (int)SqlHelper.ExecuteScalar(cnCustomers
													   , CommandType.StoredProcedure
													   , StoredProcedureConstants.CHECK_DUPLICATE_CUSTOMER_NAME
													   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
													   , parCustomerID
													   , parCustomerName);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// To check duplicate vehicle number
		/// </summary>
		/// <param name="cnCustomers">Connection object</param>
		/// <param name="customerId">Customer id</param>
		/// <param name="vehicleNo">Vehicle number</param>
		/// <returns>Count of duplicate vehicle number</returns>
		public static int CheckDuplicateVehicleNo(SqlConnection cnCustomers, int customerId, string vehicleNo)
		{
			try
			{
				SqlParameter parCustomerID = new SqlParameter("@CustomerID", customerId);
				SqlParameter parVehicleNo = new SqlParameter("@VehicleNo", vehicleNo);

				return (int)SqlHelper.ExecuteScalar(cnCustomers
													   , CommandType.StoredProcedure
													   , StoredProcedureConstants.CHECK_DUPLICATE_VEHICLE_NO
													   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
													   , parCustomerID
													   , parVehicleNo);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// To insert update customer
		/// </summary>
		/// <param name="tranCustomer">Transaction Object</param>
		/// <param name="customer">Customer details</param>
		/// <returns>Customer Id</returns>
		public static int InsertUpdateCustomer(SqlTransaction tranCustomer, ref Customer customer)
		{
			try
			{
				SqlParameter parCustomerId = new SqlParameter("@CustomerID", customer.CustomerId);
				parCustomerId.Direction = ParameterDirection.InputOutput;
				SqlParameter parCustomerName = new SqlParameter("@CustomerName", customer.CustomerName);
				SqlParameter parVehicleNo = new SqlParameter("@VehicleNo", customer.VehicleNumber);
				SqlParameter parAddress1 = new SqlParameter("@Address1", customer.Address1);
				SqlParameter parAddress2 = new SqlParameter("@Address2", customer.Address2);
				SqlParameter parPhone = new SqlParameter("@Phone", customer.Phone);
				SqlParameter parMobile = new SqlParameter("@Mobile", customer.Mobile);
				SqlParameter parIsInsertUpdateDelete = new SqlParameter("@IsInsertUpdateDelete", (int)customer.IsInsertUpdateDelete);
				SqlParameter[] parameters = {
											  parCustomerId
											, parCustomerName
											, parVehicleNo
											, parAddress1
											, parAddress2
											, parPhone
											, parMobile
											, parIsInsertUpdateDelete};

				SqlHelper.ExecuteNonQuery(tranCustomer
										, CommandType.StoredProcedure
										, StoredProcedureConstants.INSERT_UPDATE_CUSTOMER
										, CrystalConstants.DEFAULT_COMMAND_TIME_OUT
										, parameters);

				return (Convert.ToInt32(parCustomerId.Value));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// To delete customer
		/// </summary>
		/// <param name="tranCustomer">Transaction object</param>
		/// <param name="customerId">Customer Id</param>
		/// <param name="userId">User Id</param>
		public static void DeleteCustomer(SqlTransaction tranCustomer, int customerId, int userId)
		{
			try
			{
				SqlParameter parCustomerID = new SqlParameter("@CustomerID", customerId);
				SqlParameter parUserID = new SqlParameter("@UserID", userId);

				SqlHelper.ExecuteNonQuery(tranCustomer
										, CommandType.StoredProcedure
										, StoredProcedureConstants.DELETE_CUSTOMER
										, CrystalConstants.DEFAULT_COMMAND_TIME_OUT
										, parCustomerID
										, parUserID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		/// <summary>
		/// To get customer pending amount using vehicle number
		/// </summary>
		/// <param name="cnSales">Connection object</param>
		/// <param name="vehicleNo">Vehicle No</param>
		/// <returns>Customer details with pending amount</returns>
		public static DataTable GetCustomerPendingAmountUsingVehicleNo(SqlConnection cnSales, string vehicleNo)
		{
			DataTable dtCustomerPendingAmount = new DataTable();

			try
			{
				SqlParameter parVehicleNo = new SqlParameter("@VehicleNo", vehicleNo);

				SqlHelper.FillDatatable(cnSales
					   , CommandType.StoredProcedure
					   , StoredProcedureConstants.GET_CUSTOMER_PENDING_AMOUNT_USING_VEHICLE_NO
					   , dtCustomerPendingAmount
					   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
					   , parVehicleNo);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtCustomerPendingAmount;
		}

		/// <summary>
		/// To get customer pending amount using customer name
		/// </summary>
		/// <param name="cnSales">Connection object</param>
		/// <param name="customerName">Customer Name</param>
		/// <returns>Returns customer details with pending amount</returns>
		public static DataTable GetCustomerPendingAmountUsingName(SqlConnection cnSales, string customerName)
		{
			DataTable dtCustomerPendingAmount = new DataTable();

			try
			{
				SqlParameter parVehicleNo = new SqlParameter("@CustomerName", customerName);

				SqlHelper.FillDatatable(cnSales
					   , CommandType.StoredProcedure
					   , StoredProcedureConstants.GET_CUSTOMER_PENDING_AMOUNT_USING_NAME
					   , dtCustomerPendingAmount
					   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
					   , parVehicleNo);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtCustomerPendingAmount;
		}
	}
}
