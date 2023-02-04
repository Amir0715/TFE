namespace TFE.WebApi.DTOs;

public record RegistrationDTO(string Email, string UserName, string FirstName, string LastName, string? Patronymic, string Password);