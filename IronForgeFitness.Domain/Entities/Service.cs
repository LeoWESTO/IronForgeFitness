using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities
{
    /// <summary>
    /// Represents an entity of gym service
    /// </summary>
    public class Service : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
    }
}
