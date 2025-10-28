namespace TechPathNavigator.DTOs
{
    class CategoryPostDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; } // Nullable to allow root categories
    }
}