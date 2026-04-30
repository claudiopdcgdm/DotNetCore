using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Proeventos.DTO
{
    public class EventoDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Campo {0} Obrigatório!")]
        public string Tema { get; set; }
        
        public string Local { get; set; }
        public string ImgUrl { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Informe a quantidade de pessoas!")]
        public int QtdPessoas { get; set; }
        
        [Required(ErrorMessage ="Campo {0} Obrigatório!")]
         public string DataEvento { get; set; }
        
        [Required(ErrorMessage = "Telefone é obrigatório")]
        [RegularExpression(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", 
        ErrorMessage = "Telefone inválido")]    
        public string Telefone { get; set; }
        
        [Required(ErrorMessage ="Campo {0} Obrigatório!")]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<LoteDto> Lotes  { get; set; }// (1 X N)
        
        public ICollection<RedeSocialDto> RedesSociais { get; set; } // (1 X N)

        public ICollection<PalestranteDto> Palestrantes { get; set; }//(N X N)
        
        
    }
}