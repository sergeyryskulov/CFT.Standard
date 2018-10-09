using SharepointEmulator.Models;

namespace CFT.Standard.DAL.Repositories
{
	public interface ICurrentUserRepository
	{
		SharepointLookupFieldEmulator GetCurrentUserLookupValue();
	}
}