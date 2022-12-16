using TFE.Application.CQRS.Abstractions.Messaging;

namespace TFE.Application.CQRS.Test.Commands.CreateTest;

public class CreateTestCommand : ICommand<Guid>
{
    public string Title { get; set; }
    public string Desciption { get; set; }
    public Guid CategoryId { get; set; }
}