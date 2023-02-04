using TFE.Application.CQRS.Abstractions.Messaging;

namespace TFE.Application.CQRS.Tests.Commands.CreateTest;

public record CreateTestCommand(string Title, string Description, int CategoryId, int UserProfileId) 
    : ICommand<int>;