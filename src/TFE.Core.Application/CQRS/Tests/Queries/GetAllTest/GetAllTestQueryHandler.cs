using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Testing.TestAgregate;
using TFE.Infrastructure;

namespace TFE.Application.CQRS.Tests.Queries.GetAllTest;

public class GetAllTestQueryHandler : BaseHandler, IQueryHandler<GetAllTestQuery, IEnumerable<Test>>
{
    public GetAllTestQueryHandler(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
    {
    }

    public async Task<IEnumerable<Test>> Handle(GetAllTestQuery request, CancellationToken cancellationToken)
    {
        return await DbContext.Tests.AsNoTracking().ToListAsync(cancellationToken);
    }
}