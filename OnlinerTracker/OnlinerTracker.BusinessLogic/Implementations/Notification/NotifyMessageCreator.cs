using System.Text;
using OnlinerTracker.BusinessLogic.Interfaces.Notification;
using OnlinerTracker.BusinessLogic.Models.Notification;

namespace OnlinerTracker.BusinessLogic.Implementations.Notification
{
	public class NotifyMessageCreator : INotifyMessageCreator
	{
		public string Create(NotifyResult notifyResult)
		{
			var builder = new StringBuilder();

			foreach (var notifyProduct in notifyResult.NotifyProducts)
			{
				builder.Append($"{notifyProduct.Product.FullName}\n");

				if (notifyProduct.PriceHistory.MinPrice != notifyProduct.Product.Price.Min)
				{
					if (notifyProduct.PriceHistory.MinPrice < notifyProduct.Product.Price.Min)
					{
						builder.Append($"Min price increased from {notifyProduct.Product.Price.Min} to {notifyProduct.PriceHistory.MinPrice}\n");
					}

					if (notifyProduct.PriceHistory.MinPrice > notifyProduct.Product.Price.Min)
					{
						builder.Append($"Min price decreased from {notifyProduct.PriceHistory.MinPrice} to {notifyProduct.Product.Price.Min}\n");
					}
				}

				if (notifyProduct.PriceHistory.MaxPrice != notifyProduct.Product.Price.Max)
				{
					if (notifyProduct.PriceHistory.MaxPrice < notifyProduct.Product.Price.Max)
					{
						builder.Append($"Max price increased from {notifyProduct.Product.Price.Min} to {notifyProduct.PriceHistory.MaxPrice}\n");
					}

					if (notifyProduct.PriceHistory.MaxPrice > notifyProduct.Product.Price.Max)
					{
						builder.Append($"Max price decreased from {notifyProduct.PriceHistory.MaxPrice} to {notifyProduct.Product.Price.Min}\n");
					}
				}

				builder.Append('\n');
			}

			return $"Dear {notifyResult.UserInfo.FirstName},\n{builder}";
		}
	}
}