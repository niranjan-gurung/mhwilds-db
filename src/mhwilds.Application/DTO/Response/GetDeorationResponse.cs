namespace mhwilds.Application.DTO.Response
{
    public class GetDecorationResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public int Rarity { get; set; }
        public int Slot { get; set; }
        public List<GetSkillRankResponse> Skills { get; set; } = [];
    }
}
