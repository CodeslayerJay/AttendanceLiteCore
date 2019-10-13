using System.Threading.Tasks;

namespace AttendanceLite.Data
{
    public interface IUnitOfWork
    {
        void Dispose();
        int SaveChange();
        Task<int> SaveChangesAsync();
    }
}