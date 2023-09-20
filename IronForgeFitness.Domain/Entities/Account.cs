using IronForgeFitness.Domain.Abstractions;

namespace IronForgeFitness.Domain.Entities;

/// <summary>
/// Represents an Account entity, derived from BaseEntity.
/// </summary>
public class Account : BaseEntity
{
    /// <summary>
    /// The email associated with the account.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The hashed password associated with the account.
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// The role of the account.
    /// </summary>
    public string Role { get; set; } = string.Empty;
}