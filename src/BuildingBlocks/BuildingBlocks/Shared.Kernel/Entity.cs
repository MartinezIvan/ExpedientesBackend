namespace BuildingBlocks.Shared.Kernel
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
        private readonly List<DomainEvent> _domainEvents = new();
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        protected void AddDomainEvent(DomainEvent @event) => _domainEvents.Add(@event);
    }

    public abstract class DomainEvent
    {
        public DateTime OccurredOnUtc { get; } = DateTime.UtcNow;
    }
}
