using Microsoft.AspNetCore.Identity;

namespace Chuska.Models
{
    public class ChushkaUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}