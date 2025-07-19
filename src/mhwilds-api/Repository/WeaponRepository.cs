using mhwilds_api.DTO.Response;
using mhwilds_api.Interfaces;
using mhwilds_api.Models.Weapons;
using mhwilds_api.Models.Weapons.Ranged;
using mhwilds_api.Services;
using mhwilds_api.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using mhwilds_api.Models.EnumTypes;

namespace mhwilds_api.Repository
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly ApplicationDbContext _context;
        public WeaponRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Public CRUD Operations
        public async Task<List<BaseWeapon>> GetAllAsync()
        {
            var weapons = await _context.Weapons
                .Include(w => w.Skills)
                    .ThenInclude(s => s.Skill)
                .ToListAsync();

            if (weapons.Count > 0)
            {
                await LoadAmmoForWeapons(weapons);
            }

            return weapons;
        }

        public async Task<BaseWeapon?> GetByIdAsync(int id)
        {
            var weapon = await _context.Weapons
                .Include(w => w.Skills)
                    .ThenInclude(s => s.Skill)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (weapon != null)
            {
                await LoadAmmoForWeapon(weapon);
            }

            return weapon;
        }

        public async Task<BaseWeapon> CreateAsync(BaseWeapon weapon)
        {
            _context.Weapons.Add(weapon);
            await _context.SaveChangesAsync();
            return weapon;
        }

        public async Task<BaseWeapon> UpdateAsync(BaseWeapon weapon)
        {
            _context.Entry(weapon).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return weapon;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var weapon = await _context.Weapons.FindAsync(id);

            if (weapon == null)
            {
                return false;
            }

            _context.Weapons.Remove(weapon);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Private Helper Methods
        private async Task LoadAmmoForWeapons(List<BaseWeapon> weapons)
        {
            var lightBowgunIds = weapons
                .Where(w => w.WeaponType == WeaponType.LightBowgun)
                .Select(w => w.Id)
                .ToList();

            var heavyBowgunIds = weapons
                .Where(w => w.WeaponType == WeaponType.HeavyBowgun)
                .Select(w => w.Id)
                .ToList();

            if (lightBowgunIds.Any())
            {
                var lightBowguns = await _context.Set<LightBowgun>()
                    .Where(w => lightBowgunIds.Contains(w.Id))
                    .Include(w => w.Ammo)
                    .ToListAsync();
            }

            if (heavyBowgunIds.Any())
            {
                var heavyBowguns = await _context.Set<HeavyBowgun>()
                    .Where(w => heavyBowgunIds.Contains(w.Id))
                    .Include(w => w.Ammo)
                    .ToListAsync();
            }
        }

        private async Task LoadAmmoForWeapon(BaseWeapon weapon)
        {
            if (weapon.WeaponType == WeaponType.LightBowgun &&
                weapon is LightBowgun lightBowgun)
            {
                await _context.Entry(lightBowgun)
                    .Collection(w => w.Ammo)
                    .LoadAsync();
            }
            else if (weapon.WeaponType == WeaponType.HeavyBowgun &&
                weapon is HeavyBowgun heavyBowgun)
            {
                await _context.Entry(heavyBowgun)
                    .Collection(w => w.Ammo)
                    .LoadAsync();
            }
        }
        #endregion
    }
}
