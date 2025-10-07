using mhwilds.Application.DTO.Response;
using System.ComponentModel.DataAnnotations;

namespace mhwilds.Application.DTO.Request
{
    public record CharmRequest
    {
        [Required]
        public string Name { get; init; } = string.Empty;
        public List<CreateCharmRankRequest> Ranks { get; init; } = [];
    }

    public record CreateCharmRankRequest
    {
        [Required]
        public string Name { get; init; } = string.Empty;
        [Required]
        public string Description { get; init; } = string.Empty;
        public int Level { get; init; }
        [Required, Range(1, 8)]
        public int Rarity { get; init; }
        public List<SkillRankResponse> Skills { get; init; } = [];
    }
}
