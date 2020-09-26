using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NeighborhoodWatch.DAC.Entity;

namespace NeighborhoodWatch.DAC.Context
{
    public partial class IncidentContext : DbContext
    {
        public IncidentContext()
        {
        }

        public IncidentContext(DbContextOptions<IncidentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Incident> Incident { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new InvalidOperationException("Database context is not configured");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>(entity =>
            {
                entity.ToTable("incident");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
