using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [StringLength(21)]
        public string UserName { get; set; }
        //public string Password { get; set; }

        [EmailAddress(ErrorMessage ="Lütfen e-mail formatına uygun bir adres giriniz.")]
        public string Email { get; set; }

        public string PictureUrl { get; set; }

		[StringLength(100,ErrorMessage ="100 karakterden fazla giremezsiniz.")]
		public string ProfileDescription { get; set; }

        public string UserURL { get; set; }
        public List<ArticleViewModel> Articles { get; set; }
    }
}
