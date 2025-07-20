using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Ranged
{
    public class HeavyBowgun : BaseWeapon
    {
        public HeavyBowgun()
        {
            WeaponType = WeaponType.HeavyBowgun;
        }
        public List<Ammo> Ammo { get; set; }
    }
}
