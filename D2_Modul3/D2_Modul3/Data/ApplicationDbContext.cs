using D2_Modul3.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace D2_Modul3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Modules> Modules { get; set; }
        public DbSet<Coupons> Coupons { get; set; }
        public DbSet<Purchases> Purchases { get; set; }

    }
}
