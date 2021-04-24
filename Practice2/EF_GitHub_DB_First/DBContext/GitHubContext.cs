using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EF_GitHub_DB_First.Entites;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EF_GitHub_DB_First.DBContext
{
    public partial class GitHubContext : DbContext
    {
        public GitHubContext()
        {
        }

        public GitHubContext(DbContextOptions<GitHubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Repository> Repository { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=GitHub;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .IsUnique()
                    .HasFilter("([Username] IS NOT NULL)");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(40);
            });

            modelBuilder.Entity<Repository>(entity =>
            {
                entity.HasIndex(e => e.ProfileId);

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Repository)
                    .HasForeignKey(d => d.ProfileId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
