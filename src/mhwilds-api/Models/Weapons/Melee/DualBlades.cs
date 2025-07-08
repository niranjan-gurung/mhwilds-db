using mhwilds_api.Models.Weapons.Common;

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
