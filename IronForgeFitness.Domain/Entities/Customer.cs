using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities
{
    /// <summary>
    /// Represents an entity of customer
    /// </summary>
    public class Customer : Person
    {
        public Account? Account { get; set; }
        public List<Subscription> Subscriptions { get; set; } = new();
    }
}
