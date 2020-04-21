using Formula1.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Formula1.DataAccess.Context
{
    public partial class F1TeamContext : DbContext
    {
        public F1TeamContext()
        {
        }

        public F1TeamContext(DbContextOptions<F1TeamContext> options) : base(options)
        {
        }

        public virtual DbSet<F1Team> F1Team { get; set; }
        public virtual DbSet<Rider> Rider { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<F1Team>(entity =>
                {
                    entity.Property(c => c.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(c => c.TeamName).IsRequired();
                    entity.Property(c => c.LeaderName).IsRequired();
                    entity.Property(c => c.TeamCountry).IsRequired();
                });

            modelBuilder.Entity<Rider>(entity =>
                {
                    entity.Property(s=>s.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    entity.Property(s => s.Name).IsRequired();
                    entity.Property(s => s.Country).IsRequired();
                    entity.Property(s => s.Seasons).IsRequired();
                    entity.Property(s => s.Champion).IsRequired();
                    entity.Property(s => s.Starts).IsRequired();
                    entity.Property(s => s.Wins).IsRequired();
                    entity.Property(s => s.Poles).IsRequired();
                    entity.HasOne(s => s.F1Team)
                        .WithMany(c => c.Rider)
                        .HasForeignKey(s => s.F1TeamId)
                        .HasConstraintName("FK_Rider_F1Team");
                });
            
            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}