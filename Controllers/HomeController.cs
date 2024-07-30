using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		// Group of different action methods
		public IActionResult Index()
		{
			return View();
		}
	}
}
