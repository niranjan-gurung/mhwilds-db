using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.Interfaces.Services
{
    public interface ISkillService
    {
        Task<List<SkillResponse>> GetAllAsync();
        Task<SkillResponse?> GetByIdAsync(int id);
        Task<SkillResponse> CreateAsync(SkillRequest request);
        Task<List<SkillResponse>> CreateRangeAsync(List<SkillRequest> requests);
        Task<bool> DeleteAsync(int id);
    }
}
