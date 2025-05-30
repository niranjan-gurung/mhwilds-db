namespace mhwilds_api.DTO.Response
{
    public class GetCharmResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<CharmRankResponse> Ranks { get; set; } = new();
    }

    public class CharmRankResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Level { get; set; }
        public int Rarity { get; set; }
        public int CharmId { get; set; }
        public List<SkillRankResponse> Skills { get; set; } = new();
    }
}
