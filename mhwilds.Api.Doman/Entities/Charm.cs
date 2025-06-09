namespace mhwilds.Api.Doman.Entities
{
    public class Charm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<CharmRank> Ranks { get; set; } = [];
    }

    public class CharmRank
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Level { get; set; }
        public int Rarity { get; set; }
        public int CharmId { get; set; }
        public Charm? Charm { get; set; }
        public List<SkillRank> Skills { get; set; } = [];
    }
}
