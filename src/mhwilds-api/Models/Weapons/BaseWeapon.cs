using Newtonsoft.Json;
using JsonSubTypes;
using mhwilds_api.Models.Weapons.Ranged;
using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Melee;

namespace mhwilds_api.Models.Weapons
{
    [JsonConverter(typeof(JsonSubtypes), "weaponType")]
    [JsonSubtypes.KnownSubType(typeof(Greatsword), WeaponType.Greatsword)]
    [JsonSubtypes.KnownSubType(typeof(Longsword), WeaponType.Longsword)]
    [JsonSubtypes.KnownSubType(typeof(SwordAndShield), WeaponType.SwordAndShield)]
    [JsonSubtypes.KnownSubType(typeof(DualBlades), WeaponType.DualBlades)]
    [JsonSubtypes.KnownSubType(typeof(Hammer), WeaponType.Hammer)]
    [JsonSubtypes.KnownSubType(typeof(HuntingHorn), WeaponType.HuntingHorn)]
    [JsonSubtypes.KnownSubType(typeof(Gunlance), WeaponType.Gunlance)]
    [JsonSubtypes.KnownSubType(typeof(Lance), WeaponType.Lance)]
    [JsonSubtypes.KnownSubType(typeof(ChargeBlade), WeaponType.ChargeBlade)]
    [JsonSubtypes.KnownSubType(typeof(SwitchAxe), WeaponType.SwitchAxe)]
    [JsonSubtypes.KnownSubType(typeof(InsectGlaive), WeaponType.InsectGlaive)]
    [JsonSubtypes.KnownSubType(typeof(LightBowgun), WeaponType.LightBowgun)]
    [JsonSubtypes.KnownSubType(typeof(HeavyBowgun), WeaponType.HeavyBowgun)]
    [JsonSubtypes.KnownSubType(typeof(Bow), WeaponType.Bow)]
    public abstract class BaseWeapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public abstract WeaponType WeaponType { get; }
        public int Defense { get; set; }
        public int Rarity { get; set; }
        public List<int>? Slot { get; set; }
        public int Affinity { get; set; }
        public Damage Damage { get; set; }
        public Element? Element { get; set; }
        public int? Elderseal { get; set; }
        public List<SkillRank>? Skills { get; set; }
        [JsonIgnore]
        public string WeaponTypeDisplay => WeaponType.ToDisplayString();
        [JsonIgnore]
        public bool IsRangedWeapon => WeaponType.IsRangedWeapon();
        [JsonIgnore]
        public bool IsMeleeWeapon => WeaponType.IsMeleeWeapon();
    }
}
