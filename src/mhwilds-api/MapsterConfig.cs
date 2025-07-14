using Mapster;
using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models.Weapons;
using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Models.Weapons.Melee;
using mhwilds_api.Models.Weapons.Ranged;

namespace mhwilds_api
{
    public static class MapsterConfig
    {
        public static void Configure()
        {
            // configure individual weapon type mappings
            ConfigureWeaponEntityToResponseMappings();
            ConfigureWeaponRequestToEntityMappings();
            ConfigureCommonMappings();

            // compile all configurations
            TypeAdapterConfig.GlobalSettings.Compile();
        }

        private static void ConfigureWeaponEntityToResponseMappings()
        {
            // configure each weapon type to its specific response DTO
            TypeAdapterConfig<BaseWeapon, GetWeaponResponse>
                .NewConfig()
                .Include<Greatsword, GetGreatswordResponse>()
                .Include<Longsword, GetLongswordResponse>()
                .Include<DualBlades, GetDualBladesResponse>()
                .Include<SwordAndShield, GetSwordAndShieldResponse>()
                .Include<Hammer, GetHammerResponse>()
                .Include<HuntingHorn, GetHuntingHornResponse>()
                .Include<Gunlance, GetGunlanceResponse>()
                .Include<Lance, GetLanceResponse>()
                .Include<ChargeBlade, GetChargeBladesResponse>()
                .Include<SwitchAxe, GetSwitchAxeResponse>()
                .Include<InsectGlaive, GetInsectGlaiveResponse>()
                .Include<LightBowgun, GetLightBowgunResponse>()
                .Include<HeavyBowgun, GetHeavyBowgunResponse>()
                .Include<Bow, GetBowResponse>();
        }

        private static void ConfigureWeaponRequestToEntityMappings()
        {
            // configure request DTOs to weapon entities
            TypeAdapterConfig<CreateWeaponRequest, BaseWeapon>
                .NewConfig()
                .Include<CreateGreatswordRequest, Greatsword>()
                .Include<CreateLongswordRequest, Longsword>()
                .Include<CreateDualBladesRequest, DualBlades>()
                .Include<CreateSwordAndShieldRequest, SwordAndShield>()
                .Include<CreateHammerRequest, Hammer>()
                .Include<CreateHuntingHornRequest, HuntingHorn>()
                .Include<CreateGunlanceRequest, Gunlance>()
                .Include<CreateLanceRequest, Lance>()
                .Include<CreateChargeBladesRequest, ChargeBlade>()
                .Include<CreateSwitchAxeRequest, SwitchAxe>()
                .Include<CreateInsectGlaiveRequest, InsectGlaive>()
                .Include<CreateLightBowgunRequest, LightBowgun>()
                .Include<CreateHeavyBowgunRequest, HeavyBowgun>()
                .Include<CreateBowRequest, Bow>();
        }

        private static void ConfigureCommonMappings()
        {
            // configure enum mappings
            TypeAdapterConfig<PhialType?, string>
                .NewConfig()
                .MapWith(src => src.ToString());

            TypeAdapterConfig<CreateAmmoRequest, Ammo>.NewConfig();
            TypeAdapterConfig<Ammo, GetAmmoResponse>.NewConfig();
        }
    }
}
