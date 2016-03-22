using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using OnlinerTracker.BusinessLogic.Interfaces;
using OnlinerTracker.BusinessLogic.Models;

namespace OnlinerTracker.Web.Controllers.Api
{
	public class CurrencyController : ApiControllerBase
	{
		private readonly ICurrencyService currencyService;

		public CurrencyController(ICurrencyService currencyService)
		{
			this.currencyService = currencyService;
		}

		[Route("currency")]
		[HttpGet]
		[ResponseType(typeof (IEnumerable<Currency>))]
		public IHttpActionResult CurrencyList()
		{
			return Ok(currencyService.CurrencyList());
		}
	}
}