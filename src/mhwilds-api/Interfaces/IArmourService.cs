using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models;

namespace mhwilds_api.Interfaces
{
    public interface IArmourService
    {
        Task<List<GetArmourResponse>> GetAllAsync();
        Task<GetArmourResponse?> GetByIdAsync(int id);
        Task<List<GetArmourResponse>> CreateRangeAsync(List<CreateArmourRequest> requests);
        Task<GetArmourResponse> UpdateAsync(int id, UpdateArmourRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
