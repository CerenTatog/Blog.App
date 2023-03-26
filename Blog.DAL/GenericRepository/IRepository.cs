using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Model.Models;

namespace Blog.DAL.GenericRepository
{
    public interface IRepository<TEntity> where TEntity : Base
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int Id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int Id);
    }
}
