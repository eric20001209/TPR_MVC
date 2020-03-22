using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TPR_MVC.Data;
using TPR_MVC.Dto;
using TPR_MVC.Models;

namespace RTS.Controllers
{
    public class GeneralReportController : Controller
    {
		private readonly mtrk_taiping09Context _db;
		public GeneralReportController(mtrk_taiping09Context db)
		{
			_db = db;
		}
		public IActionResult Index()
        {
			//setup time filter
			var myfilter = new FilterDto();
			myfilter.Start = DateTime.Parse("01-01-2019");
			myfilter.End = DateTime.Parse("01-08-2019");

			var generalReport = new GeneralReportDto();
			var list = getInvices(myfilter);

            return View(list);
        }

		public List<GeneralReportDto> getGeneralReportList(FilterDto myfilter)
		{
			_db.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;

			var generalReport = new GeneralReportDto();
			var tills = _db.Orders.Select(o => o.StationId).Distinct();
			
			foreach (var t in tills)
			{
				var list = _db.Invoice
								.Where(i => myfilter.Start == null ? true : i.CommitDate >= myfilter.Start)
								.Where(i => myfilter.End == null ? true : i.CommitDate <= myfilter.End)
								.OrderByDescending(i => i.Id)
								.Take(20);
			}

			return new List<GeneralReportDto>();
		}

		public List<Invoice> getInvices(FilterDto myfilter)
		{
			var list = _db.Invoice
					.Where(i => myfilter.Start == null ? true : i.CommitDate >= myfilter.Start)
					.Where(i => myfilter.End == null ? true : i.CommitDate <= myfilter.End)
					.OrderByDescending(i => i.Id)
					.Take(10)
					.ToList();
			return list;
		}

    }
}