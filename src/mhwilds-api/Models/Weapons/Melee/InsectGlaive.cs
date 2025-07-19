using mhwilds_api.Models.EnumTypes;
using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class InsectGlaive : BaseWeapon
    {
        public InsectGlaive()
        {
            WeaponType = WeaponType.InsectGlaive;
        }
        public int KinsectLevel { get; set; }
        public Sharpness Sharpness { get; set; }
    }
}
