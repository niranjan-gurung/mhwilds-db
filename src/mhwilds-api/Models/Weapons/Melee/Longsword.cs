using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class Longsword : BaseWeapon
    {
        public Longsword()
        {
            WeaponType = WeaponType.Longsword;
        }
        public Sharpness Sharpness { get; set; }
    }
}
