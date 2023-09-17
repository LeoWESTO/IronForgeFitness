using IronForgeFitness.Domain.Abstractions;
using IronForgeFitness.Domain.Enums;

namespace IronForgeFitness.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public TransactionType Type { get; set; } = TransactionType.None;
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; } = decimal.Zero;
        public string Description { get; set; }
    }
}
