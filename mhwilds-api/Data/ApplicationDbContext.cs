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

            modelBuilder.Entity<Skill>()
                .HasMany(s => s.Ranks)
                .WithOne(sr => sr.Skill)
                .HasForeignKey(sr => sr.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
