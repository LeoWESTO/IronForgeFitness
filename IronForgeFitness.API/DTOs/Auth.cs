namespace IronForgeFitness.API.DTOs;

public record AuthCredentials(
    string Email, 
    string Password);
public record AuthToken(
    string AccessToken,
    string RefreshToken);