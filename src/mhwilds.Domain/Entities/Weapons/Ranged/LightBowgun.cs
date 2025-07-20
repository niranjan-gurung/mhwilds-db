using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Ranged
{
    public class LightBowgun : BaseWeapon
    {
        public LightBowgun()
        {
            WeaponType = WeaponType.LightBowgun;
        }
        public List<Ammo> Ammo { get; set; }
        public string SpecialAmmo { get; set; }
    }
}
