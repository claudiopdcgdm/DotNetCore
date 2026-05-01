using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proeventos.Domain;

namespace Proeventos.Persistence.Interfaces
{
    public interface ILotePersistence:IBasePersistence
    {   
        /// <summary>
        /// Retrieves all Lotes for a specific Evento
        /// </summary>
        /// <param name="eventoId">The ID of the evento</param>
        /// <returns>A collection of Lotes</returns>
        Task<Lote[]> GetLotesByEventoIdAsync(int eventoId);
        
        /// <summary>
        /// Retrieve one Lote for a specific Lote and Evento
        /// </summary>
        /// <param name="eventoId">The ID of the evento </param>
        /// <param name="loteId">The ID of de Lote</param>
        /// <returns>A Lote object</returns>
        Task<Lote> GetOneLoteAsync(int eventoId,int loteId);
    }
}