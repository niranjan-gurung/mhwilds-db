using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;

namespace mhwilds.Domain.Entities.Weapons.Ranged
{
    public class Bow : BaseWeapon
    {
        public Bow()
        {
            WeaponType = WeaponType.Bow;
        }
        public List<CoatingType> Coatings { get; set; } = [];
    }
}
