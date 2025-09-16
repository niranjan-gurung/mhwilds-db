using mhwilds.Domain.Entities.Weapons.Common;
using mhwilds.Domain.EnumTypes;

namespace mhwilds.Domain.Entities.Weapons
{
    public class Phial
    {
        public PhialType Type { get; set; }
        public Damage? Damage { get; set; }
    }
}
