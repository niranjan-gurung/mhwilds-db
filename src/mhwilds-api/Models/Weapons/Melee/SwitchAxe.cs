using mhwilds_api.Models.Weapons.Common;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class SwitchAxe : BaseWeapon
    {
        public SwitchAxe()
        {
            WeaponType = WeaponType.SwitchAxe;
        }
        public string Phial { get; set; }
        public Sharpness Sharpness { get; set; }
    }
}
