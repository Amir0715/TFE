using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Entities;
using TFE.Persistence;
using TFE.Persistence.Exceptions.NotFoundExceptions;

namespace TFE.Application.CQRS.Tests.Queries.GetTest;

public class GetTestQueryHandler : BaseHandler, IQueryHandler<GetTestQuery, Test>
{
    public GetTestQueryHandler(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
    {
    }

    public async Task<Test> Handle(GetTestQuery request, CancellationToken cancellationToken)
    {
        var test = await DbContext.Tests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.TestId, cancellationToken);
        if (test == null) throw new NotFoundException<Test>(request.TestId);

        return test;
    }
}