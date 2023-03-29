using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.ViewModels
{
	public class ArticleByTagViewModel
	{
		public ArticleByTagViewModel()
		{
			this.Tags = new List<TagViewModel>();
		}
	    public List<TagViewModel> Tags { get; set; }
		public string Title { get; set; }

		public string Summary { get; set; }

		public string Content { get; set; }
		public string ArticleUrl { get; set; }

		public int UserId { get; set; }

		public string UserName { get; set; }
		public int ArticleId { get; set; }

		public int Likes { get; set; }

		public int ReadCount { get; set; }

		public int ReadTime { get; set; }

		public DateTime UpdatedTime { get; set; }
		public DateTime CreatedTime { get; set; }
		public string CreatedTimeStr { get; set; }
		public string UserPicUrl { get; set; }

		public string ArticleCoverPhoto { get; set; }





		





	}
}
