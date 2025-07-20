using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.Interfaces.Services
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
