using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
			EmulateActiveDirectoryConnection();
			EmulateSharepointConnection();
		}

		private void EmulateActiveDirectoryConnection()
		{
			ClientContext.SiteUsers.AddItem(new UserEmulator()
				{ Login = "ftc\\testuser", DisplayName = "Иванов Иван Иванович" });

			//Мне нужно узнать дисплей нейм текущего сотрудника без коннекта к АД
		    //Пока смотрю под кем идет поток, позже сделаю другое решение
			var loginFromHttp = HttpContext.Current.User.Identity.Name;
			if (loginFromHttp.Contains("|"))
			{
				loginFromHttp = loginFromHttp.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries)[1];
			}

			var loginFromHttpWithoutDomain = loginFromHttp;
			if (loginFromHttpWithoutDomain.Contains("\\"))
			{
				loginFromHttpWithoutDomain = loginFromHttp.Split(new[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[1];
			}						
			var loginFromThread= UserPrincipal.Current;
			if (loginFromHttpWithoutDomain == loginFromThread.Name)
			{
				ClientContext.SiteUsers.AddItem(new UserEmulator()
				{Login = loginFromHttp, DisplayName = loginFromThread.DisplayName});
			}
			
		}

		private void EmulateSharepointConnection()
		{
			var author =
				new SharepointLookupFieldEmulator()
				{
					LookupId = ClientContext.EnsureUser("ftc\\testuser").Id
				};

			var created = new DateTime(2018, 10, 1, 10, 0, 0);

			Banks.AddItem(
				new Bank() {Title = "test", Bik = "123", Created = created, Author = author});

			Banks.AddItem(
				new Bank() {Title = "test2", Bik = "345", Created = created, Author = author});

			Banks.AddItem(
				new Bank() {Title = "test3", Bik = "12121", Created = created, Author = author});
		}

		[SharepointListEmulatorAttribute(ListName = "Банки")]
		public SharepointListEmulator<Bank> Banks { get; set; }
	}
}
