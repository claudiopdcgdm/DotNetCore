using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proeventos.Domain
{
    [Table("TbEvento")]
    public class Evento
    {
        public int Id { get; set; }
        [
            Required,
            MaxLength(100)
        ]
        public string Tema { get; set; }
        public string Local { get; set; }
        public string ImgUrl { get; set; }
        public int QtdPessoas { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public IEnumerable<Lote> Lotes  { get; set; }// (1 X N)
        
        public IEnumerable<RedeSocial> RedesSociais { get; set; } // (1 X N)

        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }//(N X N)

        [NotMapped]
        public string campoNaoVaiParaOBanco { get; set; }
        


    }
}