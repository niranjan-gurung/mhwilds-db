using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models;

namespace mhwilds_api.Interfaces
{
    public interface ICharmService
    {
        Task<List<GetCharmResponse>> GetAllAsync();
        Task<GetCharmResponse?> GetByIdAsync(int id);
        Task<List<GetCharmResponse>> CreateRangeAsync(List<CharmRequest> charms);
        Task<GetCharmResponse> UpdateAsync(int id, CharmRequest charm);
        Task<bool> DeleteAsync(int id);
    }
}
