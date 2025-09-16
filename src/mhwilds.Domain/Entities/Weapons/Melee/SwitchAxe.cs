using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Melee
{
    public class SwitchAxe : BaseWeapon
    {
        public SwitchAxe()
        {
            WeaponType = WeaponType.SwitchAxe;
        }
        public Phial Phial { get; set; }
        public Sharpness Sharpness { get; set; }
    }
}
