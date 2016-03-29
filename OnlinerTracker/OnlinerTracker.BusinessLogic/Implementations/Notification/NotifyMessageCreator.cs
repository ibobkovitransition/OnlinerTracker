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
				// TODO: докрутить increase, decrease
				builder.Append($"{notifyProduct.Product.FullName}'s has been changed\n");

				if (notifyProduct.MinPrice != notifyProduct.Product.Price.Min)
				{
					builder.Append($"Old min {notifyProduct.MinPrice}\n");
					builder.Append($"New min {notifyProduct.Product.Price.Min}\n");
				}

				if (notifyProduct.MaxPrice != notifyProduct.Product.Price.Max)
				{
					builder.Append($"Old max {notifyProduct.MaxPrice}\n");
					builder.Append($"New max {notifyProduct.Product.Price.Max}\n");
				}
				
				builder.Append('\n');
			}

			return $"Dear {notifyResult.UserInfo.FirstName}\n{builder}";
		}
	}
}