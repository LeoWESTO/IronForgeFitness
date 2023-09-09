using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities
{
    public class Subscription : BaseEntity
    {
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public List<ScheduleAction> Actions { get; set; } = new();
    }
}
