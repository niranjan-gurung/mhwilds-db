namespace mhwilds_api.Models.Weapons.Ranged;
public class Bow : BaseWeapon
{
    public Bow()
    {
        WeaponType = WeaponType.Bow;
    }
    public List<string> Coatings { get; set; } = [];
}
