using System.Diagnostics;
using Blog.BLL;
using Blog.BLL.Helper;
using Blog.Model.ViewModels;
using Blog.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.MVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IArticleManager _articleManager;
		public HomeController(ILogger<HomeController> logger, IArticleManager articleManager)
		{
			_logger = logger;
			_articleManager = articleManager;
		}

		public IActionResult Index()
		{
			var tagList = _articleManager.GetAllTags().Select(x => new SelectListItem()
			{
				Selected = false,
				Text = x.TagName,
				Value = x.TagId.ToString()

			}).ToList();
			tagList.Insert(0, new SelectListItem()
			{
				Selected = false,
				Text = "Sizin İçin",
				Value = "0"
			});
			ViewBag.Taglist = tagList;
			//TempData.Set("key", tagList);
			//TempData["TagList"] = tagList;
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

		[HttpPost]
		public IActionResult GetArticleByTagId([FromBody] GetArticleByTagRequestModel model)
		{
			return ViewComponent("MyTagArticles", new {tagId = model.TagId});
		}



	}
}