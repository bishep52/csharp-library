using DB_connect.Models;
using Microsoft.EntityFrameworkCore;

namespace DB_connect.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Booking> Booking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title).IsRequired();
                entity.Property(b => b.Author).IsRequired();
                entity.Property(b => b.Year).IsRequired();
                entity.Property(b => b.IsAvailable).IsRequired();
            });

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.ToTable("readers");
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired();
                entity.Property(r => r.SecondName).IsRequired();

                entity.HasMany(r => r.Bookings)
                      .WithOne(b => b.Reader)
                      .HasForeignKey(b => b.ReaderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("bookings");
                entity.HasKey(l => l.Id);
                entity.Property(l => l.BookDate).IsRequired();
                entity.Property(l => l.ReturnDate);

                entity.HasOne(l => l.Book)
                      .WithMany()
                      .HasForeignKey(l => l.BookId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.Reader)
                      .WithMany()
                      .HasForeignKey(b => b.ReaderId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
