namespace TFE.WebApi.DTOs;

public record CreateCategoryDTO(string Title, string Description, int? ParentCategoryId = null);