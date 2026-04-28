using AutoMapper;
using Proeventos.Domain;
using Proeventos.DTO;

namespace Proeventos.API.Helpers
{
    public class EventoProfile:Profile
    {
        public EventoProfile()
        {
            CreateMap<Evento,EventoDto>();
        }
        
    }
}