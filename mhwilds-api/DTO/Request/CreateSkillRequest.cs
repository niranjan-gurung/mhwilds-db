namespace mhwilds_api.DTO.Request
{
    public class CreateSkillRequest
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }

        public List<CreateSkillRankRequest>? Ranks { get; set; }
    }

    public class CreateSkillRankRequest
    {
        public int Level { get; set; }
        public required string Description { get; set; }
    }
}
