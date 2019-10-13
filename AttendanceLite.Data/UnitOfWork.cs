using AttendanceLite.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLite.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext _dbContext;

        public UnitOfWork(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
