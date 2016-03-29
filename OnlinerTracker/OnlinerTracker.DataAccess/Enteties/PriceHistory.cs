using OnlinerTracker.DataAccess.Enteties.Basis;

namespace OnlinerTracker.DataAccess.Enteties
{
	public class PriceHistory : BaseEntity
	{
		public int ProductId { get; set; }

		public Product Product { get; set; }

		public decimal MinPrice { get; set; }

		public decimal MaxPrice { get; set; }

		// добавить свойство isNotified
		// пилить отдельную таблицу пока не вижу смысла. Если нужно будет фиксировать время рассылки и получателей - сделаю
	}
}