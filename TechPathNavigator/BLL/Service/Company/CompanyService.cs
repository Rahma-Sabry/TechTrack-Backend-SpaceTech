using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechPathNavigator.Common.Errors;
using TechPathNavigator.Common.Messages;
using TechPathNavigator.Common.Results;
using TechPathNavigator.DTOs;
using TechPathNavigator.Extensions;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repo;

        public CompanyService(ICompanyRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<CompanyGetDto>> GetAllAsync()
        {
            var companies = await _repo.GetAllAsync();
            return companies.Select(c => c.ToGetDto());
        }

        public async Task<CompanyGetDto?> GetByIdAsync(int id)
        {
            var company = await _repo.GetByIdAsync(id);
            return company?.ToGetDto();
        }

        public async Task<ServiceResult<CompanyGetDto>> CreateAsync(CompanyPostDto dto)
        {
            var errors = await ValidateAsync(dto);
            if (errors.Any())
                return ServiceResult<CompanyGetDto>.Fail(errors);

            var created = await _repo.AddAsync(dto.ToEntity());
            return ServiceResult<CompanyGetDto>.Ok(created.ToGetDto());
        }

        public async Task<ServiceResult<CompanyGetDto>> UpdateAsync(int id, CompanyPostDto dto)
        {
            var errors = await ValidateAsync(dto);
            if (errors.Any())
                return ServiceResult<CompanyGetDto>.Fail(errors);

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return ServiceResult<CompanyGetDto>.Fail(ApiMessages.CompanyNotFound);

            existing.CompanyName = dto.CompanyName ?? existing.CompanyName;
            existing.WebsiteUrl = dto.WebsiteUrl ?? existing.WebsiteUrl;

            var updated = await _repo.UpdateAsync(existing);
            return ServiceResult<CompanyGetDto>.Ok(updated.ToGetDto());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        private async Task<List<string>> ValidateAsync(CompanyPostDto dto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.CompanyName))
                errors.Add(ErrorMessages.Company_NameRequired);
            else if (await _repo.CompanyNameExistsAsync(dto.CompanyName))
                errors.Add(ErrorMessages.Company_NameExists);

            if (!string.IsNullOrWhiteSpace(dto.WebsiteUrl))
            {
                var pattern = @"^(https?:\/\/)?([\w-]+\.)+[\w-]+(\/\S*)?$";
                if (!Regex.IsMatch(dto.WebsiteUrl, pattern, RegexOptions.IgnoreCase))
                    errors.Add(ErrorMessages.Company_WebsiteInvalid);
            }

            return errors;
        }
    }
}
