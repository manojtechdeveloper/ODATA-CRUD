using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Repository.ProductDbContext;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.Entities;
using System.Linq.Expressions;

namespace ProductManagement.Repository.BaseRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ProductContext _baseContext;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(ProductContext baseContext) {
            _baseContext = baseContext;
            _baseContext.Set<TEntity>();
            _dbSet = baseContext.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _baseContext.Set<TEntity>().FindAsync(id);
        }
        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression)
        {
             return _baseContext.Set<TEntity>().Where(expression).ToList();
        }

        public void Create(TEntity entity)
        {
            try
            {

                 _baseContext.Set<TEntity>().Add(entity);
                 _baseContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateMany(IEnumerable<TEntity> entity)
        {
            try
            {
                _baseContext.Set<TEntity>().AttachRange(entity);
                await _baseContext.Set<TEntity>().AddRangeAsync(entity);
                await _baseContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(int id, TEntity entity)
        {
            _baseContext.Set<TEntity>().Update(entity);
            await _baseContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _baseContext.Set<TEntity>().Remove(entity);
            await _baseContext.SaveChangesAsync();
        }

        public async Task DeleteMany(IEnumerable<TEntity> entity)
        {
            _baseContext.Set<TEntity>().AttachRange(entity);
            _baseContext.Set<TEntity>().RemoveRange(entity);
            await _baseContext.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await _baseContext.DisposeAsync();
        }

    }
}
