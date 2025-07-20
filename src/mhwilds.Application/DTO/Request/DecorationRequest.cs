using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.DTO.Request
{
    public class DecorationRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }
        public required int Rarity { get; set; }
        public required int Slot { get; set; }
        public required List<GetSkillRankResponse> Skills { get; set; } = [];
    }
}
