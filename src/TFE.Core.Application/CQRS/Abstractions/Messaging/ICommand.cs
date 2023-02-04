using MediatR;

namespace TFE.Application.CQRS.Abstractions.Messaging;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}