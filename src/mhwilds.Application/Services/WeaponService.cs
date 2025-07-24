using Mapster;
using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;
using mhwilds.Application.Interfaces.Repositories;
using mhwilds.Application.Interfaces.Services;
using mhwilds.Domain.Entities.Weapons;
using mhwilds.Domain.Entities.Weapons.Melee;
using mhwilds.Domain.Entities.Weapons.Ranged;
using Microsoft.Extensions.Logging;

namespace mhwilds.Application.Services
{
    /// <summary>
    /// Service layer class
    /// - uses weapon repository via DI for database calls
    /// - handles error checking and res/req mappings
    /// </summary>
    public class WeaponService : IWeaponService
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ILogger<WeaponService> _logger;

        public WeaponService(
            IWeaponRepository weaponRepository,
            ISkillRepository skillRepository,
            ILogger<WeaponService> logger)
        {
            _weaponRepository = weaponRepository;
            _skillRepository = skillRepository;
            _logger = logger;
        }

        public async Task<List<GetWeaponResponse>> GetAllAsync()
        {
            var weapons = await _weaponRepository.GetAllAsync();

            if (weapons.Count == 0)
            {
                _logger.LogInformation("No weapons found in database");
                return [];
            }

            var response = new List<GetWeaponResponse>();

            foreach (var weapon in weapons)
            {
                GetWeaponResponse weaponResponse = MapWeaponToResponse(weapon);
                response.Add(weaponResponse);
            }

            return response;
        }

        public async Task<GetWeaponResponse?> GetByIdAsync(int id)
        {
            var weapon = await _weaponRepository.GetByIdAsync(id);

            if (weapon == null)
            {
                _logger.LogInformation("No weapon found in database");
                return null;
            }

            return MapWeaponToResponse(weapon);
        }

        public async Task<GetWeaponResponse> CreateAsync(WeaponRequest request)
        {
            BaseWeapon weapon = MapRequestToWeapon(request);

            // clear auto mapped skills by Mapster
            weapon.Skills = null;

            // handle skill assignment
            // references existing skills instead of creating new skill/skillranks,
            // this avoids duplicate skill ids.
            await HandleSkillAssignment(weapon, request);

            var createdWeapon = await _weaponRepository.CreateAsync(weapon);
            
            _logger.LogInformation("Created new weapon with ID: {Id} of type: {WeaponType}", 
                createdWeapon.Id, createdWeapon.WeaponType);

            return MapWeaponToResponse(createdWeapon);
        }

        public async Task<List<GetWeaponResponse>> CreateRangeAsync(List<WeaponRequest> requests)
        {
            var weapons = new List<BaseWeapon>();

            for (int i = 0; i < requests.Count; i++)
            {
                var request = requests[i];
                var weapon = MapRequestToWeapon(request);

                // existing skill assignment to weapon
                weapon.Skills = null;
                await HandleSkillAssignment(weapon, request);

                weapons.Add(weapon);
            }

            var createdWeapons = await _weaponRepository.CreateRangeAsync(weapons);

            _logger.LogInformation("Created {Count} new weapons of multiple types",
                createdWeapons.Count);

            // map each weapon to its appropriate type
            var responses = new List<GetWeaponResponse>();
            foreach (var weapon in createdWeapons)
            {
                var response = MapWeaponToResponse(weapon);
                responses.Add(response);
            }

            return responses;
        }

        public async Task<GetWeaponResponse> UpdateAsync(int id, WeaponRequest request)
        {
            var existingWeapon = await _weaponRepository.GetByIdAsync(id);
            if (existingWeapon == null)
            {
                throw new InvalidOperationException($"Weapon with ID: {id} not found");
            }
            
            var weapon = MapRequestToWeapon(request);

            // ensure the id matches
            weapon.Id = id;
            var updatedWeapon = await _weaponRepository.UpdateAsync(weapon);

            _logger.LogInformation("Updated weapon with ID {Id}", id);
            return MapWeaponToResponse(updatedWeapon);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _weaponRepository.DeleteAsync(id);
            if (deleted)
            {
                _logger.LogInformation("Successfully deleted weapon with ID: {id}", id);
            }
            else
            {
                _logger.LogInformation("No weapon with ID: {id} found in database for deletion", id);
            }

            return deleted;
        }

        #region Helper Methods
        private GetWeaponResponse MapWeaponToResponse(BaseWeapon weapon)
        {
            return weapon switch
            {
                Greatsword gs => gs.Adapt<GetGreatswordResponse>(),
                Longsword ls => ls.Adapt<GetLongswordResponse>(),
                DualBlades db => db.Adapt<GetDualBladesResponse>(),
                SwordAndShield sns => sns.Adapt<GetSwordAndShieldResponse>(),
                Hammer hm => hm.Adapt<GetHammerResponse>(),
                HuntingHorn hh => hh.Adapt<GetHuntingHornResponse>(),
                Gunlance gl => gl.Adapt<GetGunlanceResponse>(),
                Lance lnc => lnc.Adapt<GetLanceResponse>(),
                ChargeBlade cb => cb.Adapt<GetChargeBladesResponse>(),
                SwitchAxe sa => sa.Adapt<GetSwitchAxeResponse>(),
                InsectGlaive ig => ig.Adapt<GetInsectGlaiveResponse>(),
                LightBowgun lbg => lbg.Adapt<GetLightBowgunResponse>(),
                HeavyBowgun hbg => hbg.Adapt<GetHeavyBowgunResponse>(),
                Bow bow => bow.Adapt<GetBowResponse>(),
                _ => throw new InvalidOperationException($"Unsupported weapon type: {weapon.GetType().Name}")
            };
        }

        private BaseWeapon MapRequestToWeapon(WeaponRequest request)
        {
            return request switch
            {
                CreateGreatswordRequest gs => gs.Adapt<Greatsword>(),
                CreateLongswordRequest ls => ls.Adapt<Longsword>(),
                CreateDualBladesRequest db => db.Adapt<DualBlades>(),
                CreateSwordAndShieldRequest sns => sns.Adapt<SwordAndShield>(),
                CreateHammerRequest hm => hm.Adapt<Hammer>(),
                CreateHuntingHornRequest hh => hh.Adapt<HuntingHorn>(),
                CreateGunlanceRequest gl => gl.Adapt<Gunlance>(),
                CreateLanceRequest lnc => lnc.Adapt<Lance>(),
                CreateChargeBladesRequest cb => cb.Adapt<ChargeBlade>(),
                CreateSwitchAxeRequest sa => sa.Adapt<SwitchAxe>(),
                CreateInsectGlaiveRequest ig => ig.Adapt<InsectGlaive>(),
                CreateLightBowgunRequest lbg => lbg.Adapt<LightBowgun>(),
                CreateHeavyBowgunRequest hbg => hbg.Adapt<HeavyBowgun>(),
                CreateBowRequest bow => bow.Adapt<Bow>(),
                _ => throw new InvalidOperationException("Unsupported weapon type.")
            };
        }
        
        private async Task HandleSkillAssignment(BaseWeapon weapon, WeaponRequest request)
        {
            if (request.Skills?.Count > 0)
            {
                var skillRankIds = request.Skills
                    .Select(sr => sr.Id).ToList();

                var skillRanks = await _skillRepository
                    .GetSkillRanksByIdsAsync(skillRankIds);

                weapon.Skills = skillRanks;
            }
        }
        #endregion
    }
}
