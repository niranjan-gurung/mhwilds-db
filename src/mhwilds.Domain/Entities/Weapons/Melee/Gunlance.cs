using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class Gunlance : BaseWeapon
    {
        public Gunlance()
        {
            WeaponType = WeaponType.Gunlance;
        }
        public Shell Shell { get; set; }
        public Sharpness Sharpness { get; set; }
    }
}
