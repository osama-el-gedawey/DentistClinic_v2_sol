using Microsoft.AspNetCore.Mvc;

namespace DentistClinic.Controllers
{
	public class ContactsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
