﻿namespace Application.DTOs.Category;

public class UpdateCategoryDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsModerationOnly { get; set; }
}
