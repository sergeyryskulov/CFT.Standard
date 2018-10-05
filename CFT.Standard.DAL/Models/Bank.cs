using SharepointEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Standard.DAL.Models
{
	public class Bank
	{
		public string Title { get; set; }

		public SharepointLookupFieldEmulator Author { get; set; }

		public Domain.Models.Bank ToDomain()
		{
			return new Domain.Models.Bank()
			{
				Author = this.Author.LookupValue,
				Title = this.Title
			};
		}

	}
}
