using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.ViewModels
{
	public class UserTagViewModel
	{
		public int UserId { get; set; }

		public string UserName { get; set; }

		public int TagId { get; set; }

		public string TagName { get; set; }

	}
}
