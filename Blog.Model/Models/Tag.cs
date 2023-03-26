using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Models
{
    public class Tag : Base
    {
        public string TagName { get; set; }

        public string SearchText { get; set; }
        public string TagUrl { get; set; }

        public virtual ICollection<ArticleTag>? ArticleTags { get; set; }

        public virtual ICollection<UserTag>? UserTags { get; set; }

        public Tag()
        {
            ArticleTags = new List<ArticleTag>();
            UserTags = new List<UserTag>();
        }
    }
}
