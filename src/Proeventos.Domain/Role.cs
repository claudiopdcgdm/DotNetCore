using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Proeventos.Domain
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        
    }
}