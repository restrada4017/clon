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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adn>(entity =>
            {
                entity.ToTable("ADN");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.Adn1)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("ADN");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
