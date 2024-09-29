using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace STEP_backend.Entity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Package> Packages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Using table-per-hierarchy (TPH) pattern with a discriminator column.
            builder.Entity<ApplicationUser>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Teacher>("Teacher")
                .HasValue<Student>("Student");
        }


    }
}
