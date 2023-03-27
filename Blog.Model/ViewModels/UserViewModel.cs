using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            this.Articles = new List<ArticleViewModel>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PictureUrl { get; set; }
        public string ProfileDescription { get; set; }
        public List<ArticleViewModel> Articles { get; set; }
    }
}
