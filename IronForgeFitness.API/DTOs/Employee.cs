namespace IronForgeFitness.API.DTOs;

public record EmployeesList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<EmployeeResponse> Employees);
public record EmployeeResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly DateOfBirth,
    string PhoneNumber,
    Guid? AccountId,
    decimal Salary,
    DateOnly DateOfHire);
public record EmployeeRequest(
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly DateOfBirth,
    string PhoneNumber,
    Guid AccountId,
    decimal Salary,
    DateOnly DateOfHire);