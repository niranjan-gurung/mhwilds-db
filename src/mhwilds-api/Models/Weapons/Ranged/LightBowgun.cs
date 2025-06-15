using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Ranged
{
    public class LightBowgun : BaseWeapon
    {
        public override WeaponType WeaponType => WeaponType.LightBowgun;
        public Ammo Ammo { get; set; }
        public string SpecialAmmo { get; set; }
    }
}
