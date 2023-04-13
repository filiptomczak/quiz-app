using Microsoft.EntityFrameworkCore;

namespace QuizTerenowyAPI.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
        public DbSet<Place> Places{ get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<User> Users{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
                .HasMany(p => p.Questions)
                .WithOne(q => q.Place)
                .HasForeignKey(q => q.PlaceId)
                .IsRequired(true);

            base.OnModelCreating(modelBuilder);
        }
    }
    
}
