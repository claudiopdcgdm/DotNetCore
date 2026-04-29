using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proeventos.DTO
{
    public class RedeSocialDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } 
        public string Url { get; set; }

        public int? EventoId { get; set; }
        public EventoDto Evento { get; set; }
       
        public int? PalestranteId { get; set; }
        public PalestranteDto Palestrante { get; set; }
        
    }
}