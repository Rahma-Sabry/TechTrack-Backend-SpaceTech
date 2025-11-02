namespace TechPathNavigator.Common.Errors
{
    public static class ErrorMessages
    {
        public const string InterviewQuestion_TextRequired = "QuestionText is required.";
        public const string InterviewQuestion_TechnologyRequired = "TechnologyId must be a valid existing technology.";
        public const string InterviewQuestion_DifficultyInvalid = "DifficultyLevel must be one of: Easy, Medium, Hard.";
        public const string InterviewQuestion_TypeInvalid = "QuestionType must be one of: Technical, Behavioral, SystemDesign.";

        public const string Company_NameRequired = "CompanyName is required.";
        public const string Company_NameExists = "A company with this name already exists.";
        public const string Company_WebsiteInvalid = "WebsiteUrl is not a valid URL.";

        public const string CompanyTechnology_CompanyInvalid = "CompanyId must reference an existing company.";
        public const string CompanyTechnology_TechnologyInvalid = "TechnologyId must reference an existing technology.";
        public const string CompanyTechnology_UsageInvalid = "UsageLevel must be one of: Primary, Secondary, Experimental.";
        public const string CompanyTechnology_PairExists = "This company already has this technology assigned.";

        public const string Review_RatingInvalid = "Rating must be between 1 and 5.";
        public const string Review_UserInvalid = "UserId must reference an existing user.";
        public const string Review_TechnologyInvalid = "TechnologyId must reference an existing technology.";
    }
}


