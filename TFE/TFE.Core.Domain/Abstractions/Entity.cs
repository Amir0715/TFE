namespace TFE.Domain.Abstractions
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity()
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
        }
        protected Entity(int id) : this() => Id = id;

        public int Id { get; protected set; }
        public DateTime CreatedOnUtc { get; protected set; }
        public DateTime UpdatedOnUtc { get; protected set; }

        public bool Equals(Entity? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Entity)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
