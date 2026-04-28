using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proeventos.Domain
{
    public class PalestranteEvento
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}