using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Entities;
using TFE.Persistence;

namespace TFE.Application.CQRS.Categories.Queries.GetAllCategory;

public class GetAllCategoryQueryHandler : BaseHandler, IQueryHandler<GetAllCategoryQuery, IEnumerable<Category>>
{
    public GetAllCategoryQueryHandler(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
    {
    }

    public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await DbContext.Categories.AsNoTracking().ToListAsync(cancellationToken);
    }
}