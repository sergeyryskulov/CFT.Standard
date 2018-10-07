using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharepointEmulator.Models;

namespace CFT.Standard.Domain.Models
{
	public class Bank
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Bik { get; set; }

		public SharepointLookupFieldEmulator Author { get; set; }

		public DateTime Created { get; set; }
		
	}
}
