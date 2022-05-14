using Microsoft.AspNetCore.Identity;

namespace uwierzytelnianie.Models
{
    public class AppUser : IdentityUser
    {
        public List<Person>? People { get; set; }
    }
}
