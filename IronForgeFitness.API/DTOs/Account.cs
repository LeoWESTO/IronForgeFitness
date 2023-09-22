using IronForgeFitness.Domain.Enums;

namespace IronForgeFitness.API.DTOs;

public record AccountsList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<AccountResponse> Accounts);
public record AccountResponse(
    Guid Id,
    string Email,
    string Role);
public record AccountRequest(
    string Email,
    string Password,
    string Role);
