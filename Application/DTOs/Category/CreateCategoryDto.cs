namespace Application.DTOs.Category;

public class CreateCategoryDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsModerationOnly { get; set; }
}
