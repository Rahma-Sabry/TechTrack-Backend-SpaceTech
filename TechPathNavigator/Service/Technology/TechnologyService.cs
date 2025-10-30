using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Common;
using TechPathNavigator.Data;
using TechPathNavigator.DTOs;
using TechPathNavigator.Mappers;
using TechPathNavigator.Models;
using TechPathNavigator.Service.Technology;

using EntityTechnology = TechPathNavigator.Models.Technology;

namespace TechPathNavigator.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ApplicationDbContext _context;

        public TechnologyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TechnologyGetDto>> GetAllAsync()
        {
            var techs = await _context.Technologies.ToListAsync();
            return techs.Select(t => t.ToDto<EntityTechnology, TechnologyGetDto>());
        }

        public async Task<TechnologyGetDto?> GetByIdAsync(int id)
        {
            var tech = await _context.Technologies.FindAsync(id);
            return tech?.ToDto<EntityTechnology, TechnologyGetDto>();
        }

        public async Task<TechnologyGetDto> AddAsync(TechnologyPostDto dto)
        {
            ValidateTechnology(dto);

            var entity = dto.ToEntity<EntityTechnology, TechnologyPostDto>();
            _context.Technologies.Add(entity);
            await _context.SaveChangesAsync();

            return entity.ToDto<EntityTechnology, TechnologyGetDto>();
        }

        public async Task<TechnologyGetDto?> UpdateAsync(int id, TechnologyPostDto dto)
        {
            var existing = await _context.Technologies.FindAsync(id);
            if (existing == null) return null;

            ValidateTechnology(dto);

            var updated = dto.ToEntity<EntityTechnology, TechnologyPostDto>(id);
            _context.Entry(existing).CurrentValues.SetValues(updated);
            await _context.SaveChangesAsync();

            return updated.ToDto<EntityTechnology, TechnologyGetDto>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tech = await _context.Technologies.FindAsync(id);
            if (tech == null) return false;

            _context.Technologies.Remove(tech);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Validation logic
        private void ValidateTechnology(TechnologyPostDto dto)
        {
            if (dto.TrackId <= 0)
                throw new ArgumentException(AppConstants.TechnologyTrackIdRequired);

            if (string.IsNullOrWhiteSpace(dto.TechnologyName))
                throw new ArgumentException(AppConstants.TechnologyNameRequired);
        }
    }
}
