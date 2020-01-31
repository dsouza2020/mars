using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarsProject.Models
{
    public partial class MARSContext : DbContext
    {
        public MARSContext()
        {
        }

        public MARSContext(DbContextOptions<MARSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Photos> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SqlServer;Database=MARS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.HasKey(e => e.PhotoId)
                    .HasName("PK__Photos__21B7B58254C555BD");

                entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

                entity.Property(e => e.EarthDate)
                    .HasColumnName("earth_date")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImgSrc)
                    .HasColumnName("img_src")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sol).HasColumnName("sol");
            });
        }
    }
}
