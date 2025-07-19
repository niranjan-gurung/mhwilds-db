using mhwilds_api.Models.EnumTypes;
using mhwilds_api.Models.Weapons.Common;

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
