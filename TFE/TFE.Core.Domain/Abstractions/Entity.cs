namespace TFE.Domain.Abstractions
{
    public abstract class Entity
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
    }
}
