using mhwilds_api.Models.EnumTypes;

namespace mhwilds_api.Models.Weapons.Common
{
    // Shell type specific for gunlance
    public class Shell
    {
        public ShellType Type { get; set; }
        public int Power { get; set; }
    }
}
