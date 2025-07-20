using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.DTO.Request
{
    public class CharmRequest
    {
        public required string Name { get; set; }
        public required List<CreateCharmRankRequest> Ranks { get; set; } = [];
    }

    public class CreateCharmRankRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Level { get; set; }
        public int Rarity { get; set; }
        public required List<GetSkillRankResponse> Skills { get; set; } = [];
    }
}
