namespace IronForgeFitness.API.DTOs;

public record ItemsList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<ItemResponse> Items);
public record ItemResponse(
    Guid Id,
    string Title,
    decimal Price);
public record ItemRequest(
    string Title,
    decimal Price);