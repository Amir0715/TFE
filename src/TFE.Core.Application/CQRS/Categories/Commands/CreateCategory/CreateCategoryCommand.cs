using TFE.Application.CQRS.Abstractions.Messaging;

namespace TFE.Application.CQRS.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Title, string Description, int? ParentCategoryId)
    : ICommand<int>;