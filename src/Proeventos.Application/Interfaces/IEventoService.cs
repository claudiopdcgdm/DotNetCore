using System.Threading.Tasks;
using Proeventos.DTO;

namespace Proeventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<EventoDto> AddEvento(int userId, EventoDto model);
        Task<EventoDto> UpdateEvento(int userId, int eventoId,  EventoDto model);
        Task<bool> DeleteEvento(int userId, int eventoId);

        
        Task<EventoDto[]> GetAllEventoAsync(int userId, bool includePalestrantes = false);
        Task<EventoDto[]> GetAllEventosByTemaAsync(int userId, string tema, bool includePalestrantes = false);
        Task<EventoDto> GetEventoByIdAsync(int userId, int eventoId, bool includePalestrantes = false);
    }
}