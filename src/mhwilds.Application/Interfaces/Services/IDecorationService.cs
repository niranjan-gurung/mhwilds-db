using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.Interfaces.Services
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
