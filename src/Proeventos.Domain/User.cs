using System.Collections.Generic;
using Proeventos.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace Proeventos.Domain
{
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