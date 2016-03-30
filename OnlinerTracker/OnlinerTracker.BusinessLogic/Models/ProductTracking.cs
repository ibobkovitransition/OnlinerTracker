using OnlinerTracker.BusinessLogic.Models.Basis;
using OnlinerTracker.BusinessLogic.Models.Onliner;
using OnlinerTracker.BusinessLogic.Models.User;

namespace OnlinerTracker.BusinessLogic.Models
{
	public class ProductTracking : BaseModel
	{
		public int ProductId { get; set; }

		public Product Product { get; set; }

		public int UserInfoId { get; set; }

		public UserInfo UserInfo { get; set; }

		public bool Enabled { get; set; }

		public bool Increase { get; set; }

		public bool Decrease { get; set; }
	}
}