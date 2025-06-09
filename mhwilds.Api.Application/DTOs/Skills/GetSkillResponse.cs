namespace mhwilds.Api.Application.DTOs.Skills
{
    public class GetSkillResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public List<GetSkillRankResponse>? Ranks { get; set; }
    }

    public class GetSkillRankResponse
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string? Description { get; set; }
        public int SkillId { get; set; }
        public string? SkillName { get; set; }
    }
}
