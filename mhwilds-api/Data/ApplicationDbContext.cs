using mhwilds_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* relationships */

            /* 1 - many */
            modelBuilder.Entity<Skill>()
                .HasMany(s => s.Ranks)
                .WithOne(sr => sr.Skill)
                .HasForeignKey(sr => sr.SkillId)
                .OnDelete(DeleteBehavior.Cascade);

            /* 1 - 1 */
            modelBuilder.Entity<Armour>()
                .HasOne(r => r.Resistances)
                .WithOne(a => a.Armour)
                .HasForeignKey<Resistances>(r => r.ArmourId)
                .OnDelete(DeleteBehavior.Cascade);

            /* 1 - many */
            modelBuilder.Entity<Armour>()
                .HasMany(s => s.Slots)
                .WithOne(a => a.Armour)
                .HasForeignKey(a => a.ArmourId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
