namespace mhwilds.Application.DTO.Response
{
    public record ArmourResponse
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Type { get; init; }
        public string? Rank { get; init; }
        public int Rarity { get; init; }
        public int Defense { get; init; }
        public ResistancesResponse? Resistances { get; init; }
        public List<int> Slots { get; init; } = [];
        public List<SkillRankResponse> Skills { get; init; } = [];
    }
}
