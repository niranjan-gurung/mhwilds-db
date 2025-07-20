using Mapster;
using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;
using mhwilds.Application.Interfaces.Repositories;
using mhwilds.Application.Interfaces.Services;
using mhwilds.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace mhwilds.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly ILogger<SkillService> _logger;

        public SkillService(
            ISkillRepository skillRepository,
            ILogger<SkillService> logger)
        {
            _skillRepository = skillRepository;
            _logger = logger;
        }

        public async Task<List<GetSkillResponse>> GetAllAsync()
        {
            var skills = await _skillRepository.GetAllAsync();

            if (skills.Count == 0)
            {
                _logger.LogInformation("No skills found in database");
                return [];
            }

            return skills.Adapt<List<GetSkillResponse>>();
        }

        public async Task<GetSkillResponse?> GetByIdAsync(int id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);

            if (skill == null)
            {
                _logger.LogInformation("No skill found in database");
                return null;
            }

            return skill.Adapt<GetSkillResponse>();
        }

        public async Task<GetSkillResponse> CreateAsync(SkillRequest request)
        {
            var skill = request.Adapt<Skill>();

            var createdSkill = await _skillRepository.CreateAsync(skill);
            _logger.LogInformation("Created new skill with ID: {id}", createdSkill.Id);

            return createdSkill.Adapt<GetSkillResponse>();
        }

        public async Task<List<GetSkillResponse>> CreateRangeAsync(List<SkillRequest> requests)
        {
            var skills = requests.Adapt<List<Skill>>();

            var createdSkills = await _skillRepository.CreateRangeAsync(skills);
            _logger.LogInformation("Created {Count} new skills", createdSkills.Count);

            return createdSkills.Adapt<List<GetSkillResponse>>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _skillRepository.DeleteAsync(id);

            if (deleted)
            {
                _logger.LogInformation("Successfully deleted skill with ID {Id}", id);
            }
            else
            {
                _logger.LogInformation("No skill with ID {Id} found for deletion", id);
            }

            return deleted;
        }
    }
}
