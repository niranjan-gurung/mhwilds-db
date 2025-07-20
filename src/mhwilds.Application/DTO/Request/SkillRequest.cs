namespace mhwilds.Application.DTO.Request
{
    public class SkillRequest
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
        public required List<CreateSkillRankRequest> Ranks { get; set; } = [];
    }

    public class CreateSkillRankRequest
    {
        public required int Level { get; set; }
        public required string Description { get; set; }
    }
}
