namespace mhwilds_api.Models.DTO
{
    public class ArmourResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Slug { get; set; }
        public required string Type { get; set; }
        public required string Rank { get; set; }
        public required int Rarity { get; set; }
        public required int Defense { get; set; }

        public required ResistancesResponse Resistances { get; set; }
        public List<SlotResponse> Slots { get; set; } = new();
        public List<SkillRankResponse> Skills { get; set; } = new();
    }
}
