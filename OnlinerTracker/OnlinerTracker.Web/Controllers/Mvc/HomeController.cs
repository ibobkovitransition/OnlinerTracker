using System;
using System.Web.Mvc;
using OnlinerTracker.BusinessLogic.Abstract;

namespace OnlinerTracker.Web.Controllers.Mvc
{
	public class HomeController : Controller
	{
		public ViewResult Index()
		{
			return View();
		}
	}
}
