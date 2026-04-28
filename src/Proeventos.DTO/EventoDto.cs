
namespace Proeventos.DTO
{
    public class EventoDto
    {

        public int Id { get; set; }
        public string Tema { get; set; }
        public string Local { get; set; }
        public string ImgUrl { get; set; }
        public int QtdPessoas { get; set; }
        public string DataEvento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // public IEnumerable<Lote> Lotes  { get; set; }// (1 X N)
        
        // public IEnumerable<RedeSocial> RedesSociais { get; set; } // (1 X N)

        // public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }//(N X N)
        
        
    }
}