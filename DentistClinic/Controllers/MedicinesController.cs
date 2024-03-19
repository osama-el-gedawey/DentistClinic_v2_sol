using Microsoft.AspNetCore.Mvc;

namespace DentistClinic.Controllers
{
	public class MedicinesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
