using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;
using Newtonsoft.Json;

namespace mhwilds.Domain.Entities.Weapons
{
    public abstract class BaseWeapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual WeaponType WeaponType { get; set; }
        public int Defense { get; set; }
        public int Rarity { get; set; }
        public List<int>? Slot { get; set; }
        public int Affinity { get; set; }
        public Damage Damage { get; set; }
        public Element? Element { get; set; }
        public List<SkillRank>? Skills { get; set; }
        [JsonIgnore]
        public string WeaponTypeDisplay => WeaponType.ToDisplayString();
        [JsonIgnore]
        public bool IsRangedWeapon => WeaponType.IsRangedWeapon();
        [JsonIgnore]
        public bool IsMeleeWeapon => WeaponType.IsMeleeWeapon();
    }
}
