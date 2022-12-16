using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Persistence;

namespace TFE.Application.CQRS.Test.Commands.CreateTest;

public class CreateTestCommandHandler : ICommandHandler<CreateTestCommand, Guid>
{
    private readonly ApplicationDbContext _dbContext;

    public CreateTestCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task<Guid> Handle(CreateTestCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Guid.NewGuid());
    }
}