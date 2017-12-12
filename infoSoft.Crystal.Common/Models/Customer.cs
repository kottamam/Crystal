#region Copyright

// ©Copyright 2017, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 02.12.2017
// Created By  : Noble
// Description : This class includes member and accessor methods for customer object.
//-----------------------------------------------------------------------------------------------------------------------------------------------------//
// Last Modified On         : 
// Last Modified By         : 
// Modification Description : 

#endregion

#region Using Directives

using tv.Crystal.Common.Constants;

#endregion

namespace tv.Crystal.Common.Models
{
	public class Customer
	{
		#region Constructor

		public Customer()
		{
			CustomerId = 0;
			CustomerName = string.Empty;
			VehicleNumber = string.Empty;
			Address1 = string.Empty;
			Address2 = string.Empty;
			Phone = string.Empty;
			Mobile = string.Empty;
			IsInsertUpdateDelete = InsertUpdateDeleteMode.InsertMode;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Identification number of customer
		/// </summary>
		public int CustomerId
		{
			get;
			set;
		}

		/// <summary>
		/// Customer Name
		/// </summary>
		public string CustomerName
		{
			get;
			set;
		}

		/// <summary>
		/// Vehicle Number
		/// </summary>
		public string VehicleNumber
		{
			get;
			set;
		}

		/// <summary>
		/// House name/number of customer
		/// </summary>
		public string Address1
		{
			get;
			set;
		}

		/// <summary>
		/// Landmark of customer
		/// </summary>
		public string Address2
		{
			get;
			set;
		}

		/// <summary>
		/// Phone number of customer
		/// </summary>
		public string Phone
		{
			get;
			set;
		}

		/// <summary>
		/// Mobile number of customer
		/// </summary>
		public string Mobile
		{
			get;
			set;
		}

		public InsertUpdateDeleteMode IsInsertUpdateDelete
		{
			get;
			set;
		}

		#endregion
	}
}
