using API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace API.DataAccess.EFCore
{
    public partial class TappitTechnicalTestContext : DbContext
    {
        public TappitTechnicalTestContext()
        {
        }

        public TappitTechnicalTestContext(DbContextOptions<TappitTechnicalTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavouriteSport> FavouriteSports { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<FavouriteSport>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.SportId });

                entity.ToTable("FavouriteSports", "TappitTechnicalTest");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.FavouriteSports)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FavouriteSports_People");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.FavouriteSports)
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FavouriteSports_Sports");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("People", "TappitTechnicalTest");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.ToTable("Sports", "TappitTechnicalTest");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
