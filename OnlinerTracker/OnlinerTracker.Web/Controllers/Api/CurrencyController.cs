using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using OnlinerTracker.BusinessLogic.Interfaces.ModelWrappers;
using OnlinerTracker.BusinessLogic.Models.Exchange;

namespace OnlinerTracker.Web.Controllers.Api
{
	public class CurrencyController : ApiControllerBase
	{
		private readonly ICurrencyService currencyService;

		public CurrencyController(ICurrencyService currencyService)
		{
			this.currencyService = currencyService;
		}

		[HttpGet]
		[ResponseType(typeof (IEnumerable<Currency>))]
		[Route("currency")]
		public IHttpActionResult CurrencyList()
		{
			return Ok(currencyService.CurrencyList());
		}
	}
}