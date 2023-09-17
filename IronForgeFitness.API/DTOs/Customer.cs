namespace IronForgeFitness.API.DTOs;

public record CustomersList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<CustomerResponse> Customers);
public record CustomerResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly DateOfBirth,
    string PhoneNumber, 
    Guid? AccountId);
public record CustomerRequest(
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly DateOfBirth,
    string PhoneNumber,
    Guid AccountId);