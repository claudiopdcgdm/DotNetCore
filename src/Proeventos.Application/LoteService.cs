using System;
using System.Linq;
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
        public async Task<LoteDto[]> SaveLotes(int eventoId, LoteDto[] models)
        {
            try
            {
                var lotesDomain = await _lotePersistence.GetLotesByEventoIdAsync(eventoId);
                
                if (lotesDomain != null)
                {
                    foreach (var model in models)
                    {
                        //Se o modelo passado na requisição for diferente de 0 ele executa o update do Lote, pois possui Id
                        if (model.Id != 0 )
                        {
                            var loteDomain = lotesDomain.FirstOrDefault(lote => lote.Id == model.Id);
                            model.Id = loteDomain.Id; //Garante a consistencia do update
                            // _mapper.Map<Lote>(model);
                            _mapper.Map(model,loteDomain); //mapeia de o modelo passado(LoteDto) para Dominio(LoteDomain), para salvar no banco
                            _lotePersistence.Update<Lote>(loteDomain);
                            await _lotePersistence.SaveChangesAsync();
                        }
                        // Insere no banco
                        else
                        {
                            model.EventoId = eventoId;
                            var lotePersist = _mapper.Map<Lote>(model);
                            // lotePersist.EventoId = eventoId;
                            _lotePersistence.Add(lotePersist);
                            
                            if (!await _lotePersistence.SaveChangesAsync())
                            {
                                throw new Exception("Falha ao Inserir novo Lote");
                            }
                        }

                    
                    }
                    
                    var result = await _lotePersistence.GetLotesByEventoIdAsync(eventoId);
                    return _mapper.Map<LoteDto[]>(result);
                }

                return null;                
                

            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao salvar/atualizar Lotes:{ex.Message}");
            } 
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