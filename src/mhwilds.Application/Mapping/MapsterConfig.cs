﻿using Mapster;
using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;
using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.EnumTypes;
using mhwilds.Domain.Entities.Weapons.Common;
using mhwilds.Domain.Entities.Weapons.Melee;
using mhwilds.Domain.Entities.Weapons.Ranged;

namespace mhwilds.Application.Mapping
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
            TypeAdapterConfig<WeaponRequest, BaseWeapon>
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
            TypeAdapterConfig<PhialType, string>
                .NewConfig()
                .MapWith(src => src.ToString());

            TypeAdapterConfig<CoatingType, string>
                .NewConfig()
                .MapWith(src => src.ToString());

            TypeAdapterConfig<ShellType, string>
                .NewConfig()
                .MapWith(src => src.ToString());

            // gunlance shell object mapping:
            TypeAdapterConfig<CreateShellRequest, Shell>.NewConfig();
            TypeAdapterConfig<Shell, GetShellResponse>.NewConfig();

            // ammo object mapping:
            TypeAdapterConfig<CreateAmmoRequest, Ammo>.NewConfig();
            TypeAdapterConfig<Ammo, GetLBGAmmoResponse>.NewConfig();
            TypeAdapterConfig<Ammo, GetHBGAmmoResponse>.NewConfig();
        }
    }
}
