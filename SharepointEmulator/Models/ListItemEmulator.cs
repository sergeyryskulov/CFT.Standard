using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointEmulator
{
	public class ListItemEmulator
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();

		public int? Id { get; set; }


		public List<string> GetAllFields()
		{
			return dictionary.Keys.ToList();
		}
		public object this[string fieldName]
		{
			get
			{
				if (dictionary.ContainsKey(fieldName))
				{
					return dictionary[fieldName];
				}
				return null;
			}
			set
			{
				if (dictionary.ContainsKey(fieldName))
				{
					dictionary[fieldName] = value;
				}
				else
				{
					dictionary.Add(fieldName, value);
				}
				
			}

		}
	}
}
