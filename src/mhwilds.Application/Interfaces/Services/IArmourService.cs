using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.Interfaces.Services
{
    public interface IArmourService
    {
        Task<List<ArmourResponse>> GetAllAsync();
        Task<ArmourResponse?> GetByIdAsync(int id);
        Task<ArmourResponse> CreateAsync(ArmourRequest request);
        Task<List<ArmourResponse>> CreateRangeAsync(List<ArmourRequest> requests);
        Task<ArmourResponse> UpdateAsync(int id, ArmourRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
