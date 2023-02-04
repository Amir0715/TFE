using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Entities;

namespace TFE.Application.CQRS.Categories.Queries.GetCategory;

public record GetCategoryQuery(int CategoryId) : IQuery<Category>;