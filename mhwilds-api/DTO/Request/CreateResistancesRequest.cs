namespace mhwilds_api.DTO.Request
{
    public class CreateResistancesRequest
    {
        public required string Fire { get; set; }
        public required string Water { get; set; }
        public required string Ice { get; set; }
        public required string Thunder { get; set; }
        public required string Dragon { get; set; }
    }
}
