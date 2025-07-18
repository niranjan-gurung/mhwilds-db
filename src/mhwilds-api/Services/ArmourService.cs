using Mapster;
using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Interfaces;
using mhwilds_api.Models;
using mhwilds_api.Models.Weapons.Common;
using mhwilds_api.Repository;
using Microsoft.EntityFrameworkCore;

namespace mhwilds_api.Services
{
    public class ArmourService : IArmourService
    {
        private readonly IArmourRepository _armourRepository;
        private readonly ApplicationDbContext _context;         // needed for skill lookup
        private readonly ILogger<ArmourService> _logger;

        public ArmourService(
            IArmourRepository armourRepository,
            ApplicationDbContext context,
            ILogger<ArmourService> logger)
        {
            _armourRepository = armourRepository;
            _context = context;
            _logger = logger;
        }

        public async Task<List<GetArmourResponse>> GetAllAsync()
        {
            var armours = await _armourRepository.GetAllAsync();

            if (armours.Count == 0)
            {
                _logger.LogInformation("No armours found in database");
                return [];
            }

            return armours.Adapt<List<GetArmourResponse>>();
        }

        public async Task<GetArmourResponse?> GetByIdAsync(int id)
        {
            var armour = await _armourRepository.GetByIdAsync(id);

            if (armour == null)
            {
                _logger.LogInformation("No armour found in database");
                return null;
            }

            return armour.Adapt<GetArmourResponse>();
        }

        public async Task<List<GetArmourResponse>> CreateRangeAsync(List<ArmourRequest> requests)
        {
            var armours = requests.Adapt<List<Armour>>();

            // handle skill assignment
            for (int i = 0; i < requests.Count; i++)
            {
                var request = requests[i];
                var armour = armours[i];

                await HandleSkillAssignment(armour, request);
            }

            var createdArmours = await _armourRepository.CreateRangeAsync(armours);

            _logger.LogInformation("Created {Count} new armours", createdArmours.Count);

            return createdArmours.Adapt<List<GetArmourResponse>>();
        }

        public async Task<GetArmourResponse> UpdateAsync(int id, ArmourRequest request)
        {
            var existingArmour = await _armourRepository.GetByIdAsync(id);

            if (existingArmour == null)
            {
                throw new InvalidOperationException($"Armour with ID {id} not found");
            }

            var armour = request.Adapt<Armour>();
            armour.Id = id;

            await HandleSkillAssignment(armour, request);

            var updatedArmour = await _armourRepository.UpdateAsync(armour);

            _logger.LogInformation("Updated armour with ID {Id}", id);
            return updatedArmour.Adapt<GetArmourResponse>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _armourRepository.DeleteAsync(id);

            if (deleted)
            {
                _logger.LogInformation("Successfully deleted armour with ID {Id}", id);
            }
            else
            {
                _logger.LogInformation("No armour with ID {Id} found for deletion", id);
            }

            return deleted;
        }

        private async Task HandleSkillAssignment(Armour armour, ArmourRequest request)
        {
            if (request.Skills?.Count > 0)
            {
                var skillRankIds = request.Skills
                    .Select(sr => sr.Id).ToList();

                var skillRanks = await _context.SkillRanks
                    .Where(sr => skillRankIds.Contains(sr.Id))
                    .ToListAsync();

                armour.Skills = skillRanks;
            }
        }
    }
}
