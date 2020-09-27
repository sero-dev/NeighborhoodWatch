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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>(entity =>
            {
                entity.ToTable("incident");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.County)
                    .IsRequired()
                    .HasColumnName("county");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
