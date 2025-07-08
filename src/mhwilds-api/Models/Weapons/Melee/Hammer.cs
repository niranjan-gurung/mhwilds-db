using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class Hammer : BaseWeapon
    {
        public Hammer()
        {
            WeaponType = WeaponType.Hammer;
        }
        public Sharpness Sharpness { get; set; }
    }
}
