using System;
using System.Collections.Generic;
using ADN.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ADN.Data.Data
{
    public partial class DbADNContext : DbContext
    {
        public DbADNContext()
        {
        }

        public DbADNContext(DbContextOptions<DbADNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adn> Adns { get; set; }
        public virtual DbSet<Estadistica> Estadisticas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adn>(entity =>
            {
                entity.ToTable("Adn");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Adn1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADN");
            });

            modelBuilder.Entity<Estadistica>(entity =>
            {
                entity.ToTable("Estadistica");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Llave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LLave");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
