using Newtonsoft.Json;

namespace mhwilds_api.Models
{
    public class Slot
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int ArmourId { get; set; }
        public Armour? Armour { get; set; }
    }
}
