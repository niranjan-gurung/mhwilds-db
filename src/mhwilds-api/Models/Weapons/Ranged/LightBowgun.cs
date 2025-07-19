using mhwilds_api.Models.EnumTypes;
using mhwilds_api.Models.Weapons.Common;

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
