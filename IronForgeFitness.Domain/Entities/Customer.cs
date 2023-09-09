using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities
{
    public class Customer : Person
    {
        public Account Account { get; set; }
        public List<Subscription> Subscriptions { get; set; } = new();
    }
}
