namespace Domain.Core.Models
{
    public abstract class AggregateRoot : BaseEntity
    {
        private List<IDomainEvent> domainEvents;
        public AggregateRoot()
        {
            SetVersion();
        }

        /// <summary>
        /// To handle concurrency
        /// Vesion changes after each aggregate update
        /// </summary>
        public string Version { get; private set; }


        [BsonIgnore]
        public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents?.AsReadOnly();

        /// <summary>
        /// Clear domain events
        /// </summary>
        public void ClearDomainEvents()
        {
            domainEvents?.Clear();
        }

        /// <summary>
        /// Add domain event
        /// </summary>
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            CheckInvariants();

            UpdateAggregate();

            domainEvents ??= new List<IDomainEvent>();
            this.domainEvents.Add(domainEvent);
        }



        /// <summary>
        /// Check invariants for each entity
        /// Invariants are kind of validation that made the entity in true state
        /// Should be Called in the end of process for the entity
        /// </summary>
        protected abstract void CheckInvariants();

        /// <summary>
        /// update aggregate Version and ModifiedDateTime
        /// </summary>
        private void UpdateAggregate()
        {
            SetVersion();
            UpdateModifiedDateTime();
        }



        /// <summary>
        /// Vesion must change after each aggregate update
        /// </summary>
        private void SetVersion()
        {
            Version = Guid.NewGuid().ToString();
        }
    }
}
