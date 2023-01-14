using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Entities;
using TFE.Infrastructure;
using TFE.Infrastructure.Exceptions.NotFoundExceptions;

namespace TFE.Application.CQRS.Tests.Commands.CreateTest;

public class CreateTestCommandHandler : BaseHandler, ICommandHandler<CreateTestCommand, int>
{
    public CreateTestCommandHandler(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
    {
    }

    public async Task<int> Handle(CreateTestCommand request, CancellationToken cancellationToken)
    {
        var category = await DbContext.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId, cancellationToken);
        if (category == null) throw new NotFoundException<Category>(request.CategoryId);

        var userProfile = await DbContext.UserProfiles.FirstOrDefaultAsync(x => x.Id == request.UserProfileId, cancellationToken);
        if (userProfile == null) throw new NotFoundException<UserProfile>(request.UserProfileId);

        var test = new Test(request.Title, request.Description, category, userProfile);
        await DbContext.Tests.AddAsync(test, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return test.Id;
    }
}