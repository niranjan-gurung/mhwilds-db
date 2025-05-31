using Newtonsoft.Json;

namespace mhwilds_api.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public List<SkillRank> Ranks { get; set; } = [];
    }

    public class SkillRank
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string? Description { get; set; }
        public int SkillId { get; set; }
        public Skill? Skill { get; set; }
        public List<Armour> Armours { get; set; } = [];
        public List<CharmRank> Charms { get; set; } = [];
    }
}
