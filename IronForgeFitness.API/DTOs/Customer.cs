namespace IronForgeFitness.API.DTOs;

public record CustomersList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<CustomerGet> Customers);
public record CustomerGet(
    Guid Id,
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly DateOfBirth,
    string PhoneNumber, 
    Guid? AccountId);
public record CustomerPost(
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly DateOfBirth,
    string PhoneNumber,
    Guid AccountId);
public record CustomerPut(
    Guid Id,
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly DateOfBirth,
    string PhoneNumber,
    Guid AccountId);