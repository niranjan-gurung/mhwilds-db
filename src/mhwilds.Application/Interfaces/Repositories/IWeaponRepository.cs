using mhwilds.Domain.Entities.Weapons;

namespace mhwilds.Application.Interfaces.Repositories
{
    public interface IWeaponRepository
    {
        Task<List<BaseWeapon>> GetAllAsync();
        Task<BaseWeapon?> GetByIdAsync(int id);
        Task<BaseWeapon> CreateAsync(BaseWeapon weapon);
        Task<List<BaseWeapon>> CreateRangeAsync(List<BaseWeapon> weapons);
        Task<BaseWeapon> UpdateAsync(BaseWeapon weapon);
        Task<bool> DeleteAsync(int id);
    }
}
