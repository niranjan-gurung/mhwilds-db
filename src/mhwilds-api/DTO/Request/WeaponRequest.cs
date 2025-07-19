using JsonSubTypes;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models.EnumTypes;
using mhwilds_api.Models.Weapons.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace mhwilds_api.DTO.Request
{
    [JsonConverter(typeof(JsonSubtypes), "WeaponType")]
    [JsonSubtypes.KnownSubType(typeof(CreateGreatswordRequest), WeaponType.Greatsword)]
    [JsonSubtypes.KnownSubType(typeof(CreateLongswordRequest), WeaponType.Longsword)]
    [JsonSubtypes.KnownSubType(typeof(CreateDualBladesRequest), WeaponType.DualBlades)]
    [JsonSubtypes.KnownSubType(typeof(CreateSwordAndShieldRequest), WeaponType.SwordAndShield)]
    [JsonSubtypes.KnownSubType(typeof(CreateHammerRequest), WeaponType.Hammer)]
    [JsonSubtypes.KnownSubType(typeof(CreateHuntingHornRequest), WeaponType.HuntingHorn)]
    [JsonSubtypes.KnownSubType(typeof(CreateGunlanceRequest), WeaponType.Gunlance)]
    [JsonSubtypes.KnownSubType(typeof(CreateLanceRequest), WeaponType.Lance)]
    [JsonSubtypes.KnownSubType(typeof(CreateChargeBladesRequest), WeaponType.ChargeBlade)]
    [JsonSubtypes.KnownSubType(typeof(CreateSwitchAxeRequest), WeaponType.SwitchAxe)]
    [JsonSubtypes.KnownSubType(typeof(CreateInsectGlaiveRequest), WeaponType.InsectGlaive)]
    [JsonSubtypes.KnownSubType(typeof(CreateLightBowgunRequest), WeaponType.LightBowgun)]
    [JsonSubtypes.KnownSubType(typeof(CreateHeavyBowgunRequest), WeaponType.HeavyBowgun)]
    [JsonSubtypes.KnownSubType(typeof(CreateBowRequest), WeaponType.Bow)]
    public abstract class WeaponRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required WeaponType WeaponType { get; set; }
        public required int Defense { get; set; }
        [Range(1, 8)]
        public required int Rarity { get; set; }
        public List<int>? Slot { get; set; }
        [Range(-100, 100)]
        public required int Affinity { get; set; }
        public required Damage Damage { get; set; }
        public Element? Element { get; set; }
        public List<GetSkillRankResponse>? Skills { get; set; }
    }

    #region Melee Weapons
    public class CreateGreatswordRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateLongswordRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateDualBladesRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateSwordAndShieldRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateHammerRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateHuntingHornRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateGunlanceRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
        public CreateShellRequest? Shell { get; set; }
    }

    public class CreateLanceRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateChargeBladesRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }

        [StringLength(12)]
        public string? Phial { get; set; }
    }

    public class CreateSwitchAxeRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
        [StringLength(12)]
        public string? Phial { get; set; }
    }

    public class CreateInsectGlaiveRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
        [Range(1, 10)]
        public int KinsectLevel { get; set; }
    }
    #endregion

    #region Ranged Weapons
    public class CreateLightBowgunRequest : WeaponRequest
    {
        public List<CreateAmmoRequest>? Ammo { get; set; }

        [StringLength(20)]
        public string? SpecialAmmo { get; set; }
    }

    public class CreateHeavyBowgunRequest : WeaponRequest
    {
        public List<CreateAmmoRequest>? Ammo { get; set; }
    }

    public class CreateBowRequest : WeaponRequest
    {
        public List<string>? Coatings { get; set; }
    }
    #endregion

    #region DTO Helpers
    public class CreateDamageRequest
    {
        [Required]
        public int Raw { get; set; }
        [Required]
        public int Display { get; set; }
    }

    public class CreateElementRequest
    {
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public CreateDamageRequest Damage { get; set; } = new();
    }

    public class CreateSharpnessRequest
    {
        public int Red { get; set; }
        public int Orange { get; set; }
        public int Yellow { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int White { get; set; }
        public int Purple { get; set; }
    }

    public class CreateShellRequest
    {
        [Required]
        public string Type { get; set; } = string.Empty;
        [Range(1, 3)]
        public int Power { get; set; }
    }

    public class CreateAmmoRequest
    {
        [Required]
        public string Type { get; set; } = string.Empty;
        [Range(1, 3)]
        public int Level { get; set; }
        [Range(1, 99)]
        public int Capacity { get; set; }
        public bool? Rapid { get; set; }
    }
    #endregion
}
