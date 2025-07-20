using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class Greatsword : BaseWeapon
    {
        public Greatsword()
        {
            WeaponType = WeaponType.Greatsword;
        }
        public Sharpness Sharpness { get; set; }
    }
}
