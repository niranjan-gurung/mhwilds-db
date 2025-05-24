using Newtonsoft.Json;

namespace mhwilds_api.Models
{
    public class Slot
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int Level { get; set; }
        [JsonIgnore]
        public int ArmourId { get; set; }
        [JsonIgnore]
        public Armour? Armour { get; set; }
    }
}
