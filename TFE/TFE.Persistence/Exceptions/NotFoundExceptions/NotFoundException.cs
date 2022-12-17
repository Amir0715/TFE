using TFE.Domain.Abstractions;
using TFE.Domain.Entities;

namespace TFE.Persistence.Exceptions.NotFoundExceptions;

public class NotFoundException<T> : Exception
    where T : Entity
{
    public NotFoundException(int key) : base($"Entity with type {typeof(T)} and with key {key} not found")
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }

    public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}