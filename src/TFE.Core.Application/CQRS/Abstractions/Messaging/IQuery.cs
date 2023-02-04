using MediatR;

namespace TFE.Application.CQRS.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}