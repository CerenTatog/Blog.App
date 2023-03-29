using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.ViewModels
{
	public class AddCommentViewModel
	{
		public string Comment { get; set; }
		public int ArticleId { get; set; }
	}
}
