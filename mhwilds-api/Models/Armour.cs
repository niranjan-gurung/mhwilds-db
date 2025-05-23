namespace mhwilds_api.Models
{
    public class Armour
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Slug { get; set; }
        public required string Type { get; set; }
        public required string Rank { get; set; }
        public required int Rarity { get; set; }
        public required int Defense { get; set; }
        
        public required Resistances Resistances { get; set; }
        public List<Slot> Slots { get; set; } = new();

        public List<SkillRank> Skills { get; set; }
    }
}
