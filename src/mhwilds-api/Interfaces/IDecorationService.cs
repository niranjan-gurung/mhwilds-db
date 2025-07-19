using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;
using mhwilds_api.Models;

namespace mhwilds_api.Interfaces
{
    public interface IDecorationService
    {
        Task<List<GetDecorationResponse>> GetAllAsync();
        Task<GetDecorationResponse?> GetByIdAsync(int id);
        Task<GetDecorationResponse> CreateAsync(DecorationRequest decoration);
        Task<List<GetDecorationResponse>> CreateRangeAsync(List<DecorationRequest> decorations);
        Task<GetDecorationResponse> UpdateAsync(int id, DecorationRequest decoration);
        Task<bool> DeleteAsync(int id);
    }
}
