using SharepointEmulator.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SharepointEmulator.Helpers
{
	public class OperationHelper
	{
		public static CompareOperation ParseOperation(XElement element)
		{
			var result = new CompareOperation();
			result.OperationType = element.Name.LocalName;

			result.FieldName = (from product in element.Elements("FieldRef")
								   select product.Attribute("Name").Value
			).FirstOrDefault();

			result.ValueType = (from product in element.Elements("Value")
								   select product.Attribute("Type").Value
			).FirstOrDefault();

			result.Value = (from product in element.Elements("Value")
							   select product.Value
			).FirstOrDefault();
			return result;

		}
	}
}
