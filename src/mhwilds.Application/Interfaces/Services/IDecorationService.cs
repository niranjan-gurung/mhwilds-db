using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.Interfaces.Services
{
    public interface IDecorationService
    {
        Task<List<DecorationResponse>> GetAllAsync();
        Task<DecorationResponse?> GetByIdAsync(int id);
        Task<DecorationResponse> CreateAsync(DecorationRequest decoration);
        Task<List<DecorationResponse>> CreateRangeAsync(List<DecorationRequest> decorations);
        Task<DecorationResponse> UpdateAsync(int id, DecorationRequest decoration);
        Task<bool> DeleteAsync(int id);
    }
}
