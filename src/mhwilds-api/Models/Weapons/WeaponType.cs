using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace mhwilds_api.Models.Weapons;

/// 
/// represents all weapon types currently in the game
/// 
[JsonConverter(typeof(StringEnumConverter))]
public enum WeaponType
{
    Greatsword = 0,
    Longsword,
    [JsonProperty("dual_blades")]
    DualBlades,
    Hammer,
    [JsonProperty("hunting_horn")]
    HuntingHorn,
    Gunlance,
    Lance,
    [JsonProperty("sword_and_shield")]
    SwordAndShield,
    [JsonProperty("charge_blade")]
    ChargeBlade,
    [JsonProperty("switch_axe")]
    SwitchAxe,
    [JsonProperty("insect_glaive")]
    InsectGlaive,
    [JsonProperty("light_bowgun")]
    LightBowgun,
    [JsonProperty("heavy_bowgun")]
    HeavyBowgun,
    Bow
}

public static class WeaponTypeExtensions
{
    public static string ToDisplayString(this WeaponType weaponType)
    {
        return weaponType switch
        {
            WeaponType.DualBlades => "Dual Blades",
            WeaponType.HuntingHorn => "Hunting Horn",
            WeaponType.SwordAndShield => "Sword and Shield",
            WeaponType.ChargeBlade => "Charge Blade",
            WeaponType.SwitchAxe => "Switch Axe",
            WeaponType.InsectGlaive => "Insect Glaive",
            WeaponType.LightBowgun => "Light Bowgun",
            WeaponType.HeavyBowgun => "Heavy Bowgun",
            _ => weaponType.ToString()
        };
    }

    public static bool IsRangedWeapon(this WeaponType weaponType)
    {
        return weaponType is WeaponType.Bow or WeaponType.LightBowgun or WeaponType.HeavyBowgun;
    }

    public static bool IsMeleeWeapon(this WeaponType weaponType)
    {
        return !weaponType.IsRangedWeapon();
    }
}