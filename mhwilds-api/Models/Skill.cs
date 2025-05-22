using System.Text.Json.Serialization;

namespace mhwilds_api.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<SkillRank> Ranks { get; set; } = new();
    }

    public class SkillRank
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Description { get; set; } = null!;
        public int SkillId { get; set; }
        [JsonIgnore]
        public Skill? Skill { get; set; }
    }
}
