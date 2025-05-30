using mhwilds_api.DTO.Response;

namespace mhwilds_api.DTO.Request
{
    public class CreateArmourRequest
    {
        public required string Name { get; set; }
        public string? Slug { get; set; }
        public required string Type { get; set; }
        public required string Rank { get; set; }
        public required int Rarity { get; set; }
        public required int Defense { get; set; }

        public required CreateResistancesRequest Resistances { get; set; }
        public List<CreateSlotRequest> Slots { get; set; } = new();
        public List<SkillRankResponse> Skills { get; set; } = new();
    }
}
