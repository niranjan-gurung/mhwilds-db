using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class DualBlades : BaseWeapon
    {
        public DualBlades()
        {
            WeaponType = WeaponType.DualBlades;
        }
        public Sharpness Sharpness { get; set; }
    }
}
