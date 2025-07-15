using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Melee
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
