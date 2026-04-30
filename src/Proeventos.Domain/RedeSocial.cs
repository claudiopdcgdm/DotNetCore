using System.ComponentModel.DataAnnotations.Schema;

namespace Proeventos.Domain
{
    [Table("TbRedeSocial")]
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