using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Blog.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.Entities
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options)
        {
        }

        public DbSet<About> About { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleComments> ArticleComments { get; set; }
        public DbSet<ArticleLike> ArticleLike { get; set; }
        public DbSet<ArticleTag> ArticleTag { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserTag> UserTag { get; set; }
        public DbSet<FollowUsers> FollowUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Article>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ArticleComments>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ArticleLike>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<ArticleTag>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Tag>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<UserTag>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<FollowUsers>().HasQueryFilter(p => !p.IsDeleted);
            base.OnModelCreating(modelBuilder);
        }
    }
}
