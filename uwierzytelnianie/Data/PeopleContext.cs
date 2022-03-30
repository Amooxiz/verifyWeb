using uwierzytelnianie.Models;
using Microsoft.EntityFrameworkCore;

namespace uwierzytelnianie.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Person { get; set; }

    }
}
