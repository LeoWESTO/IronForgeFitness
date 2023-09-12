namespace IronForgeFitness.Domain.Abstractions
{
    /// <summary>
    /// Represents the entity that should be identified
    /// </summary>
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
