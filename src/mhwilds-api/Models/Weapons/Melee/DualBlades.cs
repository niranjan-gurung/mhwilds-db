using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class DualBlades : BaseWeapon
    {
        public DualBlades()
        {
            WeaponType = WeaponType.DualBlades;
        }
        public Sharpness Sharpness { get; set; }
    }
}
