using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.Interfaces.Services
{
    public interface IWeaponService
    {
        Task<List<GetWeaponResponse>> GetAllAsync();
        Task<GetWeaponResponse?> GetByIdAsync(int id);
        Task<GetWeaponResponse> CreateAsync(WeaponRequest request);
        Task<List<GetWeaponResponse>> CreateRangeAsync(List<WeaponRequest> requests);
        Task<GetWeaponResponse> UpdateAsync(int id, WeaponRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
