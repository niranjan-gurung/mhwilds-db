using Newtonsoft.Json;

namespace mhwilds_api.Models
{
    public class Charm
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<CharmRank> Ranks { get; set; } = new();
    }

    public class CharmRank
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Level { get; set; }
        public int Rarity { get; set; }
        public int CharmId { get; set; }
        public Charm? Charm { get; set; }
        public List<SkillRank> Skills { get; set; } = new();
    }
}
