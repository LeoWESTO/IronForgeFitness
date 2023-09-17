using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities
{
    /// <summary>
    /// Represents an entity of customer's subscription 
    /// </summary>
    public class Subscription : BaseEntity
    {
        public Transaction? Transaction { get; set; }
        public Service? Service { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
