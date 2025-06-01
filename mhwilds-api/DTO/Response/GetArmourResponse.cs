namespace mhwilds_api.DTO.Response
{
    public class GetArmourResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public string? Type { get; set; }
        public string? Rank { get; set; }
        public int Rarity { get; set; }
        public int Defense { get; set; }
        public GetResistancesResponse? Resistances { get; set; }
        public List<GetSlotResponse> Slots { get; set; } = [];
        public List<GetSkillRankResponse> Skills { get; set; } = [];
    }
}
