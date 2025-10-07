namespace mhwilds.Application.DTO.Response
{
    public record DecorationResponse
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public string? Type { get; init; }
        public int Rarity { get; init; }
        public int Slot { get; init; }
        public List<SkillRankResponse> Skills { get; init; } = [];
    }
}
