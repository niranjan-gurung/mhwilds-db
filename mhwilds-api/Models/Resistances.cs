using Newtonsoft.Json;

namespace mhwilds_api.Models
{
    public class Resistances
    {
        public int Id { get; set; }
        public int Fire { get; set; }
        public int Water { get; set; }
        public int Ice { get; set; }
        public int Thunder { get; set; }
        public int Dragon { get; set; }
        public int ArmourId { get; set; }
        public Armour? Armour { get; set; }
    }
}
