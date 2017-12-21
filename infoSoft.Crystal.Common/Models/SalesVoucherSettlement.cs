using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tv.Crystal.Common.Models
{
	public class SalesVoucherSettlement
	{
		#region Constructor
		public SalesVoucherSettlement()
		{
			SalesId = 0;
			Amount = 0.00M;
		}
		#endregion

		#region Public Methods
		public int SalesId
		{
			get;
			set;
		}

		public decimal Amount
		{
			get;
			set;
		}
		#endregion
	}
}
