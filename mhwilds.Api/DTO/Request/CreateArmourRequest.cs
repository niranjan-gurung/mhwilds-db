using mhwilds_api.DTO.Response;
using System.ComponentModel.DataAnnotations;

namespace mhwilds_api.DTO.Request
{
    public class CreateArmourRequest
    {
        public required string Name { get; set; }
        public string? Slug { get; set; }
        public required string Type { get; set; }
        public required string Rank { get; set; }
        [Range(1, 8)]
        public required int Rarity { get; set; }
        public required int Defense { get; set; }
        public required CreateResistancesRequest Resistances { get; set; }
        public required List<CreateSlotRequest> Slots { get; set; } = [];
        public required List<GetSkillRankResponse> Skills { get; set; } = [];
    }
}
