using mhwilds.Domain.Entities;

namespace mhwilds.Application.Interfaces.Repositories
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
