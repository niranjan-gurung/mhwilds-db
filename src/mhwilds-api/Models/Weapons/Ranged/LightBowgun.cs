using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Ranged
{
    public class LightBowgun : BaseWeapon
    {
        public LightBowgun()
        {
            WeaponType = WeaponType.LightBowgun;
        }
        public List<Ammo> Ammo { get; set; }
        public string SpecialAmmo { get; set; }
    }
}
