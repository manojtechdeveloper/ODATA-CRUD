using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.BaseRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        Task CreateMany(IEnumerable<TEntity> entity);
        Task Update(int id, TEntity entity);
        Task Delete(int id);
        Task DeleteMany(IEnumerable<TEntity> entity);

        void Dispose();
    }
}
