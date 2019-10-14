using AttendanceLite.Domain.Interfaces;
using AttendanceLite.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLite.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext _dbContext;
        public IUserRepository Users { get; }
        public ITimeLogRepository TimeLogs { get;  }

        public UnitOfWork(IAppDbContext dbContext, 
            IUserRepository userRepository, ITimeLogRepository timeLogRepository)
        {
            _dbContext = dbContext;
            Users = userRepository;
            TimeLogs = timeLogRepository;
        }

        public int SaveChanges()
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
