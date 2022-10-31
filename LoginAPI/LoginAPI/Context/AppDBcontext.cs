using LoginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Context
{
    public class AppDBcontext: DbContext
    {
        public AppDBcontext(DbContextOptions <AppDBcontext> options):base(options)
        {
                
        }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("users");
        }
    }
}
