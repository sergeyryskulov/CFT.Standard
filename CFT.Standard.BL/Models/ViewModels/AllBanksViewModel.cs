using CFT.Standard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Standard.BL.Models.ViewModels
{
	public class AllBanksViewModel
	{
		public string Filter { get; set; }

		public List<Bank> Banks { get; set; }
	}
}
