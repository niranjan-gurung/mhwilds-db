namespace mhwilds_api.DTO.Response
{
    public class GetCharmResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<GetCharmRankResponse> Ranks { get; set; } = [];
    }

    public class GetCharmRankResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Level { get; set; }
        public int Rarity { get; set; }
        public List<GetSkillRankResponse> Skills { get; set; } = [];
    }
}
