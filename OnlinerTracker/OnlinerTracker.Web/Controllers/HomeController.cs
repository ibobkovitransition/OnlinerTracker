﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace OnlinerTracker.Web.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult Index()
		{
			return View();
		}
	}
}
