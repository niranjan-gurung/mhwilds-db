using System.ComponentModel.DataAnnotations;

namespace mhwilds.Application.DTO.Request
{
    public record ResistancesRequest
    {
        [Required]
        public int Fire { get; init; }
        [Required]
        public int Water { get; init; }
        [Required]
        public int Ice { get; init; }
        [Required]
        public int Thunder { get; init; }
        [Required]
        public int Dragon { get; init; }
    }
}
