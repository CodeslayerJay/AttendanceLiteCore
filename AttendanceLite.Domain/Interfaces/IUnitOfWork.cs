using System.Threading.Tasks;

namespace AttendanceLite.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Dispose();
        int SaveChange();
        Task<int> SaveChangesAsync();
    }
}