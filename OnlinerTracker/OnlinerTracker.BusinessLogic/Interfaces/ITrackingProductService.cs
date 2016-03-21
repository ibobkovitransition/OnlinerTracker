namespace OnlinerTracker.BusinessLogic.Interfaces
{
	public interface ITrackingProductService
	{
		void Track(int productId, int userId);

		void Untrack(int productId, int userId);

		void Remove(int productId, int userId);
	}
}
