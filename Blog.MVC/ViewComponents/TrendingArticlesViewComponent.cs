using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Blog.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Model.ViewComponents
{
	public class TrendingArticlesViewComponent:ViewComponent
	{
		private readonly IArticleManager _articleManager;

		public TrendingArticlesViewComponent(IArticleManager articleManager)
		{
			_articleManager = articleManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var list = _articleManager.GetPopularArticles();

			return View(list);
		}
	}
}
