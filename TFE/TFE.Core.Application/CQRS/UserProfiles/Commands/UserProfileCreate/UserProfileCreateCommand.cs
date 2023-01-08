using TFE.Application.CQRS.Abstractions.Messaging;

namespace TFE.Application.CQRS.UserProfiles.Commands.UserProfileCreate;

public record UserProfileCreateCommand(string FirstName, string LastName, string? Patronymic) : ICommand<int>;