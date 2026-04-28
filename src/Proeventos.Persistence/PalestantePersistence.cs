
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proeventos.Domain;

namespace Proeventos.Persistence
{
    public class PalestantePersistence : BasePersistence, IPalestrantePersistence
    {   
        // private readonly ProeventosContext _context;
        // public PalestantePersistence(ProeventosContext context)
        // {
        //     this._context = context;
        // }
        public PalestantePersistence(ProeventosContext context):base(context)
        {
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos= false)
        {
            IQueryable<Palestrante> sql = _context.Palestrante.Include(p => p.RedesSociais);

            if(includeEventos){
                sql = sql.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);
            }
            sql = sql.OrderBy(p => p.Id);

            return await sql.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos= false)
        {
            IQueryable<Palestrante> sql = _context.Palestrante.Include(p => p.RedesSociais);

            if(includeEventos){
                sql = sql.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);
            }
            sql = sql.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await sql.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos= false)
        {
            IQueryable<Palestrante> sql = _context.Palestrante.Include(p => p.RedesSociais);

            if(includeEventos){
                sql = sql.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);
            }
            sql = sql.OrderBy(p => p.Id).Where(p => p.Id == palestranteId );

            return await sql.FirstOrDefaultAsync();
        }
    }
}