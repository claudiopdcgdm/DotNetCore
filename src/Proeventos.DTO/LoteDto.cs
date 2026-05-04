using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proeventos.DTO
{
    public class LoteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public int Quantidade { get; set; }
        //  [Required(ErrorMessage ="Campo {0} Obrigatório!")]
        public int? EventoId { get; set; }
        // public EventoDto Evento { get; set; }
    }
}