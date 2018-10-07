using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFT.Standard.DAL.Contexts;
using SharepointEmulator.Models;
using CFT.Standard.Domain.Repositories;

namespace CFT.Standard.DAL.Repositories
{
	public class CurrentUserRepository : ICurrentUserRepository
	{
		private IHttpRepository _httpRepository;
		private StandardListsContext _ctx;

		public CurrentUserRepository(
			IHttpRepository httpRepository,
			StandardListsContext ctx)
		{
			_ctx = ctx;
			_httpRepository = httpRepository;
		}

		public SharepointLookupFieldEmulator GetCurrentUserLookupValue()
		{
			var currentUserLogin = _httpRepository.GetCurrentUserLogin();
			var currentUser = _ctx.ClientContext.EnsureUser(currentUserLogin);
			return new SharepointLookupFieldEmulator()
			{
				LookupId = currentUser.Id,
				LookupValue = currentUser.DisplayName
			};
		}
	}
}