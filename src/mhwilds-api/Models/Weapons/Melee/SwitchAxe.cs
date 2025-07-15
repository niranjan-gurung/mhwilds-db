using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class SwitchAxe : BaseWeapon
    {
        public SwitchAxe()
        {
            WeaponType = WeaponType.SwitchAxe;
        }
        public PhialType Phial { get; set; }
        public Sharpness Sharpness { get; set; }
    }
}
