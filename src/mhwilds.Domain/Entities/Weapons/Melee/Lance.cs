using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class Lance : BaseWeapon
    {
        public Lance()
        {
            WeaponType = WeaponType.Lance;
        }
        public Sharpness Sharpness { get; set; }
    }
}
