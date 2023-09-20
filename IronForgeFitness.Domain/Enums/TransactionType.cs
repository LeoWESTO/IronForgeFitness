namespace IronForgeFitness.Domain.Enums;

/// <summary>
/// Enumeration for different transaction types.
/// </summary>
public enum TransactionType
{
    /// <summary>
    /// No transaction type specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// Payment transaction type.
    /// </summary>
    Payment,

    /// <summary>
    /// Rent transaction type.
    /// </summary>
    Rent,

    /// <summary>
    /// Sale transaction type.
    /// </summary>
    Sale,

    /// <summary>
    /// Purchase transaction type.
    /// </summary>
    Purchase,

    /// <summary>
    /// Salary transaction type.
    /// </summary>
    Salary,
}