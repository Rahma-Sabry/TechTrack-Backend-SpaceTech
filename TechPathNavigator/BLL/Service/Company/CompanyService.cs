using System.Text.RegularExpressions;
using TechPathNavigator.Common.Errors;
using TechPathNavigator.Common.Results;
using TechPathNavigator.DTOs;
using TechPathNavigator.Extensions;
using TechPathNavigator.Repositories;
using TechPathNavigator.Helpers;

namespace TechPathNavigator.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;

        public CompanyService(ICompanyRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CompanyGetDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return items.Select(i => i.ToGetDto());
        }

        public async Task<CompanyGetDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity?.ToGetDto();
        }

        public async Task<ServiceResult<CompanyGetDto>> CreateAsync(CompanyPostDto dto)
        {
            var errors = await Validate(dto);
            if (errors.Any()) return ServiceResult<CompanyGetDto>.Fail(errors);

            var created = await _repo.AddAsync(dto.ToEntity());
            return ServiceResult<CompanyGetDto>.Ok(created.ToGetDto());
        }

        public async Task<ServiceResult<CompanyGetDto>> UpdateAsync(int id, CompanyPostDto dto)
        {
            var errors = await Validate(dto);
            if (errors.Any()) return ServiceResult<CompanyGetDto>.Fail(errors);

            var updated = await _repo.UpdateAsync(dto.ToEntity(id));
            if (updated == null)
                return ServiceResult<CompanyGetDto>.Fail(ErrorMessages.Company_NotFound);


            return ServiceResult<CompanyGetDto>.Ok(updated.ToGetDto());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        private async Task<List<string>> Validate(CompanyPostDto dto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.CompanyName))
            {
                errors.Add(ErrorMessages.Company_NameRequired);
            }
            else if (await _repo.CompanyNameExistsAsync(dto.CompanyName))
            {
                errors.Add(ErrorMessages.Company_NameExists);
            }

            if (!string.IsNullOrWhiteSpace(dto.WebsiteUrl))
            {
                var pattern = @"^(https?:\/\/)?([\w-]+\.)+[\w-]+(\/\S*)?$";
                if (!Regex.IsMatch(dto.WebsiteUrl, pattern, RegexOptions.IgnoreCase))
                {
                    errors.Add(ErrorMessages.Company_WebsiteInvalid);
                }
            }

            return errors;
        }
    }
}


