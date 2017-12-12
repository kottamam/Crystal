#region Copyright
// ©Copyright 2017, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 25.11.2017
// Created By   : Noble
// Description  : Business class for customer details
// -------------------------------------------------------------------//
// Modified By              : 
// Modified Date            : 
// Modification Description : 

#endregion

#region Using Directives

using System;
using System.Data;
using System.Data.SqlClient;
using tv.Crystal.Data;
using tv.Crystal.Common.Constants;
using tv.Crystal.Common.Models;

#endregion

namespace tv.Crystal.Business
{
	public class CustomerBLL
	{
		/// <summary>
		/// To get customer list
		/// </summary>
		/// <returns>Customer List</returns>
		public static DataTable GetCustomerList()
		{
			DataTable dtCustomers;

			using (SqlConnection cnCustomers = new SqlConnection(tvConnection.ConnectionString))
			{
				cnCustomers.Open();

				try
				{
					//Calling data method for getting customer list
					dtCustomers = CustomerDAL.GetCustomerList(cnCustomers);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (cnCustomers.State == ConnectionState.Open || cnCustomers != null)
					{
						cnCustomers.Dispose();
						cnCustomers.Close();
					}
				}

				return dtCustomers; // Return datatable with account groups and ledger
			}
		}

		/// <summary>
		/// To get customer details
		/// </summary>
		/// <param name="customerId">Customer id</param>
		/// <returns>Customer details</returns>
		public static DataTable GetCustomerDetails(int customerId)
		{
			DataTable dtCustomer;

			using (SqlConnection cnCustomer = new SqlConnection(tvConnection.ConnectionString))
			{
				cnCustomer.Open();

				try
				{
					//Calling data method for getting customer details
					dtCustomer = CustomerDAL.GetCustomerDetails(cnCustomer, customerId);
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

				return dtCustomer; // Return datatable with customer details
			}
		}

		/// <summary>
		/// To check duplicate customer name
		/// </summary>
		/// <param name="customerId">Customer ID</param>
		/// <param name="customerName">Customer Name</param>
		/// <returns>Count of duplicate customer name</returns>
		public static int CheckDuplicateCustomerName(int customerId, string customerName)
		{
			using (SqlConnection cnCustomers = new SqlConnection(tvConnection.ConnectionString))
			{
				cnCustomers.Open();

				try
				{
					//Calling data method for getting count of duplicate customer name
					return CustomerDAL.CheckDuplicateCustomerName(cnCustomers, customerId, customerName);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (cnCustomers.State == ConnectionState.Open || cnCustomers != null)
					{
						cnCustomers.Dispose();
						cnCustomers.Close();
					}
				}
			}
		}

		/// <summary>
		/// To check duplicate vehicle number
		/// </summary>
		/// <param name="customerId">Customer id</param>
		/// <param name="vehicleNo">Vehicle Number</param>
		/// <returns>Count of duplicate vehicle number</returns>
		public static int CheckDuplicateVehicleNo(int customerId, string vehicleNo)
		{
			using (SqlConnection cnCustomers = new SqlConnection(tvConnection.ConnectionString))
			{
				cnCustomers.Open();

				try
				{
					//Calling data method for getting count of duplicate vehicle number
					return CustomerDAL.CheckDuplicateVehicleNo(cnCustomers, customerId, vehicleNo);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (cnCustomers.State == ConnectionState.Open || cnCustomers != null)
					{
						cnCustomers.Dispose();
						cnCustomers.Close();
					}
				}
			}
		}

		/// <summary>
		/// To insert/update customer
		/// </summary>
		/// <param name="customer">Customer details</param>
		/// <returns>Customer id</returns>
		public static int InsertUpdateCustomer(ref Customer customer)
		{
			try
			{
				using (SqlConnection cnCustomer = new SqlConnection(tvConnection.ConnectionString))
				{
					cnCustomer.Open();

					using (SqlTransaction tranCustomer = cnCustomer.BeginTransaction())
					{
						try
						{
							// Calling data method for inserting/updating customer
							customer.CustomerId = CustomerDAL.InsertUpdateCustomer(tranCustomer, ref customer);
							tranCustomer.Commit();
						}
						catch (Exception ex)
						{
							if (tranCustomer != null)
								tranCustomer.Rollback();
							throw ex;
						}
						finally
						{
							if (cnCustomer != null && cnCustomer.State == ConnectionState.Open)
							{
								cnCustomer.Close();
								cnCustomer.Dispose();
							}
						}
					}
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			return customer.CustomerId; // Return customer id
		}

		/// <summary>
		/// To delete customer
		/// </summary>
		/// <param name="customerId">Customer Id</param>
		/// <param name="userId">User Id</param>
		public static void DeleteCustomer(int customerId, int userId)
		{
			try
			{
				using (SqlConnection cnCustomer = new SqlConnection(tvConnection.ConnectionString))
				{
					cnCustomer.Open();

					using (SqlTransaction tranCustomer = cnCustomer.BeginTransaction())
					{
						try
						{
							// Calling data method for deleting customer
							CustomerDAL.DeleteCustomer(tranCustomer, customerId, userId);
							tranCustomer.Commit();
						}
						catch (Exception ex)
						{
							if (tranCustomer != null)
								tranCustomer.Rollback();
							throw ex;
						}
						finally
						{
							if (cnCustomer != null && cnCustomer.State == ConnectionState.Open)
							{
								cnCustomer.Close();
								cnCustomer.Dispose();
							}
						}
					}
				}
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// To get customer pending amount using vehicle number
		/// </summary>
		/// <param name="vehicleNo">Vehicle number</param>
		/// <returns>Customer details with pending amount</returns>
		public static DataTable GetCustomerPendingAmountUsingVehicleNo(string vehicleNo)
		{
			DataTable dtCustomer;

			using (SqlConnection cnCustomer = new SqlConnection(tvConnection.ConnectionString))
			{
				cnCustomer.Open();

				try
				{
					//Calling data method for getting customer pending amount
					dtCustomer = CustomerDAL.GetCustomerPendingAmountUsingVehicleNo(cnCustomer, vehicleNo);
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

				return dtCustomer; // Return datatable with customer pending amount
			}
		}

		/// <summary>
		/// To get customer pending amount using name
		/// </summary>
		/// <param name="customerName">Customer Name</param>
		/// <returns>Customer details with pending amount</returns>
		public static DataTable GetCustomerPendingAmountUsingName(string customerName)
		{
			DataTable dtCustomer;

			using (SqlConnection cnCustomer = new SqlConnection(tvConnection.ConnectionString))
			{
				cnCustomer.Open();

				try
				{
					//Calling data method for getting customer pending amount
					dtCustomer = CustomerDAL.GetCustomerPendingAmountUsingName(cnCustomer, customerName);
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

				return dtCustomer; // Return datatable with customer pending amount
			}
		}
	}
}
