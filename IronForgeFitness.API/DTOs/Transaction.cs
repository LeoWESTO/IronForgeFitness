using IronForgeFitness.Domain.Enums;

namespace IronForgeFitness.API.DTOs;

public record TransactionsList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<TransactionResponse> Transactions);
public record TransactionResponse(
    Guid Id,
    DateTime DateTime,
    decimal Amount,
    TransactionType Type,
    string Description);
public record TransactionRequest(
    DateTime DateTime,
    decimal Amount,
    TransactionType Type,
    string Description);