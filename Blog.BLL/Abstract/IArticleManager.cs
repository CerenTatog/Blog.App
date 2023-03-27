﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.BLL.Helper;
using Blog.Model.Models;
using Blog.Model.ViewModels;

namespace Blog.BLL
{
    public interface IArticleManager
    {
        ArticleViewModel GetArticle(int id);
        ArticleViewModel GetArticle(string url);
		ServiceResult ArticleAddOrUpdateasDraft(ArticleCreateViewModel model);
		ServiceResult ArticleAddOrUpdateasPublished(ArticleCreateViewModel model);
        bool DeleteArticle(int id);
        ArticleComments AddCommentArticle(CommentsViewModel model);

        List<ArticleViewModel> GetMostReadArticles();
        List<ArticleViewModel> GetPopularArticles();
        List<ArticleViewModel> GetArticleBySearchText(string searchText);
        List<ArticleByTagViewModel> GetArticleByTagId(int tagId);
        List<TagViewModel> GetAllTags();
        List<TagViewModel> GetTagsWithSearch(string text);

       

	}
}
