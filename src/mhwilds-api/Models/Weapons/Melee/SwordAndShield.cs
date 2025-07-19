using mhwilds_api.Models.EnumTypes;
using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
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
