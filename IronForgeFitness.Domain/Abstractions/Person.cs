namespace IronForgeFitness.Domain.Abstractions;

/// <summary>
/// Represents a person.
/// </summary>
public abstract class Person : BaseEntity
{
    /// <summary>
    /// The first name of the person.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// The last name of the person.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// The patronymic of the person.
    /// </summary>
    public string? Patronymic { get; set; } = string.Empty;

    /// <summary>
    /// The date of birth of the person.
    /// </summary>
    public DateOnly DateOfBirth { get; set; }

    /// <summary>
    /// The phone number of the person.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
}