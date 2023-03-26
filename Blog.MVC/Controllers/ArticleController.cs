using Blog.BLL;
using Blog.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Blog.MVC.Controllers
{
	public class ArticleController : Controller
	{
		private IArticleManager _articleManager;
		public ArticleController(IArticleManager articleManager)
		{
			_articleManager = articleManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		//Article Yazma alanı. Burada ckEditör tarzı birşey olacak.
		[HttpGet]
		public IActionResult WriteArticle()
		{

			return View(new ArticleViewModel());
		}
		[HttpPost]
		public IActionResult WriteArticle(int id)
		{
			//_articleManager.ArticleAddOrUpdateasDraft();
			return View(new ArticleViewModel());
		}

		//article'a tıklandığında içeriğinin okunacağa alan. 
		//tagler altta belirtilecek.
		//Beğen, yorum yap butonları

		public IActionResult ArticleDetail()
		{
			return View();
		}
		//ViewComponent
		// Yayınlanan makaleye bağlı yorumlar yer alacak. Kullanıcı giriş yapmışsa yorum yazabilecek. 
		public IActionResult Comments()
		{
			return View();
		}

		//View Component yapısı
		//Makalenin detail sayfasında yazarın diğer makalelerinin altında yer alacağı yatay bir alan.
		public IActionResult ArticleByUserId()
		{
			return View();

		}
		//Burada kullanıcının takip ettiği tag id ye göre makaleler listelenecek. (sayfa formatı)
		//Tab kullanımı düşünülebilir. 
		public IActionResult ArticleByTag()
		{
			return View();

		}

		//View Component
		//sağ tarafta gösterilecek liste halinde
		public IActionResult MostReadArticle()
		{
			return View();
		}
		//View Component
		//sağ tarafta gösterilecek liste halinde
		public IActionResult TrendingArticle()
		{
			return View();
		}

		//View Component
		//sağ tarafta gösterilecek liste halinde
		//kullanıcının takip etmediği tagler yer alacak. İlgili tag Satfasına yönlendirilecek. 
		public IActionResult RecommendedTag()
		{
			return View();
		}

		[HttpPost]
		public IActionResult GetTags(string key)
		{
			TempData["Tags"] = _articleManager.GetAllTags().Select(x => new SelectListItem()
			{
				Selected = false,
				Text = x.TagName,
				Value = x.TagId.ToString()

			}).ToList();

			var TagList = TempData["Tags"] as List<SelectListItem>;
			var res = TagList.Where(x=> x.Text.Contains(key)).ToList();
			return Json(res);
		}

		//[HttpPost]
		//public IActionResult CreateArticle([FromBody] ArticleCreateViewModel model)
		//{
		//	//var result = _accountManager.SignIn(model);
		//	return Json("");
		//}

		[HttpPost]
		public IActionResult CreateArticle(IFormFile file, string data)
		{
			ArticleCreateViewModel formData = JsonConvert.DeserializeObject<ArticleCreateViewModel>(data);
			return Json("");
		}

	}
}
