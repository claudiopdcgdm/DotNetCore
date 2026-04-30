using System;
using System.Threading.Tasks;
using AutoMapper;
using Proeventos.Application.Interfaces;
using Proeventos.Domain;
using Proeventos.DTO;
using Proeventos.Persistence;

namespace Proeventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersistence _eventoPersistence;
        
        private readonly IMapper _mapper;
       
        public EventoService(IEventoPersistence eventoPersistence, IMapper mapper)
        {
            this._mapper = mapper;
            this._eventoPersistence = eventoPersistence;
            
        }
        public async Task<EventoDto> AddEvento(EventoDto model)
        {
            try
            {
                var eventoPersist = _mapper.Map<Evento>(model); //mapeia de eventoDto para Evento(persit)
                
                // Insere no banco
                _eventoPersistence.Add<Evento>(eventoPersist); 

                if (await _eventoPersistence.SaveChangesAsync())
                {
                    var eventoResult = await _eventoPersistence.GetEventoByIdAsync(eventoPersist.Id, false); //retorna um evento Persiste(classe de dominio)
                    var eventoDto = _mapper.Map<EventoDto>(eventoPersist); //Converte(mapeia) o dominio Evento para EventoDto
                    return eventoDto;
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception( $"Falha na Inserção: {ex.Message} ");
            }
           
            
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var eventoPersit = _mapper.Map<Evento>(model); // Mapeia a EventoDto para Evento(Persistencia);
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId);
                eventoPersit.Id = eventoId;

                //verifica existencia do objeto
                if (evento != null)
                {   
                    _eventoPersistence.Update(eventoPersit);
                    
                    if (await _eventoPersistence.SaveChangesAsync())
                    {
                        var eventorResult = await _eventoPersistence.GetEventoByIdAsync(eventoPersit.Id, false);
                        
                        return _mapper.Map<EventoDto>(eventorResult);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Falha no update: {ex.Message}");
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var modelEvento = await _eventoPersistence.GetEventoByIdAsync(eventoId);

                if (modelEvento != null)
                {
                    _eventoPersistence.Remove<Evento>(modelEvento);
                    return await _eventoPersistence.SaveChangesAsync();
                }

                throw new Exception($"Evento {eventoId} não encontrado!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha na exclusão: {ex.Message}");
            }
        }

        public async Task<EventoDto[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventoAsync(includePalestrantes);
                var result = _mapper.Map<EventoDto[]>(eventos);
                return result != null ? result : null;
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha na busca de todos: {ex.Message}");
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                var result = _mapper.Map<EventoDto[]>(eventos); //Faz o mapeamento automático do resultado da persistencia(dados do banco)
                return result != null ? result : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha na busca por Tema: {ex.Message}");
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
                
                var result = _mapper.Map<EventoDto>(evento); //Faz o mapeamento automático do resultado da persistencia(dados do banco)
                
                return result != null ? result : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha na busca por ID: {ex.Message}");
            }
        }

        
    }
}
