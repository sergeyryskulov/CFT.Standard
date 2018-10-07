using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharepointEmulator;

using SharepointEmulator.Attributes;
using SharepointEmulator.Context;
using SharepointEmulator.Models;
using CFT.Standard.Domain.Models;

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
			//Эмулятор шерпоинта не должен ни от чего зависеть, в том числе и от AD
			//Поэтомы мы эмулируем AD. Впишите свой логин если его нет!
			ClientContext.SiteUsers.AddItem(new UserEmulator()
				{Login = "ftc\\testuser", DisplayName = "Иванов Иван Иванович"});

			ClientContext.SiteUsers.AddItem(new UserEmulator()
				{ Login = "USER\\asus", DisplayName = "Рыскулов Сергей Николаевич" });

		    //Теперь заполняем списки
			var author =
				new SharepointLookupFieldEmulator()
				{
					LookupId = ClientContext.EnsureUser("ftc\\testuser").Id
				};
				
			var created = new DateTime(2018, 10, 1, 10, 0, 0);

			Banks.AddItem(
				new Bank() { Title = "test", Bik = "123", Created = created, Author = author });

			Banks.AddItem(
				new Bank() { Title = "test2", Bik = "345", Created  = created, Author = author});

			Banks.AddItem(
				new Bank() { Title = "test3", Bik = "12121", Created = created, Author = author });


		}

		[SharepointListEmulatorAttribute(ListName = "Банки")]
		public SharepointListEmulator<Bank> Banks { get; set; }
	}
}
