using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class InsectGlaive : BaseWeapon
    {
        public InsectGlaive()
        {
            WeaponType = WeaponType.InsectGlaive;
        }
        public int KinsectLevel { get; set; }
        public Sharpness Sharpness { get; set; }
    }
}
