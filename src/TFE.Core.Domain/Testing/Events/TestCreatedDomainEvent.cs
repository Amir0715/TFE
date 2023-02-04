using MediatR;
using TFE.Domain.Testing.TestAgregate;

namespace TFE.Domain.Testing.Events;

public class TestCreatedDomainEvent : INotification
{
    public Test Test { get; }

}