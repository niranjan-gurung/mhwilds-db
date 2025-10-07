using Mapster;
using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;
using mhwilds.Application.Interfaces.Repositories;
using mhwilds.Application.Interfaces.Services;
using mhwilds.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace mhwilds.Application.Services
{
    public class ArmourService : IArmourService
    {
        private readonly IArmourRepository _armourRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ILogger<ArmourService> _logger;

        public ArmourService(
            IArmourRepository armourRepository,
            ISkillRepository skillRepository,
            ILogger<ArmourService> logger)
        {
            _armourRepository = armourRepository;
            _skillRepository = skillRepository;
            _logger = logger;
        }

        public async Task<List<ArmourResponse>> GetAllAsync()
        {
            var armours = await _armourRepository.GetAllAsync();

            if (armours.Count == 0)
            {
                _logger.LogInformation("No armours found in database");
                return [];
            }

            return armours.Adapt<List<ArmourResponse>>();
        }

        public async Task<ArmourResponse?> GetByIdAsync(int id)
        {
            var armour = await _armourRepository.GetByIdAsync(id);

            if (armour == null)
            {
                _logger.LogInformation("No armour found in database");
                return null;
            }

            return armour.Adapt<ArmourResponse>();
        }

        public async Task<ArmourResponse> CreateAsync(ArmourRequest request)
        {
            var armour = request.Adapt<Armour>();

            // handle skill assignment
            await HandleSkillAssignment(armour, request);

            var createdArmour = await _armourRepository.CreateAsync(armour);

            _logger.LogInformation("Created new armour with ID: {id}", createdArmour.Id);

            return createdArmour.Adapt<ArmourResponse>();
        }

        public async Task<List<ArmourResponse>> CreateRangeAsync(List<ArmourRequest> requests)
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

            return createdArmours.Adapt<List<ArmourResponse>>();
        }

        public async Task<ArmourResponse> UpdateAsync(int id, ArmourRequest request)
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
            return updatedArmour.Adapt<ArmourResponse>();
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

                var skillRanks = await _skillRepository
                    .GetSkillRanksByIdsAsync(skillRankIds);

                armour.Skills = skillRanks;
            }
        }
    }
}
