using mhwilds_api.Models.Weapons.Types;

namespace mhwilds_api.Models.Weapons.Ranged
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
