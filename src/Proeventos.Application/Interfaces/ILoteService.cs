using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proeventos.DTO;

namespace Proeventos.Application.Interfaces
{
    public interface ILoteService
    {
        
        /// <summary>
        /// Retrieve a Lote for a specific Evento
        /// </summary>
        /// <param name="eventoId">The ID of the evento</param>
        /// <param name="loteId">The ID of the Lote</param>
        /// <returns>A Lote Object</returns>
        Task<LoteDto> GetOneLoteAsync(int eventoId, int loteId);
        /// <summary>
        /// Retrieve all Lotes for a specifc Evento
        /// </summary>
        /// <param name="eventoId">the ID of the evento</param>
        /// <returns>List of the Lotes</returns>
        Task<LoteDto[]> GetLotesByEventoAsync(int eventoId);
        /// <summary>
        /// Update many Lote for a specific Evento
        /// </summary>
        /// <param name="eventoId">The ID of the evento</param>
        /// <param name="model">The model of the Lote</param>
        /// <returns>A Lote Object</returns>
        Task<LoteDto> SaveLote(int eventoId, LoteDto[] models);

        /// <summary>
        /// Remove a Lote for a specific Evento
        /// </summary>
        /// <param name="eventoId">The ID of the evento</param>
        /// <param name="loteId">The ID of the Lote</param>
        /// <returns>true or false</returns>
        Task<bool> DeleteLote(int eventoId,int loteId);
        
    }
}