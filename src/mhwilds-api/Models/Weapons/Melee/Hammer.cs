using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class Hammer : BaseWeapon
    {
        public override WeaponType WeaponType => WeaponType.Hammer;
        public Sharpness Sharpness { get; set; }
    }
}
