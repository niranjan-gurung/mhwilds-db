namespace mhwilds_api.DTO.Response
{
    public class GetSkillResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }

        public List<SkillRankResponse>? Ranks { get; set; }
    }

    public class SkillRankResponse
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public required string Description { get; set; }
        public int SkillId { get; set; }
        public required string SkillName { get; set; }
    }
}
