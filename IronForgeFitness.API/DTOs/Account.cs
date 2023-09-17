using IronForgeFitness.Domain.Enums;

namespace IronForgeFitness.API.DTOs;

public record AccountGet();
public record AccountPost(
    string Email,
    string Password,
    Role Role);

public record AccountPut(
    Guid Id,
    string Email,
    string Password,
    Role Role);