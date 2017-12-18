#region Copyright

// ©Copyright 2017, tv Software Private Limited, All rights reserved.

#endregion

#region Code history

// Created On  : 16.12.2017
// Created By  : Noble
// Description : This class includes member and accessor methods for sales voucher object.
//-----------------------------------------------------------------------------------------------------------------------------------------------------//
// Last Modified On         : 
// Last Modified By         : 
// Modification Description : 

#endregion

#region Using Directives

using System;
using tv.Crystal.Common.Models;

#endregion

namespace tv.Crystal.Common.Models
{
	public class SalesVoucher
	{
		#region Constructor

		public SalesVoucher()
		{
			SalesId = 0;
			CustomerId = 0;
			ModelId = 0;
			SalesDate = DateTime.Now;
			Quantity = 0;
			Rate = 0.00M;
			Discount = 0.00M;
			NetAmount = (Quantity * Rate) - Discount;
			ReceivedAmount = 0.00M;
			CreatedBy = ActiveUserSession.UserId;
		}
		#endregion

		#region Public Methods

		public int SalesId
		{
			get;
			set;
		}

		public int CustomerId
		{
			get;
			set;
		}

		public int ModelId
		{
			get;
			set;
		}

		public DateTime SalesDate
		{
			get;
			set;
		}

		public int Quantity
		{
			get;
			set;
		}

		public decimal Rate
		{
			get;
			set;
		}

		public decimal Discount
		{
			get;
			set;
		}

		public decimal NetAmount
		{
			get;
			set;
		}

		public decimal ReceivedAmount
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		#endregion
	}
}
