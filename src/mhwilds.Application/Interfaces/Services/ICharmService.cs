using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.Interfaces.Services
{
    public interface ICharmService
    {
        Task<List<CharmResponse>> GetAllAsync();
        Task<CharmResponse?> GetByIdAsync(int id);
        Task<CharmResponse> CreateAsync(CharmRequest request);
        Task<List<CharmResponse>> CreateRangeAsync(List<CharmRequest> requests);
        Task<CharmResponse> UpdateAsync(int id, CharmRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
