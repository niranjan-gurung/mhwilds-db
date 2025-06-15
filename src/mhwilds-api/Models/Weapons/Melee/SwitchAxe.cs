using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class SwitchAxe : BaseWeapon
    {
        public override WeaponType WeaponType => WeaponType.SwitchAxe;
        public Sharpness Sharpness { get; set; }
    }
}
