using Newtonsoft.Json;

namespace mhwilds_api.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
        public List<SkillRank> Ranks { get; set; } = new();
    }

    public class SkillRank
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public required string Description { get; set; }
        public int SkillId { get; set; }
        public Skill? Skill { get; set; }
        public List<Armour> Armours { get; set; } = new();
        public List<CharmRank> Charms { get; set; } = new();
    }
}
