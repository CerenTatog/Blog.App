using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Model.Models;

namespace Blog.Model.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ReadCount { get; set; }
        public int ReadTime { get; set; }
        public int UserId { get; set; }
        public string AuthorName { get; set; }
        public string ArticleUrl { get; set; }
        public string? CoverPictureUrl { get; set; }
        public ArticleStatusEnum Status { get; set; }
        public int Likes { get; set; }
        public List<ArticleLike>? LikeList { get; set; }
        public List<Tag>? ArticleTags { get; set; }
        public List<ArticleComments>? ArticleComments { get; set; }

        public DateTime? UpdatedTime { get; set; }
        public DateTime? CreatedTime { get; set; }




    }
}
