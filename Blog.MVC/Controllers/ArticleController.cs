using Blog.BLL;
using Blog.Model.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Blog.MVC.Controllers
{
	public class ArticleController : Controller
	{
		private IArticleManager _articleManager;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public ArticleController(IArticleManager articleManager, IWebHostEnvironment webHostEnvironment)
		{
			_articleManager = articleManager;
			_webHostEnvironment = webHostEnvironment;
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
			var tagList = _articleManager.GetTagsWithSearch(key).Select(x => new SelectListItem()
			{
				Selected = false,
				Text = x.TagName,
				Value = x.TagId.ToString()

			}).ToList();
			return Json(tagList);
		}

		[HttpPost]
		public IActionResult CreateArticle(IFormFile file, string data)
		{
			string ext = Path.GetExtension(file.FileName);
			string resimAd = Guid.NewGuid() + ext;
			string dosyaYolu = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", resimAd);
			using (var stream = new FileStream(dosyaYolu, FileMode.Create))
			{
				file.CopyTo(stream);
			}
			ArticleCreateViewModel formData = JsonConvert.DeserializeObject<ArticleCreateViewModel>(data);
			List<int> tagIds = new List<int>();
			if (!string.IsNullOrWhiteSpace(formData.Tags))
			{
				tagIds = formData.Tags.Split(',').ToList().Select(x => int.Parse(x)).ToList();
			}
			var result = _articleManager.ArticleAddOrUpdateasDraft(new ArticleCreateViewModel()
			{
				Title = formData.Title,
				Content = formData.Content,
				CoverPictureUrl = resimAd,
				TagIds = tagIds
			});
			return Json(result);
		}

	}
}
