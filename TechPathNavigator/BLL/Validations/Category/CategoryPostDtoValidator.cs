using FluentValidation;
using TechPathNavigator.DTOs;

namespace TechPathNavigator.BLL.Validations.Category
{
    /// <summary>
    /// Validator for CategoryPostDto
    /// Ensures data integrity before processing
    /// </summary>
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required")
                .MaximumLength(200).WithMessage("Category name cannot exceed 200 characters")
                .Matches(@"^[a-zA-Z0-9\s\-]+$").WithMessage("Category name contains invalid characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters");
        }
    }
}
