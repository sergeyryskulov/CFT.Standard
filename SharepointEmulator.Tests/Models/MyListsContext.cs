using SharepointEmulator.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharepointEmulator.Attributes;

namespace SharepointEmulator.Tests.Models
{
	public class MyListsContext : SharepointListsContextEmulator
	{		

		[SharepointListEmulator(ListName ="TestList")]
		public SharepointListEmulator<TestModel> News { get; set; }
	}
}
