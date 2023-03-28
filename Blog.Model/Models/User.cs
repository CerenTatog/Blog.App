using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Models
{
    public class User : Base
    {
        public User()
        {
            UserTags = new List<UserTag>();
            Articles = new List<Article>();
            FollowUsers = new List<FollowUsers>();
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfileUrl { get; set; }
        public bool IsEmailActivated { get; set; }
        public string? About { get; set; }
        public string? ProfileDescription { get; set; }
        public string? PictureUrl { get; set; }
        public string? ActivationGuid { get; set; }
        public virtual ICollection<UserTag>? UserTags { get; set; }
        public virtual ICollection<Article>? Articles { get; set; }
        public virtual ICollection<FollowUsers>? FollowUsers { get; set; }
    }
}
