namespace TFE.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity() { }
        protected Entity(Guid id) => Id = id;

        public Guid Id { get; protected set; }
        public DateTime CreateDateTime { get; protected set; } = DateTime.Now;
        public DateTime UpdateDateTime { get; protected set; } = DateTime.Now;
    }
}
