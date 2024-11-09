using CSWork21.Enities;
using CSWork21.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSWork21.Contexts
{
    public class PhoneBookDbContext : IdentityDbContext<User>
    {
        public DbSet<Contact> Contacts { get; set; }

        public PhoneBookDbContext(DbContextOptions options) : base(options) {}

    }
}
