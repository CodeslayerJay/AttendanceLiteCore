using AttendanceLite.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace AttendanceLite.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ITimeLogRepository TimeLogs { get; }

        void Dispose();
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}