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

        public virtual DbSet<Favouritesport> Favouritesports { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United Kingdom.1252");

            modelBuilder.Entity<Favouritesport>(entity =>
            {
                entity.HasKey(e => new { e.Personid, e.Sportid })
                    .HasName("pk_favouritesports");

                entity.ToTable("favouritesports", "tappittechnicaltest");

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.Property(e => e.Sportid).HasColumnName("sportid");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Favouritesports)
                    .HasForeignKey(d => d.Personid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_favouritesports_people");

                entity.HasOne(d => d.Sport)
                    .WithMany(p => p.Favouritesports)
                    .HasForeignKey(d => d.Sportid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_favouritesports_sports");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("people", "tappittechnicaltest");

                entity.Property(e => e.Personid).HasColumnName("personid");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Isauthorised).HasColumnName("isauthorised");

                entity.Property(e => e.Isenabled).HasColumnName("isenabled");

                entity.Property(e => e.Isvalid).HasColumnName("isvalid");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastname");
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.ToTable("sports", "tappittechnicaltest");

                entity.Property(e => e.Sportid).HasColumnName("sportid");

                entity.Property(e => e.Isenabled).HasColumnName("isenabled");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
