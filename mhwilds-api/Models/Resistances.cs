using Newtonsoft.Json;

namespace mhwilds_api.Models
{
    public class Resistances
    {
        [JsonIgnore]
        public int Id { get; set; }
        public required string Fire { get; set; }
        public required string Water { get; set; }
        public required string Ice { get; set; }
        public required string Thunder { get; set; }
        public required string Dragon { get; set; }
        [JsonIgnore]
        public int ArmourId { get; set; }
        [JsonIgnore]
        public Armour? Armour { get; set; }
    }
}
