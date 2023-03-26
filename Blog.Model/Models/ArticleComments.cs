using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Models
{
    public class ArticleComments : Base
    {
        public int ArticleId { get; set; }

        public int UserId { get; set; }
        public string CommentText { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

    }
}
