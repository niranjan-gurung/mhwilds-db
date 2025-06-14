using mhwilds_api.DTO.Response;
using mhwilds_api.Models;

namespace mhwilds_api.DTO.Request
{
    public class CreateDecorationRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }
        public required int Rarity { get; set; }
        public required int Slot { get; set; }
        public required List<GetSkillRankResponse> Skills { get; set; } = [];
    }
}
