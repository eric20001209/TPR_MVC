using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPR_MVC.Dto
{
	public class GeneralReportDto
	{
		public int Till { get; set; }
		IEnumerable<PaymentByMethodDto> PaymentByMethod = new List<PaymentByMethodDto>();
		public decimal? TotalbyPayment { get; set; }
		public decimal? TotalbyCategory { get; set; }
		IEnumerable<PaymentByCategoryDto> PaymentByCategory = new List<PaymentByCategoryDto>();
	}
}
