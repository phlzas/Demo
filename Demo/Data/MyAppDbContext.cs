using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ArtPiece> ArtPieces { get; set; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoyaltyCard>()
                .HasIndex(l => l.CardNumber)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(l => l.Name)
                .IsUnique();


            modelBuilder.Entity<Customer>()
                .HasOne(c => c.LoyaltyCard)
                .WithOne(c => c.Customer)
                .HasForeignKey<LoyaltyCard>(c => c.CustomerId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.ArtPieces)
                .WithMany(c => c.Categories)
                .UsingEntity(j => j.ToTable("ArtPieceCategory"));


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" },    
                new Category { Id = 3, Name = "Category 3" },    
                new Category { Id = 4, Name = "Category 4" }    
            );
        }
    }
}
