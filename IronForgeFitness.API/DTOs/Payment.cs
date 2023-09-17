namespace IronForgeFitness.API.DTOs;

public record PaymentsList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<PaymentGet> Payments);
public record PaymentGet(
    Guid Id,
    Guid ServiceId,
    DateTime DateTime,
    decimal Amount);
public record PaymentPost(
    Guid ServiceId,
    DateTime DateTime,
    decimal Amount);
public record PaymentPut(
    Guid Id,
    Guid ServiceId,
    DateTime DateTime,
    decimal Amount);