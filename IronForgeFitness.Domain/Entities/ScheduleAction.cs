namespace IronForgeFitness.Domain.Entities
{
    public class ScheduleAction
    {
        public DateTime DateTime { get; set; }
        public List<Subscription> Subscriptions { get; set; } = new();

    }
}
