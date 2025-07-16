using mhwilds_api.DTO.Request;
using mhwilds_api.DTO.Response;

namespace mhwilds_api.Interfaces
{
    public interface IWeaponService
    {
        Task<List<GetWeaponResponse>> GetAllAsync();
        Task<GetWeaponResponse?> GetByIdAsync(int id);
        Task<GetWeaponResponse> CreateAsync(CreateWeaponRequest request);
        Task<GetWeaponResponse> UpdateAsync(int id, CreateWeaponRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
