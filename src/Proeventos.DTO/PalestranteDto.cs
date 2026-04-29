using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proeventos.DTO
{
    public class PalestranteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curriculo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
        
    }
}