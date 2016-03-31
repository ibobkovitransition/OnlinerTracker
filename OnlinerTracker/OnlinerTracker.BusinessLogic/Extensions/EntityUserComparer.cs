using System.Collections.Generic;
using EntityUser = OnlinerTracker.DataAccess.Enteties.User;

namespace OnlinerTracker.BusinessLogic.Extensions
{
	public class EntityUserComparer : IEqualityComparer<EntityUser>
	{
		public bool Equals(EntityUser x, EntityUser y)
		{
			return x.Id == y.Id;
		}

		public int GetHashCode(EntityUser obj)
		{
			return obj.Id;
		}
	}
}