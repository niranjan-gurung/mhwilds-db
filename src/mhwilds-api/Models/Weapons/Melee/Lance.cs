using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class Lance : BaseWeapon
    {
        public Lance()
        {
            WeaponType = WeaponType.Lance;
        }
        public Sharpness Sharpness { get; set; }
    }
}
