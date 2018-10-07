using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CFT.Standard.Web.Helpers
{
	public class WebConvertationHelper
	{
		public static string ToDateFormat(DateTime? dateTime)
		{
			if (!dateTime.HasValue)
			{
				return "";
			}

			return dateTime?.ToString("dd.MM.yyyy");
			
		}
	}
}