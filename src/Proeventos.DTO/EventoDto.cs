using System;
using System.Collections.Generic;

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

        public ICollection<LoteDto> Lotes  { get; set; }// (1 X N)
        
        public ICollection<RedeSocialDto> RedesSociais { get; set; } // (1 X N)

        public ICollection<PalestranteDto> Palestrantes { get; set; }//(N X N)
        
        
    }
}