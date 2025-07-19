using mhwilds_api.Models.EnumTypes;
using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class Gunlance : BaseWeapon
    {
        public Gunlance()
        {
            WeaponType = WeaponType.Gunlance;
        }
        public Shell Shell { get; set; }
        public Sharpness Sharpness { get; set; }
    }
}
