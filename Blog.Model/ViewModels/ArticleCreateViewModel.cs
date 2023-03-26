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
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
    }
}
