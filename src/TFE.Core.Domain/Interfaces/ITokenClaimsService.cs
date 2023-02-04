namespace TFE.Domain.Interfaces;

public interface ITokenClaimsService
{
    Task<string> GetTokenAsync(string userName);
}