namespace IronForgeFitness.API.DTOs;

public record TrainingsList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<TrainingResponse> Trainings);
public record TrainingResponse(
    Guid Id,
    DateTime DateTime);
public record TrainingRequest(
    DateTime DateTime);