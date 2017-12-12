#region Copyright
// ©Copyright 2017, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 02.12.2017
// Created By   : Noble
// Description  : Data class for product details
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
using tv.Crystal.Common.SqlHelper;

#endregion

namespace tv.Crystal.Data
{
	public class ProductDAL
	{
		/// <summary>
		/// To get product model list
		/// </summary>
		/// <param name="cnProducts">Connection object</param>
		/// <returns>Product model list</returns>
		public static DataTable GetProductModelList(SqlConnection cnProducts)
		{
			DataTable dtProductModels = new DataTable();

			try
			{
				SqlHelper.FillDatatable(cnProducts
					   , CommandType.StoredProcedure
					   , StoredProcedureConstants.GET_PRODUCT_MODEL_LIST
					   , dtProductModels
					   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtProductModels;
		}

		/// <summary>
		/// To get details of a product
		/// </summary>
		/// <param name="cnProduct">Connection object</param>
		/// <param name="modelId">Product model id</param>
		/// <returns>Product model details</returns>
		public static DataTable GetProductModelDetails(SqlConnection cnProduct, int modelId)
		{
			DataTable dtProductModelDetails = new DataTable();

			try
			{
				SqlParameter parModelId = new SqlParameter("@ModelID", modelId);

				SqlHelper.FillDatatable(cnProduct
					   , CommandType.StoredProcedure
					   , StoredProcedureConstants.GET_PRODUCT_MODEL_DETAILS
					   , dtProductModelDetails
					   , CrystalConstants.DEFAULT_COMMAND_TIME_OUT
					   , parModelId);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return dtProductModelDetails;
		}

		/// <summary>
		/// To update product model rate
		/// </summary>
		/// <param name="tranCustomer">Transaction object</param>
		/// <param name="modelId">Model id</param>
		/// <param name="rate">Rate</param>
		public static void UpdateProductModelRate(SqlTransaction tranCustomer, int modelId, decimal rate)
		{
			try
			{
				SqlParameter parModelId = new SqlParameter("@ModelID", modelId);
				SqlParameter parRate = new SqlParameter("@Rate", rate);

				SqlHelper.ExecuteNonQuery(tranCustomer
										, CommandType.StoredProcedure
										, StoredProcedureConstants.UPDATE_PRODUCT_MODEL_RATE
										, CrystalConstants.DEFAULT_COMMAND_TIME_OUT
										, parModelId
										, parRate);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// To get the rate of product model
		/// </summary>
		/// <param name="cnProduct">Connection object</param>
		/// <param name="modelId">Model id</param>
		/// <returns>Product model rate</returns>
		public static decimal GetProductModelRate(SqlConnection cnProduct, int modelId)
		{
			decimal rate = 0;

			try
			{
				SqlParameter parModelId = new SqlParameter("@ModelID", modelId);

				rate = (decimal)SqlHelper.ExecuteScalar(cnProduct
						, CommandType.StoredProcedure
						, StoredProcedureConstants.GET_PRODUCT_MODEL_RATE
						, CrystalConstants.DEFAULT_COMMAND_TIME_OUT
						, parModelId);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return rate;
		}
	}
}
