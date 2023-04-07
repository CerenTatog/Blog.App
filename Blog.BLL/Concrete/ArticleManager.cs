using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.BLL.Helper;
using Blog.DAL.GenericRepository;
using Blog.Model.Models;
using Blog.Model.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Blog.BLL.Concrete
{
	public class ArticleManager : IArticleManager
	{
		private IUnitOfWork _db;
		private readonly IHttpContextAccessor _contextAccessor;
		private UserViewModel _currentUser;

		public ArticleManager(IUnitOfWork db, IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
			_currentUser = contextAccessor.HttpContext.Session.Get<UserViewModel>("user");
			_db = db;
		}
		public ServiceResult AddCommentArticle(AddCommentViewModel model)
		{
			ArticleComments comments = new ArticleComments
			{
				ArticleId = model.ArticleId,
				CommentText = model.Comment,
				CreatedBy = _currentUser.Id,
				UserId = _currentUser.Id
			};
			_db.ArticleCommentRepository.Create(comments);
			return new ServiceResult();
		}

		//articlelist view model gelecek.
		public ServiceResult ArticleAddOrUpdateasDraft(ArticleCreateViewModel model)
		{
			Article article = _db.ArticleRepository.GetById(model.Id);
			if (article == null)
			{
				article = new Article();
				article.Title = model.Title;
				article.Content = model.Content;
				article.ArticleUrl = model.Title.GetArticleURL();
				article.CoverPictureUrl = model.CoverPictureUrl;
				article.UserId = _currentUser.Id;
				article.CreatedBy = _currentUser.Id;
				article.Status = ArticleStatusEnum.Draft;
				article.ReadTime = model.ReadTime;
				article.Summary = model.Summary;
				foreach (var item in model.TagIds)
				{
					article.ArticleTags.Add(new ArticleTag()
					{
						TagId = item,
						CreatedBy = _currentUser.Id
					});
				}
				_db.ArticleRepository.Create(article);
				return new ServiceResult();
			}
			article.Title = model.Title;
			article.Content = model.Content;
			article.ArticleUrl = model.Title.GetArticleURL();
			article.CoverPictureUrl = model.CoverPictureUrl;
			article.UserId = _currentUser.Id;
			article.UpdatedBy = _currentUser.Id;
			article.Status = ArticleStatusEnum.Draft;
			article.ReadTime = model.ReadTime;
			article.Summary = model.Summary;
			//tagler silinip tekrar eklenecek.
			if (model.TagIds != null)
			{
				foreach (var item in model.TagIds)
				{
					var artigleTagList = article.ArticleTags.ToList();
					foreach (var deletedTag in artigleTagList)
					{
						_db.ArticleTagRepository.Delete(deletedTag);
					}
				}
			}

			foreach (var item in model.TagIds)
			{
				ArticleTag newTag = new ArticleTag()
				{
					TagId = item,
					ArticleId = article.ID,
					CreatedBy = _currentUser.Id
				};
				_db.ArticleTagRepository.Create(newTag);
			}
			return new ServiceResult();
		}

		//varsa update alanı olacak.
		public ServiceResult ArticleAddOrUpdateasPublished(ArticleCreateViewModel model)
		{
			Article article = _db.ArticleRepository.GetById(model.Id);
			if (article == null)
			{
				article = new Article();
				article.Title = model.Title;
				article.Content = model.Content;
				article.ArticleUrl = model.Title.GetArticleURL();
				article.CoverPictureUrl = model.CoverPictureUrl;
				article.UserId = _currentUser.Id;
				article.CreatedBy = _currentUser.Id;
				article.Status = ArticleStatusEnum.Published;
				article.ReadTime = model.ReadTime;
				article.Summary = model.Summary;
				foreach (var item in model.TagIds)
				{
					article.ArticleTags.Add(new ArticleTag()
					{
						TagId = item,
						CreatedBy = _currentUser.Id
					});
				}
				_db.ArticleRepository.Create(article);
				return new ServiceResult();
			}
			article.Title = model.Title;
			article.Content = model.Content;
			article.ArticleUrl = model.Title.GetArticleURL();
			article.CoverPictureUrl = model.CoverPictureUrl;
			article.UserId = _currentUser.Id;
			article.UpdatedBy = _currentUser.Id;
			article.Status = ArticleStatusEnum.Published;
			article.ReadTime = model.ReadTime;
			article.Summary = model.Summary;
			//tagler silinip tekrar eklenecek.
			if (model.TagIds != null)
			{
				foreach (var item in model.TagIds)
				{
					var artigleTagList = article.ArticleTags.ToList();
					foreach (var deletedTag in artigleTagList)
					{
						_db.ArticleTagRepository.Delete(deletedTag);
					}
				}
			}

			foreach (var item in model.TagIds)
			{
				ArticleTag newTag = new ArticleTag()
				{
					TagId = item,
					ArticleId = article.ID,
					CreatedBy = _currentUser.Id
				};
				_db.ArticleTagRepository.Create(newTag);
			}

			return new ServiceResult("İşleminiz başarılı bir şekilde gerçekleştirilmiştir");
		}



		public bool DeleteArticle(int id)
		{
			_db.ArticleRepository.Delete(id);
			return true;
		}

		public ArticleViewModel GetArticle(int id)
		{
			var article = (from a in _db.ArticleRepository.GetAll()
						   where (a.Status == ArticleStatusEnum.Published && a.ID == id)
						   select new ArticleViewModel
						   {
							   UserId = a.UserId,
							   AuthorName = a.User.UserName,
							   ArticleTags = a.ArticleTags.Select(p => new TagViewModel() { TagId = p.TagId, TagName = p.Tag.TagName, TagUrl = p.Tag.TagUrl }).ToList(),
							   Title = a.Title,
							   Summary = a.Summary.ContentFormat(100),
							   ReadCount = a.ReadCount,
							   ReadTime = a.ReadTime,
							   Likes = a.Likes.Count(),
							   UserPicUrl = a.User.PictureUrl,
							   CoverPictureUrl = a.CoverPictureUrl

						   }).FirstOrDefault();
			return article;
		}

		public ArticleViewModel GetArticle(string url)
		{
			var article = (from a in _db.ArticleRepository.GetAll()
						   where (a.Status == ArticleStatusEnum.Published && a.IsDeleted == false && a.ArticleUrl == url)
						   select new ArticleViewModel
						   {
							   Id = a.ID,
							   UserId = a.UserId,
							   AuthorName = a.User.UserName,
							   ArticleTags = a.ArticleTags.Select(p => new TagViewModel() { TagId = p.TagId, TagName = p.Tag.TagName, TagUrl = p.Tag.TagUrl }).ToList(),
							   Title = a.Title,
							   Summary = a.Summary.ContentFormat(100),
							   ReadCount = a.ReadCount,
							   ReadTime = a.ReadTime,
							   Likes = a.Likes.Count(),
							   UserPicUrl = a.User.PictureUrl,
							   CoverPictureUrl = a.CoverPictureUrl,
							   Content = a.Content,
							   CommentCount = a.ArticleComments.Count(),
							   CreatedTimeStr = a.CreatedDate.Value.ToString("dd MMMM yyyy"),
							   UserUrl = a.User.ProfileUrl

						   }).FirstOrDefault();
			var item = _db.ArticleRepository.GetAll().FirstOrDefault(x => x.ArticleUrl == url);
			if (item != null)
			{
				item.ReadCount += 1;
				_db.ArticleRepository.Update(item);
			}
			return article;
		}

		//bakılması lazım. 
		public List<ArticleViewModel> GetArticleBySearchText(string searchText)
		{
			List<ArticleViewModel> articleList = new List<ArticleViewModel>();
			var query = (from a in _db.ArticleRepository.GetAll()
						 join at in _db.ArticleTagRepository.GetAll() on a.ID equals at.ArticleId
						 join t in _db.TagRepository.GetAll() on at.TagId equals t.ID
						 where (a.Status == ArticleStatusEnum.Published && a.IsDeleted == false && t.SearchText == searchText)
						 select new
						 {
							 Title = a.Title,
							 Content = a.Content,
							 ReadTime = a.ReadTime,
							 CoverPictureUrl = a.CoverPictureUrl,
							 UserId = a.UserId,
							 TagId = t.ID,
							 TagName = t.TagName,
							 SearchText = t.SearchText
						 }).ToList();

			return articleList;
		}

		public List<ArticleByTagViewModel> GetArticleByTagId(int tagId)
		{

			var articleByTag = _db.ArticleRepository.GetAll().Where(x => (x.ArticleTags.Any(p => p.TagId == tagId) || tagId == 0) && x.Status == ArticleStatusEnum.Published).Select(x => new ArticleByTagViewModel()
			{
				ArticleId = x.ID,
				UserId = x.UserId,
				UserName = x.User.UserName,
				Tags = x.ArticleTags.Select(p => new TagViewModel() { TagId = p.TagId, TagName = p.Tag.TagName, TagUrl = p.Tag.TagUrl }).ToList(),
				Title = x.Title,
				Summary = x.Summary.ContentFormat(100),
				ReadCount = x.ReadCount,
				ReadTime = x.ReadTime,
				Likes = x.Likes.Count(),
				UserPicUrl = x.User.PictureUrl,
				ArticleCoverPhoto = x.CoverPictureUrl,
				ArticleUrl = x.ArticleUrl,
				CreatedTimeStr = x.CreatedDate.GetValueOrDefault().ToString("dd MMMM yyyy"),

			}).ToList();


			return articleByTag;
		}

		public List<ArticleViewModel> GetArticleByTagUrl(string tagUrl)
		{

			var articleByTag = _db.ArticleRepository.GetAll().Where(x => x.ArticleTags.Any(p => p.Tag.TagUrl == tagUrl) && x.Status == ArticleStatusEnum.Published).Select(x => new ArticleViewModel()
			{
				UserId = x.UserId,
				AuthorName = x.User.UserName,
				ArticleTags = x.ArticleTags.Select(p => new TagViewModel() { TagId = p.TagId, TagName = p.Tag.TagName, TagUrl = p.Tag.TagUrl }).ToList(),
				Title = x.Title,
				Summary = x.Summary.ContentFormat(100),
				ReadCount = x.ReadCount,
				ReadTime = x.ReadTime,
				Likes = x.Likes.Count(),
				UserPicUrl = x.User.PictureUrl,
				CoverPictureUrl = x.CoverPictureUrl,
				ArticleUrl = x.ArticleUrl
			}).ToList();


			return articleByTag;
		}



		public List<ArticleViewModel> GetMostReadArticles()
		{
			var mostReadingList = _db.ArticleRepository.GetAll().Where(x => x.Status == ArticleStatusEnum.Published).Select(x => new ArticleViewModel()
			{
				UserId = x.UserId,
				AuthorName = x.User.UserName,
				ArticleTags = x.ArticleTags.Select(p => new TagViewModel() { TagId = p.TagId, TagName = p.Tag.TagName, TagUrl = p.Tag.TagUrl }).ToList(),
				Title = x.Title,
				Summary = x.Summary.ContentFormat(100),
				ReadCount = x.ReadCount,
				ReadTime = x.ReadTime,
				Likes = x.Likes.Count(),
				UserPicUrl = x.User.PictureUrl,
				CoverPictureUrl = x.CoverPictureUrl,
				ArticleUrl = x.ArticleUrl

			}).OrderByDescending(x => x.ReadCount).Take(5).ToList();
			return mostReadingList;
		}

		public List<ArticleViewModel> GetPopularArticles()//tekrar bakılacak.
		{
			var popularArticleList = (from ar in _db.ArticleRepository.GetAll()
									  where ar.Status == ArticleStatusEnum.Published
									  select new ArticleViewModel
									  {
										  UserId = ar.UserId,
										  AuthorName = ar.User.UserName,
										  ArticleTags = ar.ArticleTags.Select(p => new TagViewModel() { TagId = p.TagId, TagName = p.Tag.TagName, TagUrl = p.Tag.TagUrl }).ToList(),
										  Title = ar.Title,
										  Summary = ar.Summary.ContentFormat(100),
										  ReadCount = ar.ReadCount,
										  ReadTime = ar.ReadTime,
										  Likes = ar.Likes.Count(),
										  UserPicUrl = ar.User.PictureUrl,
										  CoverPictureUrl = ar.CoverPictureUrl,
										  ArticleUrl = ar.ArticleUrl
									  }).OrderByDescending(x => x.Likes).Take(3).ToList();


			return popularArticleList;
		}

		public List<TagViewModel> GetAllTags()
		{
			var tagList = (from t in _db.TagRepository.GetAll()
						   select new TagViewModel
						   {
							   TagId = t.ID,
							   TagName = t.TagName,
							   TagUrl = t.TagUrl
						   }).ToList();
			return tagList;

		}

		public List<TagViewModel> GetTagsWithSearch(string text)
		{
			var tagList = _db.TagRepository.GetAll().Where(x => x.TagName.Contains(text)).Select(x => new TagViewModel()
			{
				TagId = x.ID,
				TagName = x.TagName
			}).ToList();
			return tagList;
		}

		public List<ArticleViewModel> GetLatestArtciles()
		{
			var latesArticleList = (from ar in _db.ArticleRepository.GetAll()
									where ar.Status == ArticleStatusEnum.Published
									select new ArticleViewModel
									{
										UserId = ar.UserId,
										AuthorName = ar.User.UserName,
										ArticleTags = ar.ArticleTags.Select(p => new TagViewModel() { TagId = p.TagId, TagName = p.Tag.TagName, TagUrl = p.Tag.TagUrl }).ToList(),
										Title = ar.Title,
										Summary = ar.Summary.ContentFormat(100),
										ReadCount = ar.ReadCount,
										ReadTime = ar.ReadTime,
										Likes = ar.Likes.Count(),
										UserPicUrl = ar.User.PictureUrl,
										CoverPictureUrl = ar.CoverPictureUrl,
										Content = ar.Content,
										CommentCount = ar.ArticleComments.Count(),
										CreatedTimeStr = ar.CreatedDate.Value.ToString("dd MMMM yyyy"),
										UserUrl = ar.User.ProfileUrl,
										ArticleUrl = ar.ArticleUrl
									}).OrderByDescending(x => x.Likes).Take(5).ToList();

			return latesArticleList;
		}

		public List<CommentsViewModel> GetCommentArticles(int articleId)
		{
			var query = (from comment in _db.ArticleCommentRepository.GetAll().Where(x => x.ArticleId == articleId)
						 join user in _db.UserRepository.GetAll() on comment.UserId equals user.ID
						 select new CommentsViewModel
						 {
							 CommentText = comment.CommentText,
							 UserName = user.UserName,
							 UserProfileFoto = user.PictureUrl,
							 CommentId = comment.ID,
							 DateStr = comment.CreatedDate.Value.ToString("dd MMMM yyyy")
						 }).OrderByDescending(x=> x.CommentId).ToList();
			return query;
		}
	}
}
