
using System.Threading.Tasks;
namespace Proeventos.Persistence
{
    public interface IBasePersistence
    {
        //GERAL
        void Add<T>(T entity) where T:class;
        void Update<T>(T entity) where T:class;
        void Remove<T>(T entity) where T:class;
        void RemoveRange<T>(T entity) where T:class;
        Task<bool> SaveChangesAsync();
    }
}