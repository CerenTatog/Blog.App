using Blog.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.ViewComponents
{
	public class MostReadArticlesViewComponent : ViewComponent
	{
		private readonly IArticleManager _articleManager;

		public MostReadArticlesViewComponent(IArticleManager articleManager)
		{
			_articleManager = articleManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var list = _articleManager.GetMostReadArticles;

			return View(list);
		}

	}
}
