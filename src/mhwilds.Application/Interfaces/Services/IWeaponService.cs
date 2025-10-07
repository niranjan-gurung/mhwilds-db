using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;

namespace mhwilds.Application.Interfaces.Services
{
    public interface IWeaponService
    {
        Task<List<WeaponResponse>> GetAllAsync();
        Task<WeaponResponse?> GetByIdAsync(int id);
        Task<WeaponResponse> CreateAsync(WeaponRequest request);
        Task<List<WeaponResponse>> CreateRangeAsync(List<WeaponRequest> requests);
        Task<WeaponResponse> UpdateAsync(int id, WeaponRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
