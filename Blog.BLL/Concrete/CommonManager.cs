using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Model.Models;

namespace Blog.BLL.Concrete
{
    public class CommonManager : ICommonManager
    {
        public About AboutAddOrUpdate(About model)
        {
            throw new NotImplementedException();
        }

        public bool FollowUser(int followUserId, int userId)
        {
            throw new NotImplementedException();
        }

        public About GetAbout(int id)
        {
            throw new NotImplementedException();
        }

        public bool LikeArticle(int articleId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
