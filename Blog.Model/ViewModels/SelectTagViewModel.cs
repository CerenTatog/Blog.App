using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.ViewModels
{
	public class SelectTagViewModel
	{
		public SelectTagViewModel()
		{
			this.TagList = new List<TagViewModel>();
		}
		public List<TagViewModel> TagList { get; set; }
	}
}
