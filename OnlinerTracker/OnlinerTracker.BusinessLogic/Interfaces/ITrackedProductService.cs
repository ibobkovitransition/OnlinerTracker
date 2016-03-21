using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface ITrackedProductService
	{
		void Track(int productId, string hashedSocNetworkUserId);

		void Untrack(int productId, string hashedSocNetworkUserId);

		void Remove(int productId, string hashedSocNetworkUserId);
	}
}
