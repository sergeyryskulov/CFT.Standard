using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointEmulator.Attributes
{
	public class SharepointListEmulatorAttribute : Attribute
	{
		public string ListName { get; set; }
	}
}
