using AttendanceLite.Domain.Filters;
using AttendanceLite.Domain.Interfaces;
using AttendanceLite.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AttendanceLite.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly ApplicationDbContext dbContext;

        public RepositoryBase(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public virtual void Add(TEntity entity)
        {
            if(entity != null)
            {
                dbContext.Set<TEntity>().Add(entity);
            }
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll(IFilter filter)
        {
            if (filter == null)
                filter = new QueryFilter();

            return dbContext.Set<TEntity>().Where(x => x.Id > 0).Skip(filter.Skip).Take(filter.Size).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().Where(x => x.Id > 0).ToList();
        }

        public TEntity GetBy(int id)
        {
            return dbContext.Set<TEntity>().Where(x => x.Id == id).SingleOrDefault();
        }

        public void Remove(int id)
        {
            var entity = GetBy(id);
            if(entity != null)
            {
                dbContext.Set<TEntity>().Remove(entity);
            }
        }
    }
}
