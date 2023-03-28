using Blog.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.ViewComponents
{
	public class LatestArticlesViewComponent : ViewComponent
	{
		private readonly IArticleManager _articleManager;

		public LatestArticlesViewComponent(IArticleManager articleManager)
		{
			_articleManager = articleManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var list = _articleManager.GetLatestArtciles();

			return View(list);
		}
	}
}
