namespace IronForgeFitness.Domain.Abstractions
{
    /// <summary>
    /// Represents an entity that describes personal data
    /// </summary>
    public abstract class Person : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Patronymic { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber {  get; set; }
    }
}
