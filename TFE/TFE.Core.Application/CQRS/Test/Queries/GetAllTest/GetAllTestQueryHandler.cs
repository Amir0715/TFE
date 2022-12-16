using Microsoft.EntityFrameworkCore;
using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Persistence;

namespace TFE.Application.CQRS.Test.Queries.GetAllTest;

public class GetAllTestQueryHandler : IQueryHandler<GetAllTestQuery, IEnumerable<Domain.Entities.Test>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetAllTestQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<Domain.Entities.Test>> Handle(GetAllTestQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Tests.AsNoTracking().ToListAsync(cancellationToken);
    }
}