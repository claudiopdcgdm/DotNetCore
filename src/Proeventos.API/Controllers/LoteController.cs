using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        /// Retrived Lote for evento and Lote
        /// </summary>
        /// <param name="eventoId">eventoId</param>
        /// <returns>Lote Obejct</returns>
        [HttpGet("evento/{eventoId}/lote/{loteId}")]
        public async Task<ActionResult> GetOneLoteAsync(int eventoId, int loteId)
        {
            try
            {
                var lote = await _loteService.GetOneLoteAsync(eventoId,loteId);
                return lote != null? Ok(lote):NoContent();

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar LOTE. Erro: {ex.Message}");    
            }
        }
        
        /// <summary>
        /// Retrived Lotes for eventoId
        /// </summary>
        /// <param name="eventoId">eventoId</param>
        /// <returns>Lotes Obejct</returns>
        [HttpGet("evento/{eventoId}")]
        public async Task<ActionResult> GetLotesByEventoAsync(int eventoId)
        {
            try
            {
                var lotes = await _loteService.GetLotesByEventoAsync(eventoId);
                return lotes != null ? Ok(lotes):NoContent();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar LOTES. Erro: {ex.Message}");    
            }
        }

        /// <summary>
        /// Update Lote for eventoId
        /// </summary>
        /// <param name="eventoId">int eventoId</param>
        /// <param name="models">list LoteDto from body</param>
        /// <returns>LoteDto</returns>
        [HttpPut("evento/{eventoId}")]
        public async Task<ActionResult> SaveLotes(int eventoId, LoteDto[] models)
        {
           try
            {
                // var evento = await _eventoService.UpdateEvento(id, model);
                var lote = await _loteService.SaveLotes(eventoId, models);
                return lote != null ? Ok(lote): NotFound("Lote não encontrado!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar Atualizar/Salvar Lotes. Erro: {ex.Message}");                
            }
            
        }
        /// <summary>
        /// Remove Lote from evento 
        /// </summary>
        /// <param name="eventoId">int eventoId</param>
        /// <param name="loteId">int LoteId</param>
        /// <returns>bool (true=success,false=failed</returns>
        [HttpDelete("evento/{eventoId}/lote/{loteId}")]
        public async Task<ActionResult> Delete(int eventoId,int loteId)
        {
            try
            {
                var lote = await _loteService.GetOneLoteAsync(eventoId,loteId);

                if (lote != null)
                {
                    await _loteService.DeleteLote(eventoId,loteId); 
                    return Ok("Lote Deletado!");
                }
                
                return NotFound($"Lote {loteId} do Evento {eventoId} não encontrado!");

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao Excluir lote: {ex.Message}");
            }
        }
    }
}