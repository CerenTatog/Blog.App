using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Model.Models;

namespace Blog.Model.ViewModels
{
	public class ArticleCreateViewModel
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Content { get; set; }
		public string? CoverPictureUrl { get; set; }
		public string? Tags { get; set; }
		public List<int>? TagIds { get; set; }
		public int ReadTime { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime UpdatedTime { get; set;}

	}
}
