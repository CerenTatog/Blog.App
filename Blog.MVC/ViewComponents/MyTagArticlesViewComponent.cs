using Blog.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.ViewComponents
{
	public class MyTagArticlesViewComponent : ViewComponent
	{
		private readonly IArticleManager _articleManager;

		public MyTagArticlesViewComponent(IArticleManager articleManager)
		{
			_articleManager = articleManager;
		}

		public async Task<IViewComponentResult> InvokeAsync(int tagId=0)
		{
			var list = _articleManager.GetMostReadArticles();

			return View(list);
		}

	}
}
