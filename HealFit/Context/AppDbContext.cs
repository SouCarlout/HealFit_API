using HealFit.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HealFit.Context {
    public class AppDbContext : DbContext {  // Alterar de IdentityDbContext para DbContext

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public DbSet<Usuario>? Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            

            base.OnModelCreating(modelBuilder); // Chamar apenas uma vez
        }
    }
}
