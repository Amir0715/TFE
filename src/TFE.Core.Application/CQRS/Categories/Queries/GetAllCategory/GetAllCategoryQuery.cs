using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Testing.TestAgregate;

namespace TFE.Application.CQRS.Categories.Queries.GetAllCategory;

public record GetAllCategoryQuery : IQuery<IEnumerable<Category>>;