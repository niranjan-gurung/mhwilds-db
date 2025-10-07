using mhwilds.Application.DTO.Response;
using System.ComponentModel.DataAnnotations;

namespace mhwilds.Application.DTO.Request
{   public record ArmourRequest
    {
        [Required] 
        public string Name { get; init; } = string.Empty;
        [Required] 
        public string Type { get; init; } = string.Empty;
        [Required] 
        public string Rank { get; init; } = string.Empty;
        [Required, Range(1, 8)] 
        public int Rarity { get; init; }
        [Required] 
        public int Defense { get; init; }
        [Required]
        public ResistancesRequest Resistances { get; init; } = null!;
        public List<int> Slots { get; init; } = [];
        public List<SkillRankResponse> Skills { get; init; } = [];
    }
}
