using AutoMapper;
using Proeventos.Domain;
using Proeventos.DTO;

namespace Proeventos.Application.Helpers
{
    public class EventoProfile:Profile
    {
        public EventoProfile()
        {
            // CreateMap<EventoDto, Evento>(); ou assim ou o reverse
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            
        }
    }
}