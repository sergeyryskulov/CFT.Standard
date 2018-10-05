using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharepointEmulator.Models;

namespace SharepointEmulator
{
	public class TestModel
	{
		public int ID { get; set; }		

		public string Title { get; set; }

		public SharepointLookupFieldEmulator Author { get; set; }
	}
}
