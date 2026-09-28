namespace vms_be.Services
{
    public interface IAuthService
    {
        Task<bool> ValidateCredentials(string username, string password);
        string GenerateJwtToken(string username);
    }
}
