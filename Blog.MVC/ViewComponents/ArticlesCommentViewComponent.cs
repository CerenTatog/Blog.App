using Blog.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.ViewComponents
{
	public class ArticlesCommentViewComponent : ViewComponent
	{
		private readonly IArticleManager _articleManager;

		public ArticlesCommentViewComponent(IArticleManager articleManager)
		{
			_articleManager = articleManager;
		}

		public async Task<IViewComponentResult> InvokeAsync(int articleId)
		{
			var list = _articleManager.GetCommentArticles(articleId);

			return View(list);
		}

	}
}
