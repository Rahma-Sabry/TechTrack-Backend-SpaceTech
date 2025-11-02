using Microsoft.AspNetCore.Http.HttpResults;
using TechPathNavigator.Common.Errors;
using TechPathNavigator.Common.Messages;
using TechPathNavigator.Common.Results;
using TechPathNavigator.DTOs;
using TechPathNavigator.Extensions;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class CompanyTechnologyService : ICompanyTechnologyService
    {
        private static readonly HashSet<string> AllowedUsage = new(StringComparer.OrdinalIgnoreCase)
            { "Primary", "Secondary", "Experimental" };

        private readonly ICompanyTechnologyRepository _repo;

        public CompanyTechnologyService(ICompanyTechnologyRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<CompanyTechnologyGetDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(i => i.ToGetDto());
        }

        public async Task<CompanyTechnologyGetDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity?.ToGetDto();
        }

        public async Task<ServiceResult<CompanyTechnologyGetDto>> CreateAsync(CompanyTechnologyPostDto dto)
        {
            var errors = await ValidateAsync(dto, checkDuplicate: true);
            if (errors.Any())
                return ServiceResult<CompanyTechnologyGetDto>.Fail(errors);

            var created = await _repo.AddAsync(dto.ToEntity());
            return ServiceResult<CompanyTechnologyGetDto>.Ok(created.ToGetDto());
        }

        public async Task<ServiceResult<CompanyTechnologyGetDto>> UpdateAsync(int id, CompanyTechnologyPostDto dto)
        {
            var errors = await ValidateAsync(dto, checkDuplicate: false);
            if (errors.Any())
                return ServiceResult<CompanyTechnologyGetDto>.Fail(errors);

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return ServiceResult<CompanyTechnologyGetDto>.Fail(ApiMessages.CompanyTechnologyNotFound);

            existing.CompanyId = dto.CompanyId;
            existing.TechnologyId = dto.TechnologyId;
            existing.UsageLevel = dto.UsageLevel;

            var updated = await _repo.UpdateAsync(existing);
            if (updated == null)
                return ServiceResult<CompanyTechnologyGetDto>.Fail(ApiMessages.CompanyTechnologyNotFound);

            return ServiceResult<CompanyTechnologyGetDto>.Ok(updated.ToGetDto());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            return deleted;
        }

        private async Task<List<string>> ValidateAsync(CompanyTechnologyPostDto dto, bool checkDuplicate)
        {
            var errors = new List<string>();

            if (!await _repo.CompanyExistsAsync(dto.CompanyId))
            {
                errors.Add(ErrorMessages.CompanyTechnology_CompanyInvalid);
            }

            if (!await _repo.TechnologyExistsAsync(dto.TechnologyId))
            {
                errors.Add(ErrorMessages.CompanyTechnology_TechnologyInvalid);
            }

            if (!string.IsNullOrWhiteSpace(dto.UsageLevel) && !AllowedUsage.Contains(dto.UsageLevel))
            {
                errors.Add(ErrorMessages.CompanyTechnology_UsageInvalid);
            }

            if (checkDuplicate && await _repo.PairExistsAsync(dto.CompanyId, dto.TechnologyId))
            {
                errors.Add(ErrorMessages.CompanyTechnology_PairExists);
            }

            return errors;
        }
    }
}
