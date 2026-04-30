using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Proeventos.DTO
{
    public class EventoDto
    {

        public int Id { get; set; }

        [
            Required(ErrorMessage ="Campo {0} Obrigatório!"),
            StringLength(50, MinimumLength =3, ErrorMessage ="Minimo 3 a maximo 50 caracters")

        ]
        public string Tema { get; set; }
        
        public string Local { get; set; }
        [
            RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",ErrorMessage = "Formato de imagem inváldo, aceitos (jpeg,jpg ou png)")
        ]
        public string ImgUrl { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Informe a quantidade de pessoas!")]
        public int QtdPessoas { get; set; }
        
        [Required(ErrorMessage ="Campo {0} Obrigatório!")]
         public string DataEvento { get; set; }
        
        [
            Required(ErrorMessage = "Telefone é obrigatório"),
            RegularExpression(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", 
            ErrorMessage = "Telefone inválido")
        ]    
        public string Telefone { get; set; }
        
        [   
            Display(Name = "e-mail"),
            Required(ErrorMessage ="Campo {0} obrigátorio"),
            EmailAddress(ErrorMessage ="Campo {0} inválido!")
        ]
        public string Email { get; set; }

        public ICollection<LoteDto> Lotes  { get; set; }// (1 X N)
        
        public ICollection<RedeSocialDto> RedesSociais { get; set; } // (1 X N)

        public ICollection<PalestranteDto> Palestrantes { get; set; }//(N X N)
        
        
    }
}