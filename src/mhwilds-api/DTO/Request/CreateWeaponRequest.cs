using JsonSubTypes;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models.Weapons;
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
    public abstract class CreateWeaponRequest
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
    public class CreateGreatswordRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateLongswordRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateDualBladesRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateSwordAndShieldRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateHammerRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateHuntingHornRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateGunlanceRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateLanceRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }

    public class CreateChargeBladesRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }

        [StringLength(12)]
        public string? Phial { get; set; }
    }

    public class CreateSwitchAxeRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
        [StringLength(12)]
        public string? Phial { get; set; }
    }

    public class CreateInsectGlaiveRequest : CreateWeaponRequest
    {
        public CreateSharpnessRequest? Sharpness { get; set; }
    }
    #endregion

    #region Ranged Weapons
    public class CreateLightBowgunRequest : CreateWeaponRequest
    {
        public List<CreateAmmoRequest>? Ammo { get; set; }

        [StringLength(50)]
        public string? SpecialAmmo { get; set; }
    }

    public class CreateHeavyBowgunRequest : CreateWeaponRequest
    {
        public List<CreateAmmoRequest>? Ammo { get; set; }
    }

    public class CreateBowRequest : CreateWeaponRequest
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

    public class CreateAmmoRequest
    {
        [Required]
        public string Type { get; set; } = string.Empty;

        [Range(1, 3)]
        public int Level { get; set; }

        [Range(1, 99)]
        public int Capacity { get; set; }

        public bool Rapid { get; set; }
    }
    #endregion
}
