using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.ViewModels
{
	public class SelectTagUserViewModel
	{
		public SelectTagUserViewModel()
		{
			this.TagIds = new List<string>();
		}
		public int UserId { get; set; }
		public List<string> TagIds { get; set; }
	}
}
