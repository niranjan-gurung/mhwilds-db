using mhwilds.Domain.Entities;

namespace mhwilds.Application.Interfaces.Repositories
{
    public interface IArmourRepository
    {
        Task<List<Armour>> GetAllAsync();
        Task<Armour?> GetByIdAsync(int id);
        Task<Armour> CreateAsync(Armour armour);
        Task<List<Armour>> CreateRangeAsync(List<Armour> armours);
        Task<Armour> UpdateAsync(Armour armour);
        Task<bool> DeleteAsync(int id);
    }
}
