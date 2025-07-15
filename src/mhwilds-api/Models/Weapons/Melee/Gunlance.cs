using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class Gunlance : BaseWeapon
    {
        public Gunlance()
        {
            WeaponType = WeaponType.Gunlance;
        }
        public Sharpness Sharpness { get; set; }
    }
}
