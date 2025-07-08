using mhwilds_api.Models.Weapons.Common;

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
