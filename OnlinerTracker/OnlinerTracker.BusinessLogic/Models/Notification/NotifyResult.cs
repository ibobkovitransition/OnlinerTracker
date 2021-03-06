﻿using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.User;

namespace OnlinerTracker.BusinessLogic.Models.Notification
{
	public class NotifyResult
	{
		public UserInfo UserInfo { get; set; }

		public IEnumerable<NotifyProduct> NotifyProducts { get; set; }

		public NotifyResult()
		{
			NotifyProducts = new List<NotifyProduct>();
		}
	}
}