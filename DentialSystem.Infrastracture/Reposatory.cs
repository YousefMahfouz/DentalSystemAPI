using DentialSystem.Application.Contract;
using DentialSystem.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentialSystem.Infrastracture
{
    public class Reposatory<TEntity, TId> :IRepository<TEntity, TId> where TEntity : class
    {
        private readonly ApplicationContext context;
        private DbSet<TEntity> Dbset;

        public Reposatory(ApplicationContext context)
        {
            this.context = context;
            Dbset = context.Set<TEntity>();
        }

     

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var res =(await context.AddAsync(entity)).Entity;
            return res;
        }

   

        public async Task<bool> DeleteAsync(TId id)
        {
            var res = await GetByIdAsync(id);
            if(res == null)
            {
                return false;
            }
            Dbset.Remove(res); return true;

        }


      

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            var res = await Dbset.FindAsync(id);
            return res;
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity, TId id)
        {
            var res=await  GetByIdAsync(id);
            if(res!=null)
            {
                Dbset.Entry(res).CurrentValues.SetValues(entity);
                return true;
            }
            return false;
        }

        public async Task<IQueryable<TEntity>>GetAllAsync()
        {
            return  await(Task.FromResult(Dbset.Select(p => p)));
        }
    }
}
