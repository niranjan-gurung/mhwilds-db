using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class HuntingHorn : BaseWeapon
    {
        public HuntingHorn()
        {
            WeaponType = WeaponType.HuntingHorn;
        }
        public Sharpness Sharpness { get; set; }
    }
}
