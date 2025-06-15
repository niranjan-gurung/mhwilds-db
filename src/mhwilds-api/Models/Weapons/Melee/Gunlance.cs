using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class Gunlance : BaseWeapon
    {
        public override WeaponType WeaponType => WeaponType.Gunlance;
        public Sharpness Sharpness { get; set; }
    }
}
