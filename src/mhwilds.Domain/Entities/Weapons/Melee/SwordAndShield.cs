using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class SwordAndShield : BaseWeapon
    {
        public SwordAndShield()
        {
            WeaponType = WeaponType.SwordAndShield;
        }
        public Sharpness Sharpness { get; set; }
    }
}
