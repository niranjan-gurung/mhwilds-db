using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.Interfaces.Services
{
    public interface IArmourService
    {
        Task<List<GetArmourResponse>> GetAllAsync();
        Task<GetArmourResponse?> GetByIdAsync(int id);
        Task<GetArmourResponse> CreateAsync(ArmourRequest request);
        Task<List<GetArmourResponse>> CreateRangeAsync(List<ArmourRequest> requests);
        Task<GetArmourResponse> UpdateAsync(int id, ArmourRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
