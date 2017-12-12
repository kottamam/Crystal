#region Copyright
// ©Copyright 2017, tv Software Private Limited,  All rights reserved.
#endregion

#region Code history

// Created On   : 02.12.2017
// Created By   : Noble
// Description  : Business class for product details
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
using tv.Crystal.Data;

#endregion

namespace tv.Crystal.Business
{
	public class ProductBLL
	{
		/// <summary>
		/// To get product list
		/// </summary>
		/// <returns></returns>
		public static DataTable GetProductModelList()
		{
			DataTable dtProducts;

			using (SqlConnection cnProducts = new SqlConnection(tvConnection.ConnectionString))
			{
				cnProducts.Open();

				try
				{
					//Calling data method for getting product list
					dtProducts = ProductDAL.GetProductModelList(cnProducts);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (cnProducts.State == ConnectionState.Open || cnProducts != null)
					{
						cnProducts.Dispose();
						cnProducts.Close();
					}
				}

				return dtProducts; // Return datatable with product list
			}
		}

		/// <summary>
		/// To get details of a product model
		/// </summary>
		/// <param name="modelId">Product model id</param>
		/// <returns>Product model details</returns>
		public static DataTable GetProductModelDetails(int modelId)
		{
			DataTable dtProduct;

			using (SqlConnection cnProduct = new SqlConnection(tvConnection.ConnectionString))
			{
				cnProduct.Open();

				try
				{
					//Calling data method for getting product details
					dtProduct = ProductDAL.GetProductModelDetails(cnProduct, modelId);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (cnProduct.State == ConnectionState.Open || cnProduct != null)
					{
						cnProduct.Dispose();
						cnProduct.Close();
					}
				}

				return dtProduct; // Return datatable with product details
			}
		}

		/// <summary>
		/// To update product model rate
		/// </summary>
		/// <param name="modelId">Model id</param>
		/// <param name="rate">Rate</param>
		public static void UpdateProductModelRate(int modelId, decimal rate)
		{
			try
			{
				using (SqlConnection cnProduct = new SqlConnection(tvConnection.ConnectionString))
				{
					cnProduct.Open();

					using (SqlTransaction tranProduct = cnProduct.BeginTransaction())
					{
						try
						{
							// Calling data method for updating product rate
							ProductDAL.UpdateProductModelRate(tranProduct, modelId, rate);
							tranProduct.Commit();
						}
						catch (Exception ex)
						{
							if (tranProduct != null)
								tranProduct.Rollback();
							throw ex;
						}
						finally
						{
							if (cnProduct != null && cnProduct.State == ConnectionState.Open)
							{
								cnProduct.Close();
								cnProduct.Dispose();
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
		/// To get the product model rate
		/// </summary>
		/// <param name="modelId">Model id</param>
		/// <returns>Rate of product model</returns>
		public static decimal GetProductModelRate(int modelId)
		{
			decimal rate = 0;

			using (SqlConnection cnProduct = new SqlConnection(tvConnection.ConnectionString))
			{
				cnProduct.Open();

				try
				{
					//Calling data method for getting product rate
					rate = ProductDAL.GetProductModelRate(cnProduct, modelId);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (cnProduct.State == ConnectionState.Open || cnProduct != null)
					{
						cnProduct.Dispose();
						cnProduct.Close();
					}
				}

				return rate; // Return product rate
			}
		}

	}
}
