using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFT.Standard.Domain.Repositories;
using System.Web;

namespace CFT.Standard.DAL.Repositories
{
	public class HttpRepository : IHttpRepository
	{
		public string GetCurrentUserLogin()
		{
			var login = HttpContext.Current.User.Identity.Name;
			if (login.Contains("|"))
			{
				login= login.Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries)[1];
			}

			return login;

		}

	}
}
