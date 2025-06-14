namespace mhwilds_api.Models
{
    public class Armour
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Type { get; set; }
        public string? Rank { get; set; }
        public int Rarity { get; set; }
        public int Defense { get; set; }
        public Resistances? Resistances { get; set; }
        public List<int> Slots { get; set; } = [];
        public List<SkillRank> Skills { get; set; } = [];
    }
}
