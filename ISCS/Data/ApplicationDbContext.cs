using System;
using ISCS.Data.Entities;
using ISCS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ISCS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Area> Areas { get; set; }

        public DbSet<AreaWork> AreaWorks { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<EquipmentOperation> EquipmentOperations { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<TechCard> TechCards { get; set; }

        public DbSet<TechCardEquipment> TechCardEquipments { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<TechCardOperation> TechCardOperations { get; set; }

        public DbSet<Hazard> Hazards { get; set; }

        public DbSet<HazardControl> HazardControls { get; set; }

        public DbSet<TechCardHazardControl> TechCardHazardControls { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EquipmentOperation>()
                .HasOne(x => x.Equipment)
                .WithMany(x => x.EquipmentOperations);
            builder.Entity<EquipmentOperation>()
                .HasOne(x => x.Operation)
                .WithMany(x => x.EquipmentOperations);
            builder.Entity<Area>()
                .HasMany(x => x.Equipments)
                .WithOne(x => x.Area);
            builder.Entity<TechCardEquipment>()
                .HasKey(x => new { x.EquipmentId, x.TechCardId });
            builder.Entity<TechCardEquipment>()
                .HasOne(x => x.Equipment)
                .WithMany(x => x.TechCardEquipments);
            builder.Entity<TechCardEquipment>()
                .HasOne(x => x.TechCard)
                .WithMany(x => x.TechCardEquipments);
            builder.Entity<AreaWork>()
                .HasKey(x => new { x.WorkId, x.AreaId });
            builder.Entity<AreaWork>()
                .HasOne(x => x.Area)
                .WithMany(x => x.AreaWorks);
            builder.Entity<AreaWork>()
                .HasOne(x => x.Work)
                .WithMany(x => x.AreaWorks);
            builder.Entity<TechCard>()
                .HasOne(x => x.Work);
            builder.Entity<TechCard>()
                .Property(x => x.IsActual)
                .HasDefaultValue(true);
            builder.Entity<TechCard>()
                .Property(x => x.CreationDate)
                .HasDefaultValue(DateTime.Today);
            builder.Entity<TechCardOperation>()
                .HasKey(x => new {x.TechCardId, x.EquipmentOperationId});
            builder.Entity<TechCardOperation>()
                .HasOne(x => x.TechCard)
                .WithMany(x => x.TechCardOperations);
            builder.Entity<TechCardOperation>()
                .HasOne(x => x.EquipmentOperation);
            builder.Entity<TechCard>()
                .Property(x => x.TechCardState)
                .HasDefaultValue(TechCardStates.Created);
            builder.Entity<Hazard>()
                .HasMany(x => x.HazardControls)
                .WithOne(x => x.Hazard);
            builder.Entity<TechCardHazardControl>()
                .HasOne(x => x.TechCard)
                .WithMany(x => x.TechCardHazardControls);
            builder.Entity<TechCardHazardControl>()
                .HasOne(x => x.HazardControl)
                .WithMany(x => x.TechCardHazardControls);
        }
    }
}
