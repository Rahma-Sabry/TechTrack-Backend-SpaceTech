namespace TechPathNavigator.DTOs
    {
    public class CategoryGetDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<CategoryGetDto>? SubCategories { get; set; }
        public List<RoadmapGetDto>? Roadmaps { get; set; }
    }
}