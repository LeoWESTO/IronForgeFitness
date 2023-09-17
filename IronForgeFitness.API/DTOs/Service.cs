namespace IronForgeFitness.API.DTOs;

public record ServicesList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<ServiceResponse> Services);
public record ServiceResponse(
    Guid Id,
    string Title,
    string Description,
    decimal Price);
public record ServiceRequest(
    string Title,
    string Description,
    decimal Price);