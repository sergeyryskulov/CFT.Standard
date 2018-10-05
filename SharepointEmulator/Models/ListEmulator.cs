using SharepointEmulator.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharepointEmulator.Models
{
	public class ListEmulator :  List<ListItemEmulator>
	{
		private ClientContextEmulator _clentContext;

		public ListEmulator(ClientContextEmulator clientContext)
		{
			_clentContext = clientContext;
		}

		public void ItemUpdating(ListItemEmulator item)
		{
			ItemAdding(item);
		}

		public void ItemAdding(ListItemEmulator item)
		{
			foreach (var field in item.GetAllFields())
			{
				if (item[field] !=null && item[field] is SharepointLookupFieldEmulator)
				{
					var lookupId = ((SharepointLookupFieldEmulator) item[field]).LookupId;
					((SharepointLookupFieldEmulator)item[field]).LookupValue= _clentContext.SiteUsers.GetItemById(lookupId).DisplayName;
				}
			}
		}
	}
}
