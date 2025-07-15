using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Melee
{
    public class Greatsword : BaseWeapon
    {
        public Greatsword()
        {
            WeaponType = WeaponType.Greatsword;
        }
        public Sharpness Sharpness { get; set; }
    }
}
