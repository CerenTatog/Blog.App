using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model.Models
{
    public class ArticleTag : Base
    {
        public int ArticleId { get; set; }

        public int TagId { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
