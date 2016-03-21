using System;
using OnlinerTracker.DataAccess.Enteties;

namespace OnlinerTracker.BusinessLogic.Extensions
{
	public static class Parsers
	{
		public static Product ParseToEntity(this Models.Product product, DateTime? createdOn = null)
		{
			return new Product
			{
				Id = product.Id,
				CreatedOn = createdOn ?? DateTime.Now,
				Name = product.Name,
				FullName = product.FullName,
				Description = product.Description,
				HtmlUrl = product.HtmlUrl,
				MinPrice = product.Price?.Min ?? 0,
				MaxPrice = product.Price?.Max ?? 0,
				ImageUrl = product.Image != null ?
					!string.IsNullOrWhiteSpace(product.Image.Icon) ?
						product.Image.Icon :
						product.Image.Header :
					string.Empty
			};
		}

		public static User ParseToEntity(this Models.UserInfo user, DateTime? createdOn = null)
		{
			return new User
			{
				SocialId = user.UserId,
				FirstName = user.FirstName,
				PhotoUri = user.PhotoUri,
				CreatedOn = createdOn ?? DateTime.Now
			};
		}

	}
}