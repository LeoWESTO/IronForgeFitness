using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities
{
    /// <summary>
    /// Represents an entity of item in stock
    /// </summary>
    public class Item : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public Gym Gym { get; set; }
    }
}
