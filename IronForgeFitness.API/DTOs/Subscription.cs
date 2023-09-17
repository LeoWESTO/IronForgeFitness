namespace IronForgeFitness.API.DTOs;

public record SubscriptionsList(
    uint CurrentPage,
    uint ItemsPerPage,
    uint TotalItems,
    List<SubscriptionResponse> Subscriptions);
public record SubscriptionResponse(
    Guid Id,
    Guid ServiceId,
    Guid TransactionId,
    DateTime ExpirationDate);
public record SubscriptionRequest(
    Guid ServiceId);