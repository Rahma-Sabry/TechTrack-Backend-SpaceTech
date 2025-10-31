using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TechPathNavigator.Extensions
{
    /// <summary>
    /// Extension methods for validation operations
    /// Provides reusable validation utilities
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Converts FluentValidation errors to ModelStateDictionary
        /// </summary>
        public static void AddToModelState(
            this ValidationResult result,
            ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        /// <summary>
        /// Gets all error messages from ValidationResult
        /// </summary>
        public static List<string> GetErrorMessages(this ValidationResult result)
        {
            return result.Errors.Select(e => e.ErrorMessage).ToList();
        }

        /// <summary>
        /// Checks if validation result has errors
        /// </summary>
        public static bool HasErrors(this ValidationResult result)
        {
            return !result.IsValid;
        }
    }
}
