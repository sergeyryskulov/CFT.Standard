using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Standard.Domain.Repositories
{
	public interface IHttpRepository
	{
		string GetCurrentUserLogin();
	}
}
