using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class Hammer : BaseWeapon
    {
        public Hammer()
        {
            WeaponType = WeaponType.Hammer;
        }
        public Sharpness Sharpness { get; set; }
    }
}
