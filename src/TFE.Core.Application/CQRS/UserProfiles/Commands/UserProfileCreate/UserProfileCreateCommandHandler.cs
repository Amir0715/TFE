using MapsterMapper;
using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Testing.AuthorAgregate;
using TFE.Infrastructure;

namespace TFE.Application.CQRS.UserProfiles.Commands.UserProfileCreate;

public class UserProfileCreateCommandHandler : BaseHandler, ICommandHandler<UserProfileCreateCommand, int>
{
    public UserProfileCreateCommandHandler(IMapper mapper, ApplicationDbContext dbContext) : base(mapper, dbContext)
    {
    }

    public async Task<int> Handle(UserProfileCreateCommand request, CancellationToken cancellationToken)
    {
        var userProfile = new Author(request.FirstName, request.LastName, request.Patronymic);
        await DbContext.UserProfiles.AddAsync(userProfile, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
        return userProfile.Id;
    }
}