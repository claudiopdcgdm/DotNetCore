using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proeventos.Domain;
using Proeventos.Persistence.Interfaces;

namespace Proeventos.Persistence
{
    public class LotePersistence : BasePersistence, ILotePersistence
    {
        public LotePersistence(ProeventosContext context) : base(context)
        {
            
        }

        
        public async Task<Lote[]> GetLotesByEventoIdAsync(int eventoId)
        {
            IQueryable<Lote> query = _context.Lotes.Include(l => l.Evento);
            query = query.AsNoTracking().OrderBy(l => l.Id).Where(l => l.EventoId == eventoId);

            return await query.AsSplitQuery().ToArrayAsync();
        }

        public async Task<Lote> GetOneLoteAsync(int eventoId, int loteId)
        {
           IQueryable<Lote> query = _context.Lotes;
           query = query.AsNoTracking().Where(lote => lote.EventoId == eventoId && lote.Id == loteId);
           return await query.FirstOrDefaultAsync();
        }
    }
}