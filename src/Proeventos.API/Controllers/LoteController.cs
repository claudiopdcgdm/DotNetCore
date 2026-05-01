using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proeventos.Application.Interfaces;
using Proeventos.DTO;

namespace Proeventos.API
{
    [ApiController]
    [Route("api/[controller]")]
       public class LoteController : ControllerBase
    {
        private readonly ILoteService _loteService;

        public LoteController(ILoteService loteService)
        {
            this._loteService = loteService;
            
        }
        /// <summary>
        /// Search Lotes for eventoId
        /// </summary>
        /// <param name="eventoId">eventoId</param>
        /// <returns>Lotes Collection</returns>
        [HttpGet("{eventoId}")]
        public Task<ActionResult> GetByEventoId(int eventoId)
        {
            return null;
        }

        /// <summary>
        /// Update Lote for eventoId
        /// </summary>
        /// <param name="eventoId">int eventoId</param>
        /// <param name="models">list LoteDto from body</param>
        /// <returns>LoteDto</returns>
        [HttpPut("{eventoId}")]
        public Task<ActionResult> Put(int eventoId, LoteDto[] models)
        {
            return null;
        }
        /// <summary>
        /// Remove Lote from evento 
        /// </summary>
        /// <param name="eventoId">int eventoId</param>
        /// <param name="loteId">int LoteId</param>
        /// <returns>bool (true=success,false=failed</returns>
        [HttpDelete("{eventoId}/{loteId}")]
        public Task<bool> Delete(int eventoId,int loteId)
        {
            return null;
        }
    }
}