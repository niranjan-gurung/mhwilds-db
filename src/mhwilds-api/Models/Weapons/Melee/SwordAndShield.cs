using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

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
