namespace IronForgeFitness.API.DTOs;

public record ItemsList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<ItemGet> Items);
public record ItemGet(
    Guid Id,
    string Title,
    decimal Price);
public record ItemPost(
    string Title,
    decimal Price);
public record ItemPut(
    Guid Id,
    string Title,
    decimal Price);