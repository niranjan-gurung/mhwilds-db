using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Ranged
{
    public class HeavyBowgun : BaseWeapon
    {
        public HeavyBowgun()
        {
            WeaponType = WeaponType.HeavyBowgun;
        }
        public List<Ammo> Ammo { get; set; }
    }
}
