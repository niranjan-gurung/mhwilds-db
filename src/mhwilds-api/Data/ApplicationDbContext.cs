using mhwilds_api.Models;
using mhwilds_api.Models.Weapons;
using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Melee;
using mhwilds_api.Models.Weapons.Ranged;
using Microsoft.EntityFrameworkCore;

namespace mhwilds_api.Services
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
            // setup:
            // armours, skills/skillranks, charms, decorations
            ConfigureGeneralEntityModels(modelBuilder);
            // setup:
            // weapons specifics - base, ranged, melee
            ConfigureWeaponInheritance(modelBuilder);
        }

        private void ConfigureGeneralEntityModels(ModelBuilder modelBuilder)
        {
            #region Skills
            // skill -> skillRanks
            // 1 - many
            modelBuilder.Entity<Skill>()
                .HasMany(s => s.Ranks)
                .WithOne(sr => sr.Skill)
                .HasForeignKey(sr => sr.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Armours
            // armour / resistances relation
            // resistances is owned by armour
            // it is not a separate table
            modelBuilder.Entity<Armour>()
                .OwnsOne(a => a.Resistances);

            // armour -> skillRanks
            // many - many            
            modelBuilder.Entity<Armour>()
                .HasMany(a => a.Skills)
                .WithMany(sr => sr.Armours);
            #endregion

            #region Charms
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
            #endregion

            #region Decorations
            // decorations -> skillRanks
            // many - many            
            modelBuilder.Entity<Decoration>()
                .HasMany(a => a.Skills)
                .WithMany(sr => sr.Decorations);
            #endregion
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

            ConfigureRangedWeaponAmmo(modelBuilder);
            ConfigureMeleeWeaponSharpness(modelBuilder);
        }

        private void ConfigureRangedWeaponAmmo(ModelBuilder modelBuilder)
        {
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
    }
}
