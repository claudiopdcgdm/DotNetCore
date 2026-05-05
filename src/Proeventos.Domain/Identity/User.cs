using System.Collections.Generic;
using Proeventos.Domain.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proeventos.Domain.Identity
{
    [Table("TbUser")]
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Titulo Titulo { get; set; }
        public string Description { get; set; }
        public Funcao Funcao { get; set; }
        public string ImagePerfil { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}