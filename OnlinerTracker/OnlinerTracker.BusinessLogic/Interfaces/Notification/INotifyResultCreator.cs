using System;
using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.Notification;

namespace OnlinerTracker.BusinessLogic.Interfaces.Notification
{
	public interface INotifyResultCreator
	{
		IEnumerable<NotifyResult> Create(TimeSpan sendOn);
	}
}