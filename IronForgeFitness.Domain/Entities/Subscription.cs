using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities
{
    /// <summary>
    /// Represents an entity of customer's subscription 
    /// </summary>
    public class Subscription : BaseEntity
    {
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public List<Training> Actions { get; set; } = new();
    }
}
