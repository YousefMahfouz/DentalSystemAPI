using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Application.Contract
{
    public interface IRepository<TEntity ,TId>
    {
        public  Task<TEntity> GetByIdAsync(TId id);
        public Task<TEntity> CreateAsync(TEntity entity);
        public Task<bool> UpdateAsync(TEntity entity,TId id);
        public Task<bool> DeleteAsync(TId id);
        public Task<IQueryable<TEntity>> GetAllAsync();
        public Task<int> SaveChanges();

    }
}
