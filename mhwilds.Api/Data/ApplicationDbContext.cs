//using mhwilds_api.Models;
//using Microsoft.EntityFrameworkCore;

//namespace mhwilds_api.Services
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//        : base(options)
//        {
//        }

//        public DbSet<Armour> Armours { get; set; }
//        public DbSet<Skill> Skills { get; set; }
//        public DbSet<SkillRank> SkillRanks { get; set; }
//        public DbSet<Charm> Charms { get; set; }
//        public DbSet<CharmRank> CharmRanks { get; set; }
//        public DbSet<Decoration> Decorations { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            /* relationships */

//            /// skill -> skillRanks
//            /// 1 - many
//            modelBuilder.Entity<Skill>()
//                .HasMany(s => s.Ranks)
//                .WithOne(sr => sr.Skill)
//                .HasForeignKey(sr => sr.SkillId)
//                .OnDelete(DeleteBehavior.Cascade);

//            /// armour -> resistances
//            /// 1 - 1
//            modelBuilder.Entity<Armour>()
//                .HasOne(a => a.Resistances)
//                .WithOne(r => r.Armour)
//                .HasForeignKey<Resistances>(r => r.ArmourId)
//                .OnDelete(DeleteBehavior.Cascade);

//            /// armour -> slots
//            /// 1 - many
//            modelBuilder.Entity<Armour>()
//                .HasMany(s => s.Slots)
//                .WithOne(a => a.Armour)
//                .HasForeignKey(a => a.ArmourId)
//                .OnDelete(DeleteBehavior.Cascade);

//            /// armour -> skillRanks
//            /// many - many            
//            modelBuilder.Entity<Armour>()
//                .HasMany(a => a.Skills)
//                .WithMany(sr => sr.Armours);

//            /// charm -> charmRanks
//            /// 1 - many
//            modelBuilder.Entity<Charm>()
//                .HasMany(c => c.Ranks)
//                .WithOne(cr => cr.Charm)
//                .HasForeignKey(cr => cr.CharmId)
//                .OnDelete(DeleteBehavior.Cascade);

//            /// charmRanks -> skillRanks
//            /// many - many
//            modelBuilder.Entity<CharmRank>()
//                .HasMany(cr => cr.Skills)
//                .WithMany(sr => sr.Charms);

//            /// decorations -> skillRanks
//            /// many - many            
//            modelBuilder.Entity<Decoration>()
//                .HasMany(a => a.Skills)
//                .WithMany(sr => sr.Decorations);
//        }
//    }
//}
