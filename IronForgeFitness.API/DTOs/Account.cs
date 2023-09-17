using IronForgeFitness.Domain.Enums;

namespace IronForgeFitness.API.DTOs;

public record AccountsList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<AccountResponse> Accounts);
public record AccountResponse(
    string Email,
    Role Role);
public record AccountRequest(
    string Email,
    string Password,
    Role Role);
