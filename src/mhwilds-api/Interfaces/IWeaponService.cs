using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;

namespace mhwilds_api.Interfaces
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
