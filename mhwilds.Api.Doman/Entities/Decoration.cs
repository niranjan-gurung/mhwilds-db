namespace mhwilds.Api.Doman.Entities
{
    public class Decoration
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int Rarity { get; set; }
        public int Slot { get; set; }
        public List<SkillRank> Skills { get; set; } = [];
    }
}
