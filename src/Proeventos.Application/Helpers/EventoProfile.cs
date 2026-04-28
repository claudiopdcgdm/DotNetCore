using AutoMapper;
using Proeventos.Domain;
using Proeventos.DTO;

namespace Proeventos.Application.Helpers
{
    public class EventoProfile:Profile
    {
        public EventoProfile()
        {
            CreateMap<Evento, EventoDto>();
        }
    }
}