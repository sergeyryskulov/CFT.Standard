using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SharepointEmulator.Helpers
{
	public class CamlHelper<T> where T : new()
	{

		XElement where;

		public CamlHelper(string camlQuery)
		{
			var camlRoot = XDocument.Parse(camlQuery);

			where = camlRoot.Root.Element("Where").Elements().FirstOrDefault();

		}

		public string SpecialConvert(
		string camlType,
		string fieldValue)
		{
			if (camlType == "Boolean")
			{
				return fieldValue.Replace("0", "false").Replace("1", "true");
			}
			else if (camlType == "Currency" ||
				camlType == "Integer" ||
				camlType == "Counter" ||
				camlType == "Number")
			{
				return fieldValue.Replace(".", ",");
			}
			return fieldValue;
		}

		public bool CheckWhere(ListItemEmulator item)
		{
			return CheckCamlElement(where, item);
		}

		public bool CheckCamlElement(XElement element, ListItemEmulator item)
		{
			string operationName = "" + element.Name;
			switch (operationName)
			{
				case "And":
					return
						CheckCamlElement(element.Elements().ElementAt(0), item) &&
						CheckCamlElement(element.Elements().ElementAt(1), item);

				case "Or":
					return
						CheckCamlElement(element.Elements().ElementAt(0), item) ||
						CheckCamlElement(element.Elements().ElementAt(1), item);
				case "IsNull":
				case "IsNotNull":
					return CheckCamlNullOperation(element, item);
				default:
					return CheckCamlCompareOperation(element, item);

			}
			return false;
		}


		private bool CheckCamlNullOperation(XElement element, ListItemEmulator listItem)
		{

			var fieldName = "" + element.Element("FieldRef").Attribute("Name");
			var fieldValue = listItem[fieldName];
			if (element.Name == "IsNull")
			{
				return fieldValue == null;
			}

			if (element.Name == "IsNotNull")
			{
				return fieldValue != null;
			}
			return false;
		}

		private bool CheckCamlCompareOperation(XElement node, ListItemEmulator listItem)
		{

			var operation = OperationHelper.ParseOperation(node);

			var leftOperand = listItem[operation.FieldName];
			var parsedValue = SpecialConvert(operation.ValueType, operation.Value);
			var rightOperand = Convert.ChangeType(parsedValue, new ConvertationHelper<T>().GetType(operation.FieldName));
			var operationType = operation.OperationType;
			if (operationType == "Contains" || operationType == "BeginsWith")
			{
				if (operationType == "Contains")
				{
					return ("" + leftOperand).IndexOf("" + rightOperand, StringComparison.OrdinalIgnoreCase) >= 0;
				}
				if (operationType == "BeginsWith")
				{
					return ("" + leftOperand).IndexOf("" + rightOperand, StringComparison.OrdinalIgnoreCase) == 0;
				}


			}

			if (operationType == "Eq" || operationType == "Neq")
			{
				if (operationType == "Eq")
				{
					return rightOperand.Equals(leftOperand);
				}
				else
				{
					return !rightOperand.Equals(leftOperand);
				}

			}
			else
			{
				var rightComparible = (IComparable)rightOperand;
				var index = rightComparible.CompareTo(leftOperand);
				if (operationType == "Gt")
				{
					return index < 0;
				}
				if (operationType == "Geq")
				{
					return index <= 0;
				}
				if (operationType == "Lt")
				{
					return index > 0;
				}
				if (operationType == "Leq")
				{
					return index >= 0;
				}


			}
			return false;



		}
	}
}
