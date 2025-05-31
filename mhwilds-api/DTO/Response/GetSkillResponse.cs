namespace mhwilds_api.DTO.Response
{
    public class GetSkillResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public List<SkillRankResponse>? Ranks { get; set; }
    }

    public class SkillRankResponse
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string? Description { get; set; }
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
    }
}
