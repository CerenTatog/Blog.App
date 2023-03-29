using Blog.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Blog.MVC.ViewComponents
{
	public class AllTagViewComponent : ViewComponent
	{
		private readonly IArticleManager _articleManager;

		public AllTagViewComponent(IArticleManager articleManager)
		{
			_articleManager = articleManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var list = _articleManager.GetAllTags();

			return View(list);
		}

	}
}
