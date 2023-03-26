using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Model.Models;
using Blog.Model.ViewModels;

namespace Blog.BLL
{
    public interface IUserManager
    {
        UserViewModel GetProfile(int userId);
        UserViewModel GetProfile(string url);
        bool ProfileAddOrUpdate(UserViewModel model);
        bool DeleteProfile(int userId);
        List<ArticleViewModel> UserArticleListByUserId(int userId);
        bool AddUserTag(UserTagViewModel model);
        bool DeleteUserTag(UserTagViewModel model);
        List<ArticleViewModel> ArticleByUserCategoryFollow(int userId);
    }
}
