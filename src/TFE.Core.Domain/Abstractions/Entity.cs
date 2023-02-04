using MediatR;

namespace TFE.Domain.Abstractions;

public abstract class Entity : IEquatable<Entity>
{
    private int? _requestedHashCode;
    private int _id;
    private List<INotification>? _domainEvents;

    protected Entity()
    {
        CreatedOnUtc = DateTime.UtcNow;
        UpdatedOnUtc = DateTime.UtcNow;
    }

    protected Entity(int id) : this() => Id = id;

    public virtual int Id
    {
        get => _id;
        protected set => _id = value;
    }

    public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();
    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents ??= new List<INotification>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    public DateTime CreatedOnUtc { get; protected set; }
    public DateTime UpdatedOnUtc { get; protected set; }
    
    public bool IsTransient()
    {
        return Id == default(int);
    }

    bool IEquatable<Entity>.Equals(Entity? other)
    {
        return Equals(other);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity item) 
            return false;
            
        if (ReferenceEquals(this, item))
            return true;
        if (GetType() != item.GetType())
            return false;
        if (item.IsTransient() || IsTransient())
            return false;
            
        return item.Id == Id;
    }

    public override int GetHashCode()
    {
        if (IsTransient()) 
            return base.GetHashCode();
            
        _requestedHashCode ??= Id.GetHashCode() ^ 31;
        return _requestedHashCode.Value;
    }

    public static bool operator ==(Entity left, Entity right)
    {
        return left?.Equals(right) ?? Equals(right, null);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }
}