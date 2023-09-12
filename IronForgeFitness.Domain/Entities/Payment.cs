using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities
{
    /// <summary>
    /// Represents an entity of payment data
    /// </summary>
    public class Payment : BaseEntity
    {
        public Service Service { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
    }
}
