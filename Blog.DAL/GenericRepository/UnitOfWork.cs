using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Entities;
using Blog.Model.Models;

namespace Blog.DAL.GenericRepository
{
    public interface IUnitOfWork
       : IDisposable
    {
        Repository<User> UserRepository { get; }
        Repository<About> AboutRepository { get; }
        Repository<Article> ArticleRepository { get; }
        Repository<ArticleComments> ArticleCommentRepository { get; }
        Repository<ArticleLike> ArticleLikeRepository { get; }
        Repository<ArticleTag> ArticleTagRepository { get; }
        Repository<FollowUsers> FollowUserRepository { get; }
        Repository<Tag> TagRepository { get; }
        Repository<UserTag> UserTagRepository { get; }

    }
    public class UnitOfWork : IUnitOfWork
    {
        private BlogDBContext _context;
        private Repository<User> _userRepository;
        private Repository<About> _aboutRepository;
        private Repository<Article> _articleRepository;
        private Repository<ArticleComments> _articleCommentRepository;
        private Repository<ArticleLike> _articleLikeRepository;
        private Repository<ArticleTag> _articleTagRepository;
        private Repository<FollowUsers> _followUserRepository;
        private Repository<Tag> _tagRepository;
        private Repository<UserTag> _userTagRepository;

        private bool _disposed = false;
        public UnitOfWork(BlogDBContext context)
        {
            _context = context;
        }
        public Repository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new Repository<User>(_context);
                return _userRepository;
            }
        }

        public Repository<About> AboutRepository
        {
            get
            {
                if (_aboutRepository == null)
                    _aboutRepository = new Repository<About>(_context);
                return _aboutRepository;
            }
        }

        public Repository<Article> ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                    _articleRepository = new Repository<Article>(_context);
                return _articleRepository;
            }
        }

        public Repository<ArticleComments> ArticleCommentRepository
        {
            get
            {
                if (_articleCommentRepository == null)
                    _articleCommentRepository = new Repository<ArticleComments>(_context);
                return _articleCommentRepository;
            }
        }

        public Repository<ArticleLike> ArticleLikeRepository
        {
            get
            {
                if (_articleLikeRepository == null)
                    _articleLikeRepository = new Repository<ArticleLike>(_context);
                return _articleLikeRepository;
            }
        }

        public Repository<ArticleTag> ArticleTagRepository
        {
            get
            {
                if (_articleTagRepository == null)
                    _articleTagRepository = new Repository<ArticleTag>(_context);
                return _articleTagRepository;
            }
        }

        public Repository<FollowUsers> FollowUserRepository
        {
            get
            {
                if (_followUserRepository == null)
                    _followUserRepository = new Repository<FollowUsers>(_context);
                return _followUserRepository;
            }
        }
        public Repository<Tag> TagRepository
        {
            get
            {
                if (_tagRepository == null)
                    _tagRepository = new Repository<Tag>(_context);
                return _tagRepository;
            }
        }

        public Repository<UserTag> UserTagRepository
        {
            get
            {
                if (_userTagRepository == null)
                    _userTagRepository = new Repository<UserTag>(_context);
                return _userTagRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
