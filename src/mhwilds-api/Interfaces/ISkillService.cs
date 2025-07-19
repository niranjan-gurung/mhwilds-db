using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models;

namespace mhwilds_api.Interfaces
{
    public interface ISkillService
    {
        Task<List<GetSkillResponse>> GetAllAsync();
        Task<GetSkillResponse?> GetByIdAsync(int id);
        Task<GetSkillResponse> CreateAsync(SkillRequest request);
        Task<List<GetSkillResponse>> CreateRangeAsync(List<SkillRequest> requests);
        Task<bool> DeleteAsync(int id);
    }
}
