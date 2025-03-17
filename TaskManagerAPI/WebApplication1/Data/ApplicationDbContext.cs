using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<TaskItems> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura TaskItemId como clave primaria
            modelBuilder.Entity<TaskItems>()
                .HasKey(t => t.Id); // Especifica la clave primaria
        }
    }
}

