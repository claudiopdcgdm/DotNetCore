using System;
using System.Threading.Tasks;
using AutoMapper;
using Proeventos.Application.Interfaces;
using Proeventos.Domain;
using Proeventos.DTO;
using Proeventos.Persistence.Interfaces;

namespace Proeventos.Application
{
    public class LoteService : ILoteService
    {
        private readonly ILotePersistence _lotePersistence;
        private readonly IMapper _mapper;
        
        public LoteService(ILotePersistence lotePersistence, IMapper mapper)
        {
            this._mapper = mapper;
            this._lotePersistence = lotePersistence;
            
        }
        public async Task<LoteDto> GetOneLoteAsync(int eventoId, int loteId)
        {
            try
            {
                var lotePersist  = await _lotePersistence.GetOneLoteAsync(eventoId,loteId);
                var result = _mapper.Map<LoteDto>(lotePersist);
                return result != null ? result : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha na busca por Lote: {ex.Message}");
            }
        }
        public async Task<LoteDto[]> GetLotesByEventoAsync(int eventoId)
        {
            try
            {
                var lotesDomain  = await _lotePersistence.GetLotesByEventoIdAsync(eventoId);
                var result = _mapper.Map<LoteDto[]>(lotesDomain);
                return result != null ? result : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha na busca de Lotes por Evento: {ex.Message}");
            }
        }
        public Task<LoteDto> SaveLote(int eventoId, LoteDto[] models)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteLote(int eventoId, int loteId)
        {
             try
            {
                var loteDomain = await _lotePersistence.GetOneLoteAsync(eventoId,loteId);

                if (loteDomain != null)
                {
                    _lotePersistence.Remove<Lote>(loteDomain);
                    return await _lotePersistence.SaveChangesAsync();
                }

                throw new Exception($"Lote não encontrado!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha na exclusão: {ex.Message}");
            }
        }

      

     
    }
}