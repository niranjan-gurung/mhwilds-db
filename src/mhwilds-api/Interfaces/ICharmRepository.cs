using mhwilds_api.Models;

namespace mhwilds_api.Interfaces
{
    public interface ICharmRepository
    {
        Task<List<Charm>> GetAllAsync();
        Task<Charm?> GetByIdAsync(int id);
        Task<Charm> CreateAsync(Charm charm);
        Task<List<Charm>> CreateRangeAsync(List<Charm> charms);
        Task<Charm> UpdateAsync(Charm charm);
        Task<bool> DeleteAsync(int id);
    }
}
