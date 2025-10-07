using System.ComponentModel.DataAnnotations;

namespace mhwilds.Application.DTO.Request
{
    public record SkillRequest
    {
        [Required]
        public string Name { get; init; } = string.Empty;
        [Required]
        public string Type { get; init; } = string.Empty;
        [Required]
        public string Description { get; init; } = string.Empty;
        public List<CreateSkillRankRequest> Ranks { get; init; } = [];
    }

    public record CreateSkillRankRequest
    {
        [Required]
        public int Level { get; init; }
        [Required]
        public string Description { get; init; } = string.Empty;
    }
}
