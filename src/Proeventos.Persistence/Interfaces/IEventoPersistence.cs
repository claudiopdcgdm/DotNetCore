
using System.Threading.Tasks;
using Proeventos.Domain;

namespace Proeventos.Persistence
{
    public interface IEventoPersistence:IBasePersistence
    {
        
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);

    }
}