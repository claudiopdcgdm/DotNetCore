using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proeventos.Domain
{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Titulo { get; set; } 
        public string Url { get; set; }

        public int? EventoId { get; set; }
        public Evento Evento { get; set; }
       
        public int? PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
        
    }
}