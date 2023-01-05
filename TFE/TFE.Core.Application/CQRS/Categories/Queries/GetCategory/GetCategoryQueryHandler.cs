using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Entities;
using TFE.Infrastructure;
using TFE.Infrastructure.Exceptions.NotFoundExceptions;

namespace TFE.Application.CQRS.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler : BaseHandler, IQueryHandler<GetCategoryQuery, Category>
{
    public GetCategoryQueryHandler(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
    {
    }

    public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await DbContext.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.CategoryId, cancellationToken);
        if (category == null) throw new NotFoundException<Category>(request.CategoryId);

        return category;
    }
}