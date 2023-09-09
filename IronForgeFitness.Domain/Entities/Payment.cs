using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Service Service { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
    }
}
