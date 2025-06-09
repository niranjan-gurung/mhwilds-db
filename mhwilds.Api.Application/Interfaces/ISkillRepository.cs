using mhwilds.Api.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mhwilds.Api.Application.Interfaces
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(int id);
        Task AddRangeAsync(List<Skill> skills);
        Task DeleteAsync(Skill skill);
    }
}
