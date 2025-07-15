using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class HuntingHorn : BaseWeapon
    {
        public HuntingHorn()
        {
            WeaponType = WeaponType.HuntingHorn;
        }
        public Sharpness Sharpness { get; set; }
    }
}
