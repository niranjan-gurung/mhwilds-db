using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class SwordAndShield : BaseWeapon
    {
        public override WeaponType WeaponType => WeaponType.SwordAndShield;
        public Sharpness Sharpness { get; set; }
    }
}
