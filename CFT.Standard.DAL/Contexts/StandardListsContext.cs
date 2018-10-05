using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharepointEmulator;

using SharepointEmulator.Attributes;
using SharepointEmulator.Context;
using SharepointEmulator.Models;

namespace CFT.Standard.DAL.Contexts
{
	public class StandardListsContext : SharepointListsContextEmulator
	{
		public StandardListsContext(bool seed) : base()
		{
			if (seed)
			{
				Seed();
			}
		}

		private void Seed()
		{
			
			ClientContext.SiteUsers.AddItem(new UserEmulator()
				{Login = "ftc\\testuser", DisplayName = "Иванов Иван Иванович"});

			var authorId = ClientContext.EnsureUser("ftc\\testuser").Id;

			Banks.AddItem(
				new DAL.Models.Bank() {Title = "test1", Author = new SharepointLookupFieldEmulator() {LookupId = authorId}});
			Banks.AddItem(
				new DAL.Models.Bank() { Title = "test2", Author = new SharepointLookupFieldEmulator() { LookupId = authorId } });

			Banks.AddItem(
				new DAL.Models.Bank() { Title = "test3", Author = new SharepointLookupFieldEmulator() { LookupId = authorId } });

		}

		[SharepointListEmulatorAttribute(ListName = "Банки")]
		public SharepointListEmulator<DAL.Models.Bank> Banks { get; set; }
	}
}
