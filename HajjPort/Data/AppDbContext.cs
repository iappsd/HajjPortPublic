using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HajjPort.Models;
using Microsoft.AspNetCore.Identity;
using HajjPort.Models;

namespace HajjPort.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Port> Port { get; set; }
        public DbSet<PortOperations> PortOperations { get; set; }
    }
}
