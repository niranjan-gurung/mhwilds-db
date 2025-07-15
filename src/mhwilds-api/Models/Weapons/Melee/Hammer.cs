using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class Hammer : BaseWeapon
    {
        public Hammer()
        {
            WeaponType = WeaponType.Hammer;
        }
        public Sharpness Sharpness { get; set; }
    }
}
