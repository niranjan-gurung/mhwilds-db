using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Ranged
{
    public class LightBowgun : BaseWeapon
    {
        public LightBowgun()
        {
            WeaponType = WeaponType.LightBowgun;
        }
        public Ammo Ammo { get; set; }
        public string SpecialAmmo { get; set; }
    }
}
