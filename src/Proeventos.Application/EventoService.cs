using System;
using System.Threading.Tasks;
using Proeventos.Application.Interfaces;
using Proeventos.Domain;
using Proeventos.Persistence;

namespace Proeventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersistence _eventoPersistence;
       
        public EventoService(IEventoPersistence eventoPersistence)
        {
            this._eventoPersistence = eventoPersistence;
            
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _eventoPersistence.Add<Evento>(model); 

                if (await _eventoPersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);   
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception( $"Falha na Inserção: {ex.Message} ");
            }
           
            
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId);
                // if(evento == null) return null;
                if (evento != null)
                {
                    _eventoPersistence.Update(model);
                    
                    if (await _eventoPersistence.SaveChangesAsync())
                    {
                        return await _eventoPersistence.GetEventoByIdAsync(eventoId);
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

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventoAsync(includePalestrantes);
                return eventos != null ? eventos : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha na busca de todos: {ex.Message}");
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                return eventos != null ? eventos : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha na busca por Tema: {ex.Message}");
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
                return evento != null ? evento : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha na busca por ID: {ex.Message}");
            }
        }

        
    }
}
