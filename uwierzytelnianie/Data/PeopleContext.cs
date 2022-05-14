using uwierzytelnianie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace uwierzytelnianie.Data
{
    public class PeopleContext : IdentityDbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }
        public DbSet<Person> Person { get; set; }

    }
}
