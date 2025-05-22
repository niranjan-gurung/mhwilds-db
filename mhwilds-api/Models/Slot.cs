using System.Text.Json.Serialization;

namespace mhwilds_api.Models
{
    public class Slot
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int ArmourId { get; set; }
        [JsonIgnore]
        public Armour? Armour { get; set; }
    }
}
