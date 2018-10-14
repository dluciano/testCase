using System.Threading.Tasks;

namespace Clay.DAL
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}