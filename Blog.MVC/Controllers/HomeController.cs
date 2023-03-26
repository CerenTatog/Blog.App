using System.Diagnostics;
using Blog.BLL.Helper;
using Blog.Model.ViewModels;
using Blog.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			UserViewModel user = HttpContext.Session.Get<UserViewModel>("user");
			if (user == null)
			{
				return View();
			}
			return View("UserHome");
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult Search()
		{
			//burada tablar yer alacak. //makaleler/insanlar/başlık vs.
			//sağ tarafta topic matching alanı onun altında yazılan text iel ilgili uyuşan profiller
			return View();

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}