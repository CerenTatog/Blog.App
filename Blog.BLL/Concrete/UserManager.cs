using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.GenericRepository;
using Blog.Model.Models;
using Blog.Model.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Blog.BLL
{
    public class UserManager : IUserManager
    {
        private IUnitOfWork _db;
		private readonly IHttpContextAccessor _contextAccessor;

		public UserManager(IUnitOfWork db, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _db = db;
        }
        public List<ArticleViewModel> ArticleByUserCategoryFollow(int userId)
        {
            var articleRepo = _db.ArticleRepository.GetAll().Where(x => x.Status == ArticleStatusEnum.Published);
            var userTagRepo = _db.UserTagRepository.GetAll().Where(x => x.UserId == userId);
            var userRepo = _db.UserRepository.GetAll();

            var followedTagArticle = (from a in articleRepo
                                      join u in userRepo on a.UserId equals u.ID
                                      let userTagIds = userTagRepo.Select(x => x.TagId).ToList()
                                      where a.ArticleTags.Any(x => userTagIds.Contains(x.TagId))
                                      select new ArticleViewModel
                                      {
                                          ArticleUrl = a.ArticleUrl,
                                          CoverPictureUrl = a.CoverPictureUrl,
                                          CreatedTime = a.CreatedDate,
                                          //ArticleTags = a.ArticleTags.Select(x => new Tag
                                          //{
                                          //    TagName = x.Tag.TagName
                                          //}).ToList(),
                                          Content = a.Content,
                                          Likes = a.Likes.Count(),
                                          ReadCount = a.ReadCount,
                                          ReadTime = a.ReadTime,
                                          Title = a.Title,
                                          AuthorName = u.UserName,
                                          UserId = a.UserId,
                                      }).OrderByDescending(x => x.CreatedTime).Take(5).ToList();
            return followedTagArticle;
        }

        public bool DeleteProfile(int userId)
        {
            User user = _db.UserRepository.GetById(userId);
            if (user != null)
            {
                _db.UserRepository.Delete(user);

                //user a ait article lar pasife alınmak durumunda.
                var articleList = _db.ArticleRepository.GetAll().Where(x => x.UserId == userId).ToList();
                foreach (var item in articleList)
                {
                    item.Status = ArticleStatusEnum.Passive;
                    _db.ArticleRepository.Update(item);
                }
                return true;
            }
            return false;
        }

        public bool AddUserTag(UserTagViewModel model)
        {
            

            var userTag = _db.UserTagRepository.GetAll().Where(x=>x.UserId == model.UserId && x.TagId == model.TagId).FirstOrDefault();
            if (userTag == null)
            {
                userTag.Tag.ID = model.TagId;
                userTag.Tag.TagName= model.TagName;
                userTag.User.ID = model.UserId;
                userTag.User.UserName = model.UserName;
                _db.UserTagRepository.Create(userTag);
                return true;
            }
			return false;
        }
        public bool DeleteUserTag(UserTagViewModel model)
		{
			var userTag = _db.UserTagRepository.GetAll().Where(x => x.UserId == model.UserId && x.TagId == model.TagId).FirstOrDefault();
            _db.UserTagRepository.Delete(userTag);
			return true;
        }

        public UserViewModel GetProfile(int userId)
        {
            UserViewModel model = new UserViewModel();
            User user = _db.UserRepository.GetById(userId);
            model.UserName = user.UserName;
            model.Email = user.Email;
            model.ProfileDescription = user.ProfileDescription;
            model.PictureUrl = user.PictureUrl;
            return model;
        }

        public UserViewModel GetProfile(string url)
        {

            UserViewModel model = new UserViewModel();
            User user = _db.UserRepository.GetAll().FirstOrDefault(x => x.ProfileUrl == url);
            model.UserName = user.UserName;
            model.Email = user.Email;
            model.ProfileDescription = user.ProfileDescription;
            model.PictureUrl = user.PictureUrl;
            return model;

        }

        public bool ProfileAddOrUpdate(UserViewModel model)
        {
            User user = _db.UserRepository.GetById(model.Id);
            if (user == null)
            {
                user.UserName = model.UserName;
                //url ne olacak
                user.Email = model.Email;
                //user.Password = model.Password;
                user.ProfileDescription = model.ProfileDescription;
                user.PictureUrl = model.PictureUrl;
                _db.UserRepository.Create(user);
                return true;
            }
            else
            {
                user.UserName = model.UserName;
                //user.ProfileUrl = 
                user.Email = model.Email;
                //user.Password = model.Password;
                user.ProfileDescription = model.ProfileDescription;
                user.PictureUrl = model.PictureUrl;
                _db.UserRepository.Update(user);
                return true;
            }
        }

        public List<ArticleViewModel> UserArticleListByUserId(int userId)
        {
            var articleListByUser = (from a in _db.ArticleRepository.GetAll()
                                     where a.UserId == userId
                                     select new ArticleViewModel
                                     {
                                         Title = a.Title,
                                         Content = a.Content,
                                         CoverPictureUrl = a.CoverPictureUrl,
                                         ReadCount = a.ReadCount,
										 ArticleTags = a.ArticleTags.Select(p => new TagViewModel() { TagId = p.TagId, TagName = p.Tag.TagName, TagUrl = p.Tag.TagUrl }).ToList(),
									 }).OrderBy(x => x.UpdatedTime ?? x.CreatedTime).ToList();
            return articleListByUser;
        }
    }
}
