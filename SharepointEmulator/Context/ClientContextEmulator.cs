using SharepointEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharepointEmulator.Attributes;
namespace SharepointEmulator.Context
{
	public class ClientContextEmulator
	{
		private Dictionary<string, ListEmulator> lists = new Dictionary<string, ListEmulator>();		

		public ClientContextEmulator()
		{
			SiteUsers = new SharepointListEmulator<UserEmulator>("SiteUsers", this);
		}
		
		public UserEmulator EnsureUser(string login)
		{
			return SiteUsers.GetItems(CamlexNET.Camlex.Query().Where(
				m => (string) m[SiteUsersList.Login] == login))[0];
		}

		public SharepointListEmulator<UserEmulator> SiteUsers;

		public Dictionary<string, ListEmulator> Lists
		{
			get
			{
				return lists;
			}
		}

		public void AddList(string title)
		{
			lists.Add(title, new ListEmulator(this));
		}

		public ListEmulator GetListByTitle(string title)
		{
			if (!lists.ContainsKey(title))
			{
				throw new Exception("List not found");				
			}
			return lists[title];			
		}		
	}
}
