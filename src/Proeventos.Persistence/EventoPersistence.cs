
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proeventos.Domain;

namespace Proeventos.Persistence
{
    public class EventoPersistence : BasePersistence, IEventoPersistence
    {   
        // private readonly ProeventosContext _context;
        // public EventoPersistence(ProeventosContext context)
        // {
        //     this._context = context;
        // }
        

        public EventoPersistence(ProeventosContext context):base(context)
        {
        }
        
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> sql = _context.Eventos.Include(e => e.Lotes).Include(e=> e.RedesSociais);

            if(includePalestrantes){
                sql = sql.Include(pe => pe.PalestrantesEventos).ThenInclude(pa => pa.Palestrante);
            }
            sql = sql.OrderBy(e => e.Id);

            return await sql.AsSplitQuery().ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> sql = _context.Eventos.Include(e => e.Lotes).Include(e=> e.RedesSociais);

            if(includePalestrantes){
                sql = sql.Include(pe => pe.PalestrantesEventos).ThenInclude(pa => pa.Palestrante);
            }
            sql = sql.OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await sql.AsSplitQuery().ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes= false)
        {
            IQueryable<Evento> sql = _context.Eventos.Include(e => e.Lotes).Include(e=> e.RedesSociais);

            if(includePalestrantes){
                sql = sql.Include(pe => pe.PalestrantesEventos).ThenInclude(pa => pa.Palestrante);
            }
            sql = sql.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == eventoId);

            return await sql.AsSplitQuery().FirstOrDefaultAsync();
        }

    }
}