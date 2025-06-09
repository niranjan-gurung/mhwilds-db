using Mapster;
using mhwilds.Api.Application.DTOs.Skills;
using mhwilds.Api.Application.Interfaces;
using mhwilds.Api.Doman.Entities;

namespace mhwilds.Api.Application.Services
{
    public class SkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<List<GetSkillResponse>> GetAllSkillsAsync()
        {
            var skills = await _skillRepository.GetAllAsync();
            return skills.Adapt<List<GetSkillResponse>>();
        }

        public async Task<GetSkillResponse?> GetSkillByIdAsync(int id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null) return null;
            return skill.Adapt<GetSkillResponse>();
        }

        public async Task<List<GetSkillResponse>> CreateSkillsAsync(List<CreateSkillRequest> createRequests)
        {
            var skills = createRequests.Adapt<List<Skill>>();
            await _skillRepository.AddRangeAsync(skills);
            return skills.Adapt<List<GetSkillResponse>>();
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null) return false;
            await _skillRepository.DeleteAsync(skill);
            return true;
        }
    }
}
