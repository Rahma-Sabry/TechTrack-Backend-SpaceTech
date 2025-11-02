namespace TechPathNavigator.BLL.Dtos_s.SubCategory
{
    public class SubCategoryUpdateDto
    {
        public int? CategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public int? EstimatedDuration { get; set; }
    }
}

