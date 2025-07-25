﻿using mhwilds.Domain.Entities;
using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;
using mhwilds.Domain.Entities.Weapons.Melee;
using mhwilds.Domain.Entities.Weapons.Ranged;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace mhwilds.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Armour> Armours { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillRank> SkillRanks { get; set; }
        public DbSet<Charm> Charms { get; set; }
        public DbSet<CharmRank> CharmRanks { get; set; }
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<BaseWeapon> Weapons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* relationships */
            // armours, skills/skillranks, charms, decorations
            ConfigureGeneralEntityModels(modelBuilder);

            // weapons specifics - base, ranged, melee
            ConfigureWeaponInheritance(modelBuilder);

            // configure all owned types between models:
            // armour -> resistances
            // weapons -> ammo, damage, element
            ConfigureOwnedTypes(modelBuilder);

            // convert coating types to string to store in db
            ConfigureBowCoatings(modelBuilder);
        }

        private void ConfigureGeneralEntityModels(ModelBuilder modelBuilder)
        {
            // skill -> skillRanks
            // 1 - many
            modelBuilder.Entity<Skill>()
                .HasMany(s => s.Ranks)
                .WithOne(sr => sr.Skill)
                .HasForeignKey(sr => sr.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            // armour -> skillRanks
            // many - many            
            modelBuilder.Entity<Armour>()
                .HasMany(a => a.Skills)
                .WithMany(sr => sr.Armours);

            // charm -> charmRanks
            // 1 - many
            modelBuilder.Entity<Charm>()
                .HasMany(c => c.Ranks)
                .WithOne(cr => cr.Charm)
                .HasForeignKey(cr => cr.CharmId)
                .OnDelete(DeleteBehavior.Cascade);

            // charmRanks -> skillRanks
            // many - many
            modelBuilder.Entity<CharmRank>()
                .HasMany(cr => cr.Skills)
                .WithMany(sr => sr.Charms);

            // decorations -> skillRanks
            // many - many            
            modelBuilder.Entity<Decoration>()
                .HasMany(a => a.Skills)
                .WithMany(sr => sr.Decorations);
        }

        private void ConfigureWeaponInheritance(ModelBuilder modelBuilder)
        {
            // weapon inheritance configuration
            modelBuilder.Entity<BaseWeapon>()
                .HasDiscriminator(w => w.WeaponType)
                .HasValue<Greatsword>(WeaponType.Greatsword)
                .HasValue<Longsword>(WeaponType.Longsword)
                .HasValue<DualBlades>(WeaponType.DualBlades)
                .HasValue<Hammer>(WeaponType.Hammer)
                .HasValue<HuntingHorn>(WeaponType.HuntingHorn)
                .HasValue<Gunlance>(WeaponType.Gunlance)
                .HasValue<Lance>(WeaponType.Lance)
                .HasValue<SwordAndShield>(WeaponType.SwordAndShield)
                .HasValue<ChargeBlade>(WeaponType.ChargeBlade)
                .HasValue<SwitchAxe>(WeaponType.SwitchAxe)
                .HasValue<InsectGlaive>(WeaponType.InsectGlaive)
                .HasValue<LightBowgun>(WeaponType.LightBowgun)
                .HasValue<HeavyBowgun>(WeaponType.HeavyBowgun)
                .HasValue<Bow>(WeaponType.Bow);

            // index weapontype for better query performance
            modelBuilder.Entity<BaseWeapon>()
               .HasIndex(w => w.WeaponType);

            // configure: many to many relationship between weapons and skills
            modelBuilder.Entity<BaseWeapon>()
                .HasMany(w => w.Skills)
                .WithMany()
                .UsingEntity(j => j.ToTable("BaseWeaponSkillRank"));

            ConfigureMeleeWeaponSharpness(modelBuilder);
        }

        private void ConfigureOwnedTypes(ModelBuilder modelBuilder)
        {
            // armour / resistances relation
            // resistances is owned by armour
            // it is not a separate table
            modelBuilder.Entity<Armour>()
                .OwnsOne(a => a.Resistances);

            // Damage: owned type to base weapon
            modelBuilder.Entity<BaseWeapon>()
                .OwnsOne(w => w.Damage, damage =>
                {
                    damage.Property(d => d.Raw)
                        .HasColumnName("DamageRaw")
                        .IsRequired();

                    damage.Property(d => d.Display)
                        .HasColumnName("DamageDisplay")
                        .IsRequired();
                });

            // Element: owned type to base weapon
            modelBuilder.Entity<BaseWeapon>()
                .OwnsOne(w => w.Element, element =>
                {
                    element.Property(e => e.Type)
                        .HasColumnName("ElementType")
                        .HasMaxLength(50);

                    element.OwnsOne(e => e.Damage, elementDamage =>
                    {
                        elementDamage.Property(d => d.Raw)
                            .HasColumnName("ElementDamageRaw");

                        elementDamage.Property(d => d.Display)
                            .HasColumnName("ElementDamageDisplay");
                    });
                });

            // configure shell as owned type for gunlance
            modelBuilder.Entity<Gunlance>()
                .OwnsOne(g => g.Shell);

            // configure unique table for each gun type:
            modelBuilder.Entity<LightBowgun>()
                .OwnsMany(lgb => lgb.Ammo, ammo =>
                {
                    ammo.ToTable("LightBowgunAmmo");
                });

            modelBuilder.Entity<HeavyBowgun>()
                .OwnsMany(hgb => hgb.Ammo, ammo =>
                {
                    ammo.ToTable("HeavyBowgunAmmo");
                });
        }

        private void ConfigureMeleeWeaponSharpness(ModelBuilder modelBuilder)
        {
            // configure sharpness for all melee weapon types
            ConfigureSharpnessForWeapon<Greatsword>(modelBuilder);
            ConfigureSharpnessForWeapon<Longsword>(modelBuilder);
            ConfigureSharpnessForWeapon<DualBlades>(modelBuilder);
            ConfigureSharpnessForWeapon<Hammer>(modelBuilder);
            ConfigureSharpnessForWeapon<HuntingHorn>(modelBuilder);
            ConfigureSharpnessForWeapon<Gunlance>(modelBuilder);
            ConfigureSharpnessForWeapon<Lance>(modelBuilder);
            ConfigureSharpnessForWeapon<SwordAndShield>(modelBuilder);
            ConfigureSharpnessForWeapon<ChargeBlade>(modelBuilder);
            ConfigureSharpnessForWeapon<SwitchAxe>(modelBuilder);
            ConfigureSharpnessForWeapon<InsectGlaive>(modelBuilder);
        }

        private void ConfigureSharpnessForWeapon<T>(ModelBuilder modelBuilder) where T : BaseWeapon
        {
            // check if the weapon type has a sharpness property
            var sharpnessProperty = typeof(T).GetProperty("Sharpness");
            if (sharpnessProperty != null)
            {
                modelBuilder.Entity<T>()
                    .OwnsOne(typeof(Sharpness), "Sharpness", sharpness =>
                    {
                        sharpness.Property("Red").HasColumnName("SharpnessRed");
                        sharpness.Property("Orange").HasColumnName("SharpnessOrange");
                        sharpness.Property("Yellow").HasColumnName("SharpnessYellow");
                        sharpness.Property("Green").HasColumnName("SharpnessGreen");
                        sharpness.Property("Blue").HasColumnName("SharpnessBlue");
                        sharpness.Property("White").HasColumnName("SharpnessWhite");
                        sharpness.Property("Purple").HasColumnName("SharpnessPurple");
                    });
            }
        }

        private void ConfigureBowCoatings(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<List<CoatingType>, string[]>(
                v => v.Select(e => e.ToString()).ToArray(),
                v => v.Select(e => Enum.Parse<CoatingType>(e)).ToList()
            );

            var comparer = new ValueComparer<List<CoatingType>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()
            );

            modelBuilder.Entity<Bow>()
                .Property(b => b.Coatings)
                .HasConversion(converter)
                .Metadata.SetValueComparer(comparer);
        }
    }
}
