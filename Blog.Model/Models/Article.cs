using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model.Models
{
    public class Article : Base
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ReadCount { get; set; }
        public int ReadTime { get; set; }
        public int UserId { get; set; }
        public string ArticleUrl { get; set; }
        public string? CoverPictureUrl { get; set; }
        public ArticleStatusEnum Status { get; set; }
        public virtual ICollection<ArticleLike>? Likes { get; set; }
        public virtual ICollection<ArticleTag>? ArticleTags { get; set; }
        public virtual ICollection<ArticleComments>? ArticleComments { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public Article()
        {
            Likes = new List<ArticleLike>();
            ArticleTags = new List<ArticleTag>();
            ArticleComments = new List<ArticleComments>();
        }
    }
}
