using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPR_MVC.Data;
using TPR_MVC.Models;

namespace TPR_MVC.Services
{
	public interface IDataSource
	{
		IEnumerable<Invoice> GetInvoice();
	}
}
