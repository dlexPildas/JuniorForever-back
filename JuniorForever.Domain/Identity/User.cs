using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace JuniorForever.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public List<UserRole> UserRoles { get; set; }
    }
}
