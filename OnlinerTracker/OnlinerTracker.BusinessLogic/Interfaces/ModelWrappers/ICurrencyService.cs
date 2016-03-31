using System.Collections.Generic;
using OnlinerTracker.BusinessLogic.Models.Exchange;

namespace OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers
{
	public interface ICurrencyService
	{
		IEnumerable<Currency> CurrencyList();
	}
}