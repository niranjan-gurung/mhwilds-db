using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Ranged
{
    public class HeavyBowgun : BaseWeapon
    {
        public override WeaponType WeaponType => WeaponType.HeavyBowgun;
        public Ammo Ammo { get; set; }
    }
}
