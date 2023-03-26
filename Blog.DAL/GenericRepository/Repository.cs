using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DAL.Entities;
using Blog.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Base
    {
        private readonly BlogDBContext _db;
        public Repository(BlogDBContext db)
        {
            _db = db;
        }
        public void Create(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.IsDeleted = false;
            _db.Set<TEntity>().Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int Id)
        {
            TEntity entityToDelete = _db.Set<TEntity>().Find(Id);
            entityToDelete.IsDeleted = true;
            _db.Set<TEntity>().Update(entityToDelete);
            _db.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            _db.Set<TEntity>().Update(entity);
            _db.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(int Id)
        {
            return _db.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.ID == Id);
        }

        public void Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Set<TEntity>().Update(entity);
            _db.SaveChanges();
        }
    }
}

