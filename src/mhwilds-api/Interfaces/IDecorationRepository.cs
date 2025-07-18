using mhwilds_api.Models;

namespace mhwilds_api.Interfaces
{
    public interface IDecorationRepository
    {
        Task<List<Decoration>> GetAllAsync();
        Task<Decoration?> GetByIdAsync(int id);
        Task<Decoration> CreateAsync(Decoration decoration);
        Task<List<Decoration>> CreateRangeAsync(List<Decoration> decorations);
        Task<Decoration> UpdateAsync(Decoration decoration);
        Task<bool> DeleteAsync(int id);
    }
}
