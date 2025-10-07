namespace mhwilds.Application.DTO.Response
{
    public record CharmResponse
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public List<CharmRankResponse> Ranks { get; init; } = [];
    }

    public record CharmRankResponse
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public int Level { get; init; }
        public int Rarity { get; init; }
        public List<SkillRankResponse> Skills { get; init; } = [];
    }
}
