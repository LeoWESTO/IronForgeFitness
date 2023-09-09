using IronForgeFitness.Domain.Abstractions;
using IronForgeFitness.Domain.Enums;

namespace IronForgeFitness.Domain.Entities
{
    public class Expence : BaseEntity
    {
        public decimal Amount { get; set; }
        public ExpenceCategory Category { get; set; }
    }
}
