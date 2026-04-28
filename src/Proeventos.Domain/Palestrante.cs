using System;
using System.Collections.Generic;

namespace Proeventos.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curriculo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}