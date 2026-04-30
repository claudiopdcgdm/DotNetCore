using System.ComponentModel.DataAnnotations.Schema;

namespace Proeventos.Domain
{
    [Table("TbPalestraneEvento")]
    public class PalestranteEvento
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
    }
}