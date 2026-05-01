
using System.Threading.Tasks;
using Proeventos.Domain;

namespace Proeventos.Persistence
{
    public interface IPalestrantePersistence
    {
        Task<Palestrante[]> GetAllPalestrantesAsync( bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);

    }
}