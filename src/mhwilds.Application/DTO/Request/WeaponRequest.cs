using JsonSubTypes;
using mhwilds.Application.DTO.Response;
using mhwilds.Domain.EnumTypes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace mhwilds.Application.DTO.Request
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
        [Required]
        public string Name { get; init; } = string.Empty;
        [Required]
        public string Description { get; init; } = string.Empty;
        [Required]
        public WeaponType WeaponType { get; init; }
        [Required]
        public int Defense { get; init; }
        [Required, Range(1, 8)]
        public int Rarity { get; init; }
        public List<int>? Slot { get; init; }
        [Required, Range(-100, 100)]
        public int Affinity { get; init; }
        [Required]
        public CreateDamageRequest Damage { get; init; } = null!;
        public CreateElementRequest? Element { get; init; }
        public List<SkillRankResponse>? Skills { get; init; }
    }

    #region Melee Weapons
    public class CreateGreatswordRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
    }

    public class CreateLongswordRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
    }

    public class CreateDualBladesRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
    }

    public class CreateSwordAndShieldRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
    }

    public class CreateHammerRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
    }

    public class CreateHuntingHornRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
    }

    public class CreateGunlanceRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
        public CreateShellRequest? Shell { get; init; }
    }

    public class CreateLanceRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
    }

    public class CreateChargeBladesRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
        public CreatePhialRequest? Phial { get; init; }
    }

    public class CreateSwitchAxeRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
        public CreatePhialRequest? Phial { get; init; }
    }

    public class CreateInsectGlaiveRequest : WeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; init; }
        [Required, Range(1, 10)]
        public int KinsectLevel { get; init; }
    }
    #endregion

    #region Ranged Weapons
    public class CreateLightBowgunRequest : WeaponRequest
    {
        public List<CreateAmmoRequest>? Ammo { get; init; }

        [StringLength(20)]
        public string? SpecialAmmo { get; init; }
    }

    public class CreateHeavyBowgunRequest : WeaponRequest
    {
        public List<CreateAmmoRequest>? Ammo { get; init; }
    }

    public class CreateBowRequest : WeaponRequest
    {
        public List<string>? Coatings { get; init; }
    }
    #endregion

    #region DTO Helpers
    public class CreateDamageRequest
    {
        [Required]
        public int Raw { get; init; }
        [Required]
        public int Display { get; init; }
    }

    public class CreateElementRequest
    {
        public string? Type { get; init; }
        public CreateDamageRequest? Damage { get; init; }
    }

    public class CreateSharpnessRequest
    {
        [Required] 
        public int Red { get; init; }
        [Required] 
        public int Orange { get; init; }
        [Required] 
        public int Yellow { get; init; }
        [Required] 
        public int Green { get; init; }
        [Required] 
        public int Blue { get; init; }
        [Required] 
        public int White { get; init; }
        [Required] 
        public int Purple { get; init; }
    }

    public class CreateShellRequest
    {
        [Required]
        public string Type { get; init; } = string.Empty;
        [Required, Range(1, 3)]
        public int Power { get; init; }
    }

    public class CreatePhialRequest
    {
        public string? Type { get; init; }
        public CreateDamageRequest? Damage { get; init; }
    }

    public class CreateAmmoRequest
    {
        [Required]
        public string Type { get; init; } = string.Empty;
        [Range(1, 3)]
        public int Level { get; init; }
        [Range(1, 99)]
        public int Capacity { get; init; }
        public bool? Rapid { get; init; }
    }
    #endregion
}
