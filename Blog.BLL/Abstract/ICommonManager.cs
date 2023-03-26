using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Model.Models;

namespace Blog.BLL
{
    public interface ICommonManager
    {
        About GetAbout(int id);
        About AboutAddOrUpdate(About model);
        bool LikeArticle(int articleId, int userId);
        bool FollowUser(int followUserId, int userId);
    }
}
