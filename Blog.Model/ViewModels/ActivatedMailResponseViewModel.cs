using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Model.ViewModels
{
	public class ActivatedMailResponseViewModel
	{
		public ActivatedMailResponseViewModel()
		{
			this.TagList = new List<SelectListItem>();
		}
		public int UserId { get; set; }
		public List<SelectListItem> TagList { get; set; }
	}
}
