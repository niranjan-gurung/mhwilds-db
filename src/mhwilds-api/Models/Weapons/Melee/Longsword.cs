using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Melee
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
