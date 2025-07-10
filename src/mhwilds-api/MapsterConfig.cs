using Mapster;
using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models.Weapons;
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
            // Configure each weapon type to its specific response DTO
            TypeAdapterConfig<Greatsword, GetGreatswordResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness);

            TypeAdapterConfig<Longsword, GetLongswordResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness);

            TypeAdapterConfig<DualBlades, GetDualBladesResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness);

            TypeAdapterConfig<Hammer, GetHammerResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness);

            TypeAdapterConfig<HuntingHorn, GetHuntingHornResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness);
                //.Map(dest => dest.Notes, src => src.Notes);

            TypeAdapterConfig<Gunlance, GetGunlanceResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness);

            TypeAdapterConfig<Lance, GetLanceResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness);

            TypeAdapterConfig<SwordAndShield, GetSwordAndShieldResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness);

            TypeAdapterConfig<ChargeBlade, GetChargeBladesResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .Map(dest => dest.PhialType, src => src.Phial.ToString());
            //.Map(dest => dest.PhialDamage, src => src.PhialDamage);

            TypeAdapterConfig<SwitchAxe, GetSwitchAxeResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .Map(dest => dest.PhialType, src => src.Phial.ToString());
            //.Map(dest => dest.PhialDamage, src => src.PhialDamage);

            TypeAdapterConfig<InsectGlaive, GetInsectGlaiveResponse>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness);
            //.Map(dest => dest.KinsectBonusType, src => src.KinsectBonusType.ToString());

            TypeAdapterConfig<LightBowgun, GetLightBowgunResponse>
                .NewConfig()
                .Map(dest => dest.Ammo, src => src.Ammo)
                .Map(dest => dest.SpecialAmmo, src => src.SpecialAmmo);
            //.Map(dest => dest.Deviation, src => src.Deviation);

            TypeAdapterConfig<HeavyBowgun, GetHeavyBowgunResponse>
                .NewConfig()
                .Map(dest => dest.Ammo, src => src.Ammo);
            //.Map(dest => dest.SpecialAmmo, src => src.SpecialAmmo)
            //.Map(dest => dest.Deviation, src => src.Deviation)
            //.Map(dest => dest.HasShield, src => src.HasShield);

            TypeAdapterConfig<Bow, GetBowResponse>
                .NewConfig()
                .Map(dest => dest.Coatings, src => src.Coatings);
                //.Map(dest => dest.ChargeLevels, src => src.ChargeLevels);
        }

        private static void ConfigureWeaponRequestToEntityMappings()
        {
            // Configure request DTOs to weapon entities
            TypeAdapterConfig<CreateGreatswordRequest, Greatsword>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.Greatsword);

            TypeAdapterConfig<CreateLongswordRequest, Longsword>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.Longsword);

            TypeAdapterConfig<CreateDualBladesRequest, DualBlades>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.DualBlades);

            TypeAdapterConfig<CreateHammerRequest, Hammer>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.Hammer);

            TypeAdapterConfig<CreateHuntingHornRequest, HuntingHorn>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                //.Map(dest => dest.Notes, src => src.Notes)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.HuntingHorn);

            TypeAdapterConfig<CreateGunlanceRequest, Gunlance>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.Gunlance);

            TypeAdapterConfig<CreateLanceRequest, Lance>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.Lance);

            TypeAdapterConfig<CreateSwordAndShieldRequest, SwordAndShield>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.SwordAndShield);

            TypeAdapterConfig<CreateChargeBladesRequest, ChargeBlade>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .Map(dest => dest.Phial, src => string.IsNullOrEmpty(src.Phial) ? (PhialType?)null : Enum.Parse<PhialType>(src.Phial))
                //.Map(dest => dest.PhialDamage, src => src.PhialDamage)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.ChargeBlade);

            TypeAdapterConfig<CreateSwitchAxeRequest, SwitchAxe>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                .Map(dest => dest.Phial, src => string.IsNullOrEmpty(src.Phial) ? (PhialType?)null : Enum.Parse<PhialType>(src.Phial))
                //.Map(dest => dest.PhialDamage, src => src.PhialDamage)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.SwitchAxe);

            TypeAdapterConfig<CreateInsectGlaiveRequest, InsectGlaive>
                .NewConfig()
                .Map(dest => dest.Sharpness, src => src.Sharpness)
                //.Map(dest => dest.KinsectBonusType, src => string.IsNullOrEmpty(src.KinsectBonusType) ? (KinsectBonusType?)null : Enum.Parse<KinsectBonusType>(src.KinsectBonusType))
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.InsectGlaive);

            TypeAdapterConfig<CreateLightBowgunRequest, LightBowgun>
                .NewConfig()
                .Map(dest => dest.Ammo, src => src.Ammo)
                .Map(dest => dest.SpecialAmmo, src => src.SpecialAmmo)
                //.Map(dest => dest.Deviation, src => src.Deviation)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.LightBowgun);

            TypeAdapterConfig<CreateHeavyBowgunRequest, HeavyBowgun>
                .NewConfig()
                .Map(dest => dest.Ammo, src => src.Ammo)
                //.Map(dest => dest.SpecialAmmo, src => src.SpecialAmmo)
                //.Map(dest => dest.Deviation, src => src.Deviation)
                //.Map(dest => dest.HasShield, src => src.HasShield)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.HeavyBowgun);

            TypeAdapterConfig<CreateBowRequest, Bow>
                .NewConfig()
                .Map(dest => dest.Coatings, src => src.Coatings)
                //.Map(dest => dest.ChargeLevels, src => src.ChargeLevels)
                .AfterMapping((src, dest) => dest.WeaponType = WeaponType.Bow);
        }

        private static void ConfigureCommonMappings()
        {
            // Configure enum mappings
            //TypeAdapterConfig<ElementType?, string>
            //    .NewConfig()
            //    .MapWith(src => src?.ToString());

            //TypeAdapterConfig<StatusType?, string>
            //    .NewConfig()
            //    .MapWith(src => src?.ToString());

            //TypeAdapterConfig<EldersealLevel?, string>
            //    .NewConfig()
            //    .MapWith(src => src?.ToString());

            TypeAdapterConfig<PhialType?, string>
                .NewConfig()
                .MapWith(src => src.ToString());

            //TypeAdapterConfig<KinsectBonusType?, string>
            //    .NewConfig()
            //    .MapWith(src => src?.ToString());

            //// Configure nested object mappings
            //TypeAdapterConfig<HornNote, GetHornNoteResponse>
            //    .NewConfig()
            //    .Map(dest => dest.Note, src => src.Note)
            //    .Map(dest => dest.Position, src => src.Position);

            //TypeAdapterConfig<BowCoating, GetBowCoatingResponse>
            //    .NewConfig()
            //    .Map(dest => dest.Type, src => src.Type.ToString())
            //    .Map(dest => dest.Capacity, src => src.Capacity);

            //TypeAdapterConfig<BowChargeLevel, GetBowChargeLevelResponse>
            //    .NewConfig()
            //    .Map(dest => dest.Level, src => src.Level)
            //    .Map(dest => dest.ShotType, src => src.ShotType.ToString())
            //    .Map(dest => dest.ShotCount, src => src.ShotCount);

            //TypeAdapterConfig<BowgunAmmo, GetBowgunAmmoResponse>
            //    .NewConfig()
            //    .Map(dest => dest.Type, src => src.Type.ToString())
            //    .Map(dest => dest.Level, src => src.Level)
            //    .Map(dest => dest.Capacity, src => src.Capacity)
            //    .Map(dest => dest.Recoil, src => src.Recoil.ToString())
            //    .Map(dest => dest.Reload, src => src.Reload.ToString());
        }
    }
}
