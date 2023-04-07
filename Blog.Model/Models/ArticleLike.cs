using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Models
{
    public class ArticleLike : Base
    {
        public int ArticleId { get; set; }

        public int UserId { get; set; } 

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

    }
}
