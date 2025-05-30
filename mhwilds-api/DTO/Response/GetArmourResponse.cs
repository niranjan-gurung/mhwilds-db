namespace mhwilds_api.DTO.Response
{
    public class GetArmourResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Slug { get; set; }
        public required string Type { get; set; }
        public required string Rank { get; set; }
        public required int Rarity { get; set; }
        public required int Defense { get; set; }

        public required GetResistancesResponse Resistances { get; set; }
        public List<GetSlotResponse> Slots { get; set; } = new();
        public List<SkillRankResponse> Skills { get; set; } = new();
    }
}
