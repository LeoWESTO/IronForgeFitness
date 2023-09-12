namespace IronForgeFitness.Domain.Entities
{
    /// <summary>
    /// Represents an entity of training event in the calendar
    /// </summary>
    public class Training
    {
        public DateTime DateTime { get; set; }
        public List<Subscription> Subscriptions { get; set; } = new();

    }
}
