namespace TechPathNavigator.Helpers
{
    public static class ErrorMessages
    {
        //  Category Errors
        public const string Category_FetchFailed = "Failed to retrieve categories from database.";
        public const string Category_FetchByIdFailed = "Failed to retrieve category by ID.";
        public const string Category_CreateFailed = "Failed to create category.";
        public const string Category_UpdateFailed = "Failed to update category.";
        public const string Category_DeleteFailed = "Failed to delete category.";

        //  Company Errors
        public const string Company_NameRequired = "Company name is required.";
        public const string Company_NameExists = "A company with this name already exists.";
        public const string Company_WebsiteInvalid = "Invalid company website URL format.";
        public const string Company_NotFound = "Company not found.";

        // CompanyTechnology Errors
        public const string CompanyTechnology_CompanyInvalid = "Invalid company ID.";
        public const string CompanyTechnology_TechnologyInvalid = "Invalid technology ID.";
        public const string CompanyTechnology_UsageInvalid = "Invalid usage level. Allowed values are: Primary, Secondary, Experimental.";
        public const string CompanyTechnology_PairExists = "This company-technology pair already exists.";
        public const string CompanyTechnology_NotFound = "CompanyTechnology not found.";

        // 🟦 InterviewQuestion Errors
        public const string InterviewQuestion_NotFound = "Interview question not found.";
        public const string InterviewQuestion_TextRequired = "Question text is required.";
        public const string InterviewQuestion_TechnologyRequired = "Technology ID is invalid or required.";
        public const string InterviewQuestion_DifficultyInvalid = "Invalid difficulty level. Allowed values: Easy, Medium, Hard.";
        public const string InterviewQuestion_TypeInvalid = "Invalid question type. Allowed values: Technical, Behavioral, SystemDesign.";

        // 🟩 Review Errors
        public const string Review_NotFound = "Review not found.";
        public const string Review_RatingInvalid = "Rating must be between 1 and 5.";
        public const string Review_UserInvalid = "User not found or invalid.";
        public const string Review_TechnologyInvalid = "Technology not found or invalid.";




    }
}

