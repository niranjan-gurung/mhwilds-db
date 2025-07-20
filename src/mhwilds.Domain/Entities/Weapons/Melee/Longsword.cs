using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class Longsword : BaseWeapon
    {
        public Longsword()
        {
            WeaponType = WeaponType.Longsword;
        }
        public Sharpness Sharpness { get; set; }
    }
}
