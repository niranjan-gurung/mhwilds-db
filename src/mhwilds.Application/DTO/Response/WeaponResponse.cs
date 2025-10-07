using JsonSubTypes;
using mhwilds.Domain.EnumTypes;
using Newtonsoft.Json;

namespace mhwilds.Application.DTO.Response
{
    [JsonConverter(typeof(JsonSubtypes), "WeaponType")]
    [JsonSubtypes.KnownSubType(typeof(GetGreatswordResponse), WeaponType.Greatsword)]
    [JsonSubtypes.KnownSubType(typeof(GetLongswordResponse), WeaponType.Longsword)]
    [JsonSubtypes.KnownSubType(typeof(GetDualBladesResponse), WeaponType.DualBlades)]
    [JsonSubtypes.KnownSubType(typeof(GetSwordAndShieldResponse), WeaponType.SwordAndShield)]
    [JsonSubtypes.KnownSubType(typeof(GetHammerResponse), WeaponType.Hammer)]
    [JsonSubtypes.KnownSubType(typeof(GetHuntingHornResponse), WeaponType.HuntingHorn)]
    [JsonSubtypes.KnownSubType(typeof(GetGunlanceResponse), WeaponType.Gunlance)]
    [JsonSubtypes.KnownSubType(typeof(GetLanceResponse), WeaponType.Lance)]
    [JsonSubtypes.KnownSubType(typeof(GetChargeBladesResponse), WeaponType.ChargeBlade)]
    [JsonSubtypes.KnownSubType(typeof(GetSwitchAxeResponse), WeaponType.SwitchAxe)]
    [JsonSubtypes.KnownSubType(typeof(GetInsectGlaiveResponse), WeaponType.InsectGlaive)]
    [JsonSubtypes.KnownSubType(typeof(GetBowResponse), WeaponType.Bow)]
    [JsonSubtypes.KnownSubType(typeof(GetLightBowgunResponse), WeaponType.LightBowgun)]
    [JsonSubtypes.KnownSubType(typeof(GetHeavyBowgunResponse), WeaponType.HeavyBowgun)]
    public abstract class WeaponResponse
    {
        [JsonProperty(Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonProperty("type")]
        public WeaponType WeaponType { get; set; }
        public int Defense { get; set; }
        public int Rarity { get; set; }
        public List<int>? Slot { get; set; }
        public int Affinity { get; set; }
        public GetDamageResponse Damage { get; set; } = null!;
        public GetElementResponse? Element { get; set; }
        public List<SkillRankResponse>? Skills { get; set; }
    }

    #region Melee Weapons
    public class GetGreatswordResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
    }

    public class GetLongswordResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
    }

    public class GetDualBladesResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
    }

    public class GetSwordAndShieldResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
    }

    public class GetHammerResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
    }

    public class GetHuntingHornResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
    }

    public class GetGunlanceResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
        public GetShellResponse? Shell { get; set; }
    }

    public class GetLanceResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
    }

    public class GetChargeBladesResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
        public GetPhialResponse? Phial { get; set; }
    }

    public class GetSwitchAxeResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
        public GetPhialResponse? Phial { get; set; }
    }

    public class GetInsectGlaiveResponse : WeaponResponse
    {
        public GetSharpnessResponse? Sharpness { get; set; }
        public int KinsectLevel { get; set; }
    }
    #endregion

    #region Ranged Weapons
    public class GetBowResponse : WeaponResponse
    {
        public List<string> Coatings { get; set; } = [];
    }

    public class GetLightBowgunResponse : WeaponResponse
    {
        public List<GetLBGAmmoResponse> Ammo { get; set; } = [];
        public string? SpecialAmmo { get; set; }
    }

    public class GetHeavyBowgunResponse : WeaponResponse
    {
        public List<GetHBGAmmoResponse> Ammo { get; set; } = [];
    }
    #endregion

    #region DTO Helpers
    public class GetDamageResponse
    {
        public int Raw { get; set; }
        public int Display { get; set; }
    }

    public class GetElementResponse
    {
        public string Type { get; set; } = string.Empty;
        public GetDamageResponse? Damage { get; set; }

        // Newtonsoft.Json's convention based serialisation
        // syntax - ShouldSerialize{propertyName}()
        // these methods are invoked automatically,
        // checks property and appropriately returns the boolean result.
        // if both properties == false, element field will be an empty object {}
        public bool ShouldSerializeType()
        {
            return !string.IsNullOrEmpty(Type);
        }
        public bool ShouldSerializeDamage()
        {
            return Damage != null && (Damage.Raw != 0 || Damage.Display != 0);
        }
    }

    public class GetSharpnessResponse
    {
        public int Red { get; set; }
        public int Orange { get; set; }
        public int Yellow { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int White { get; set; }
        public int Purple { get; set; }
    }

    public class GetShellResponse
    {
        public string Type { get; set; } = string.Empty;
        public int Power { get; set; }
    }

    public class GetPhialResponse
    {
        public string? Type { get; set; }
        public GetDamageResponse? Damage { get; set; }
        public bool ShouldSerializeDamage()
        {
            return Damage != null && (Damage.Raw != 0 || Damage.Display != 0);
        }
    }

    public class GetLBGAmmoResponse
    {
        public string Type { get; set; } = string.Empty;
        public int Level { get; set; }
        public int Capacity { get; set; }
        public bool Rapid { get; set; }
    }
    
    public class GetHBGAmmoResponse
    {
        public string Type { get; set; } = string.Empty;
        public int Level { get; set; }
        public int Capacity { get; set; }
    }
    #endregion
}
