namespace TechPathNavigator.Common.Errors
{
    public static class ErrorMessages
    {
        // InterviewQuestion Errors
        public const string InterviewQuestion_TextRequired = "QuestionText is required.";
        public const string InterviewQuestion_TechnologyRequired = "TechnologyId must be a valid existing technology.";
        public const string InterviewQuestion_DifficultyInvalid = "DifficultyLevel must be one of: Easy, Medium, Hard.";
        public const string InterviewQuestion_TypeInvalid = "QuestionType must be one of: Technical, Behavioral, SystemDesign.";

        // Company Errors
        public const string Company_NameRequired = "CompanyName is required.";
        public const string Company_NameExists = "A company with this name already exists.";
        public const string Company_WebsiteInvalid = "WebsiteUrl is not a valid URL.";

        // CompanyTechnology Errors
        public const string CompanyTechnology_CompanyInvalid = "CompanyId must reference an existing company.";
        public const string CompanyTechnology_TechnologyInvalid = "TechnologyId must reference an existing technology.";
        public const string CompanyTechnology_UsageInvalid = "UsageLevel must be one of: Primary, Secondary, Experimental.";
        public const string CompanyTechnology_PairExists = "This company already has this technology assigned.";

        // Review Errors
        public const string Review_RatingInvalid = "Rating must be between 1 and 5.";
        public const string Review_UserInvalid = "UserId must reference an existing user.";
        public const string Review_TechnologyInvalid = "TechnologyId must reference an existing technology.";

        // Roadmap Errors
        public const string Roadmap_TitleRequired = "Roadmap title is required.";
        public const string Roadmap_TrackInvalid = "TrackId must reference an existing track.";
        public const string Roadmap_NotFound = "Roadmap not found.";
        public const string Roadmap_NotCreated = "Failed to create the roadmap.";
        public const string Roadmap_NotUpdated = "Failed to update the roadmap.";
        public const string Roadmap_NotDeleted = "Failed to delete the roadmap.";

        // RoadmapStep Errors
        public const string RoadmapStep_NotFound = "The requested roadmap step was not found.";
        public const string RoadmapStep_TitleRequired = "StepTitle is required.";
        public const string RoadmapStep_RoadmapInvalid = "RoadmapId must reference an existing roadmap.";
        public const string RoadmapStep_OrderInvalid = "StepOrder must be greater than zero.";

        // SubCategory Errors
        public const string SubCategory_NotFound = "SubCategory not found.";
        public const string SubCategory_NameRequired = "SubCategoryName is required.";
        public const string SubCategory_CategoryInvalid = "CategoryId must reference an existing category.";

        // Technology Errors
        public const string Technology_NameRequired = "TechnologyName is required.";
        public const string Technology_SubCategoryInvalid = "SubCategoryId must reference an existing subcategory.";
        public const string Technology_AlreadyExists = "A technology with this name already exists in the selected subcategory.";
        public const string Technology_NotFound = "The specified technology does not exist.";

        // Track Errors
        public const string Track_NameRequired = "TrackName is required.";
        public const string Track_NameExists = "A track with this name already exists.";
        public const string Track_DescriptionRequired = "Description is required.";
        public const string Track_InvalidId = "Track with the specified ID does not exist.";

        // User Errors
        public const string User_EmailRequired = "Email is required.";
        public const string User_EmailInvalid = "Email is not valid.";
        public const string User_EmailExists = "A user with this email already exists.";
        public const string User_NameRequired = "FullName is required.";
        public const string User_NotFound = "User with the specified ID does not exist.";
        public const string User_PasswordRequired = "Password is required.";
        public const string User_PasswordWeak = "Password must meet complexity requirements.";

        // Category Errors
        public const string Category_NameRequired = "CategoryName is required.";
        public const string Category_NameExists = "A category with this name already exists.";
        public const string Category_DescriptionRequired = "Description is required.";
        public const string Category_ImageUrlInvalid = "ImageUrl must be a valid URL.";
        public const string Category_NotFound = "Category with the specified ID does not exist.";
        public const string Category_CreateFailed = "Failed to create the category.";
        public const string Category_UpdateFailed = "Failed to update the category.";
        public const string Category_DeleteFailed = "Failed to delete the category.";
        public const string Category_FetchFailed = "Failed to fetch categories.";
        public const string Category_FetchByIdFailed = "Failed to fetch category by ID.";

    }
}


