using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class ChargeBlade : BaseWeapon
    {
        public ChargeBlade()
        {
            WeaponType = WeaponType.ChargeBlade;
        }
        public PhialType Phial {  get; set; }
        public Sharpness Sharpness { get; set; }
    }
}
