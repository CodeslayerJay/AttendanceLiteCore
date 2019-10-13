using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceLite.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetBy(int id);
        IEnumerable<TEntity> GetAll(IFilter filter);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);

    }
}
