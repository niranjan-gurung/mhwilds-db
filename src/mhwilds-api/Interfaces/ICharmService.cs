using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models;

namespace mhwilds_api.Interfaces
{
    public interface ICharmService
    {
        Task<List<GetCharmResponse>> GetAllAsync();
        Task<GetCharmResponse?> GetByIdAsync(int id);
        Task<GetCharmResponse> CreateAsync(CharmRequest request);
        Task<List<GetCharmResponse>> CreateRangeAsync(List<CharmRequest> requests);
        Task<GetCharmResponse> UpdateAsync(int id, CharmRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
