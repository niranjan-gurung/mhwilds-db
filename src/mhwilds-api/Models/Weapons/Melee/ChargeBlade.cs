using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class ChargeBlade : BaseWeapon
    {
        public ChargeBlade()
        {
            WeaponType = WeaponType.ChargeBlade;
        }
        public PhialType Phial {  get; set; }
        public Sharpness Sharpness { get; set; }
    }
}
