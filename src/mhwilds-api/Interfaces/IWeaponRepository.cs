using mhwilds_api.DTO.Response;
using mhwilds_api.Models.Weapons;

namespace mhwilds_api.Interfaces
{
    public interface IWeaponRepository
    {
        Task<List<BaseWeapon>> GetAllAsync();
        Task<BaseWeapon?> GetByIdAsync(int id);
        Task<BaseWeapon> CreateAsync(BaseWeapon weapon);
        Task<BaseWeapon> UpdateAsync(BaseWeapon weapon);
        Task<bool> DeleteAsync(int id);
    }
}
