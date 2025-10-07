using mhwilds.Application.DTO.Response;
using System.ComponentModel.DataAnnotations;

namespace mhwilds.Application.DTO.Request
{
    public record DecorationRequest
    {
        [Required]
        public string Name { get; init; } = string.Empty;
        [Required]
        public string Description { get; init; } = string.Empty;
        [Required]
        public string Type { get; init; } = string.Empty;
        [Required, Range(1, 8)]
        public int Rarity { get; init; }
        public int Slot { get; init; }
        public List<SkillRankResponse> Skills { get; init; } = [];
    }
}
