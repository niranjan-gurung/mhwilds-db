using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class ChargeBlade : BaseWeapon
    {
        public override WeaponType WeaponType => WeaponType.ChargeBlade;
        public string Phial {  get; set; }
        public Sharpness Sharpness { get; set; }
    }
}
