using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<CsnivSenha> CsnivSenha { get; set; }
        public virtual DbSet<UserLike> Likes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CsnivSenha>(entity =>
            {
                entity.HasKey(e => e.NumCotista);

                entity.ToTable("CSNIV_Senha");

                entity.Property(e => e.NumCotista)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DataAlt).HasColumnType("smalldatetime");

                entity.Property(e => e.Senha)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
            
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("AppUser");
            });

            modelBuilder.Entity<UserLike>()
                .HasKey(k => new {k.SourceUserId, k.LikedUserId});

            modelBuilder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<UserLike>()
                .HasOne(s => s.LikedUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.LikedUserId)
                .OnDelete(DeleteBehavior.NoAction);
          
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
