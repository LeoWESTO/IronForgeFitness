namespace IronForgeFitness.API.DTOs;

public record GymsList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<GymResponse> Gyms);
public record GymResponse(
    Guid Id,
    string Address);
public record GymRequest(
    string Address);