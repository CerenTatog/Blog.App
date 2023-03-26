using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.BLL.Helper;
using Blog.DAL.GenericRepository;
using Blog.Model.Models;
using Blog.Model.ViewModels;

namespace Blog.BLL.Concrete
{
	public class ArticleManager : IArticleManager
	{
		private IUnitOfWork _db;

		public ArticleManager(IUnitOfWork db)
		{
			_db = db;
		}
		public ArticleComments AddCommentArticle(CommentsViewModel model)
		{
			//CommentListesi
			//var comments = from ar in _db.ArticleRepository.GetAll()
			//               join ac in _db.ArticleCommentRepository.GetAll() on ar.ID equals ac.ArticleId
			//               join u in _db.ArticleCommentRepository.GetAll() on ac.UserId equals u.ID
			throw new NotImplementedException();
		}

		//articlelist view model gelecek.
		public ArticleViewModel ArticleAddOrUpdateasDraft(ArticleViewModel model)
		{

			Article article = _db.ArticleRepository.GetById(model.Id);
			if (article == null)
			{
				article.Title = model.Title;
				article.CreatedDate = DateTime.Now;
				article.Content = model.Content;
				article.ArticleUrl = model.Title.GetArticleURL();


			}


			throw new NotImplementedException();
		}

		public ArticleViewModel ArticleAddOrUpdateasPublished(Article model)
		{
			ArticleViewModel avm = new ArticleViewModel();
			Article article = _db.ArticleRepository.GetById(model.ID);
			if (article == null)
			{

			}


			throw new NotImplementedException();
		}



		public bool DeleteArticle(int id)
		{
			throw new NotImplementedException();
		}

		public ArticleViewModel GetArticle(int id)
		{
			var article = (from a in _db.ArticleRepository.GetAll()
						   where (a.Status == ArticleStatusEnum.Published && a.ID == id)
						   select new ArticleViewModel
						   {
							   Title = a.Title,
							   Content = a.Content,
							   ReadTime = a.ReadTime,
							   CoverPictureUrl = a.CoverPictureUrl,
							   UserId = a.UserId,

						   }).FirstOrDefault();
			return article;
		}

		public ArticleViewModel GetArticle(string url)
		{
			var article = (from a in _db.ArticleRepository.GetAll()
						   where (a.Status == ArticleStatusEnum.Published && a.IsDeleted == false && a.ArticleUrl == url)
						   select new ArticleViewModel
						   {
							   Title = a.Title,
							   Content = a.Content,
							   ReadTime = a.ReadTime,
							   CoverPictureUrl = a.CoverPictureUrl,
							   UserId = a.UserId,

						   }).FirstOrDefault();
			return article;
		}

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

		public List<ArticleViewModel> GetArticleByTagId(int tagId)
		{
			List<ArticleViewModel> articleList = new List<ArticleViewModel>();
			var query = (from a in _db.ArticleRepository.GetAll()
						 join at in _db.ArticleTagRepository.GetAll() on a.ID equals at.ArticleId
						 join t in _db.TagRepository.GetAll() on at.TagId equals t.ID
						 where (a.Status == ArticleStatusEnum.Published && a.IsDeleted == false && t.ID == tagId)
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



		public List<ArticleViewModel> GetMostReadArticles()
		{
			var mostReadingList = _db.ArticleRepository.GetAll().Where(x => x.Status == ArticleStatusEnum.Published).Select(x => new ArticleViewModel()
			{
				Title = x.Title,
				Content = x.Content,
				ReadTime = x.ReadTime,
				CoverPictureUrl = x.CoverPictureUrl,
				UserId = x.UserId,
				ReadCount = x.ReadCount
			}).OrderByDescending(x => x.ReadCount).Take(5).ToList();
			return mostReadingList;
		}

		public List<ArticleViewModel> GetPopularArticles()//tekrar bakılacak.
		{
			var popularArticleList = (from ar in _db.ArticleRepository.GetAll()
									  where ar.Status == ArticleStatusEnum.Published
									  select new ArticleViewModel
									  {
										  Title = ar.Title,
										  Content = ar.Content,
										  Likes = ar.Likes.Count()
									  }).OrderByDescending(x => x.Likes).Take(5).ToList();


			return popularArticleList;
		}

		public List<TagViewModel> GetAllTags()
		{
			var tagList = (from t in _db.TagRepository.GetAll()
						   select new TagViewModel
						   {
							   TagId = t.ID,
							   TagName = t.TagName
						   }).ToList();
			return tagList;
						 
		}
	}
}
