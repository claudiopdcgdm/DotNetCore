
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proeventos.Domain;

namespace Proeventos.Persistence
{
    public class EventoPersistence : BasePersistence, IEventoPersistence
    {   

        public EventoPersistence(ProeventosContext context):base(context)
        {
        }
        
        public async Task<Evento[]> GetAllEventoAsync(int userId, bool includePalestrantes = false)
        {
            IQueryable<Evento> sql = _context.Eventos.Include(e => e.Lotes).Include(e=> e.RedesSociais);

            if(includePalestrantes){
                sql = sql.Include(pe => pe.PalestrantesEventos).ThenInclude(pa => pa.Palestrante);
            }
            sql = sql.Where(evento => evento.UserId == userId).OrderBy(e => e.Id);

            return await sql.AsSplitQuery().ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(int userId, string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> sql = _context.Eventos.Include(e => e.Lotes).Include(e=> e.RedesSociais);

            if(includePalestrantes){
                sql = sql.Include(pe => pe.PalestrantesEventos).ThenInclude(pa => pa.Palestrante);
            }
            sql = sql.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()) && e.UserId == userId);

            return await sql.AsSplitQuery().ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int userId, int eventoId, bool includePalestrantes= false)
        {
            IQueryable<Evento> sql = _context.Eventos.Include(e => e.Lotes).Include(e=> e.RedesSociais);

            if(includePalestrantes){
                sql = sql.Include(pe => pe.PalestrantesEventos).ThenInclude(pa => pa.Palestrante);
            }
            sql = sql.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == eventoId && e.UserId == userId);

            return await sql.AsSplitQuery().FirstOrDefaultAsync();
        }

    }
}