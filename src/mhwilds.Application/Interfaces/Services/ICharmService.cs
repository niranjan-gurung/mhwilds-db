using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.Interfaces.Services
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
