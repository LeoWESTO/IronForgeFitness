namespace IronForgeFitness.API.DTOs;

public record EmployeesList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<EmployeeGet> Employees);
public record EmployeeGet(
    Guid Id,
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly DateOfBirth,
    string PhoneNumber,
    Guid? AccountId,
    decimal Salary,
    DateOnly DateOfHire);
public record EmployeePost(
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly DateOfBirth,
    string PhoneNumber,
    Guid AccountId,
    decimal Salary,
    DateOnly DateOfHire);
public record EmployeePut(
    Guid Id,
    string FirstName,
    string LastName,
    string? Patronymic,
    DateOnly DateOfBirth,
    string PhoneNumber,
    Guid AccountId,
    decimal Salary,
    DateOnly DateOfHire);