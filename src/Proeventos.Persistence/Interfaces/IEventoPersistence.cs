
using System.Threading.Tasks;
using Proeventos.Domain;

namespace Proeventos.Persistence
{
    public interface IEventoPersistence:IBasePersistence
    {
        
        Task<Evento[]> GetAllEventoAsync(int userId, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(int userId, string tema, bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int userId, int eventoId, bool includePalestrantes = false);

    }
}