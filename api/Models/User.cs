using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User : IdentityUser<int>
    {
        public virtual List<AccountGroup> AccountGroups { get; set; }
    }
}