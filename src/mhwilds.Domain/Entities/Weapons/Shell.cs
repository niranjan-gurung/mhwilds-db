using mhwilds.Domain.EnumTypes;

namespace mhwilds.Domain.Entities.Weapons
{
    // Shell type specific for gunlance
    public class Shell
    {
        public ShellType Type { get; set; }
        public int Power { get; set; }
    }
}
