namespace TechPathNavigator.Common
{
    public static class AppConstants
    {
        // ----------------------
        // Track related
        // ----------------------
        public static readonly string[] TrackDifficultyLevels =
        {
            "Beginner",
            "Intermediate",
            "Advanced"
        };

        public const string TrackSubCategoryIdRequired = "SubCategoryId must be greater than 0.";
        public const string TrackNameRequired = "TrackName is required.";
        public const string TrackEstimatedDurationRequired = "EstimatedDuration must be greater than 0.";
        public const string TrackDifficultyLevelInvalid = "DifficultyLevel must be one of: ";

        // ----------------------
        // Technology related
        // ----------------------
        public const string TechnologyNameRequired = "TechnologyName is required.";
        public const string TechnologyTrackIdRequired = "TrackId must be greater than 0.";

        // ----------------------
        // SubCategory related
        // ----------------------
        public const string SubCategoryNameRequired = "SubCategoryName is required.";

        // ----------------------
        // Roadmap related
        // ----------------------
        public const string RoadmapTechnologyIdRequired = "TechnologyId must be greater than 0.";
        public const string RoadmapStepNameRequired = "StepName is required.";
        public const string RoadmapInvalidOrder = "StepOrder must be greater than 0.";

        // ----------------------
        // General error messages
        // ----------------------
        public const string EntityNotFound = "Entity not found.";
        public const string InvalidId = "Id must be greater than 0.";
        public const string NullOrEmptyField = "Field cannot be null or empty.";

        // ----------------------
        // General success messages
        // ----------------------
        public const string CreatedSuccessfully = "Created successfully.";
        public const string UpdatedSuccessfully = "Updated successfully.";
        public const string DeletedSuccessfully = "Deleted successfully.";

        // ----------------------
        // Validation templates
        // ----------------------
        public static class Validation
        {
            public const string RequiredField = "{0} is required.";
            public const string MustBeGreaterThanZero = "{0} must be greater than zero.";
        }

        // ----------------------
        // Entity field names
        // ----------------------
        public static class Entities
        {
            public const string TrackId = "TrackId";
            public const string TechnologyName = "TechnologyName";
            public const string TechnologyId = "TechnologyId";
            public const string SubCategoryId = "SubCategoryId";
            public const string StepName = "StepName";
        }
    }
}
