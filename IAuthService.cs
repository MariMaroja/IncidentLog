using IncidentLog.DTOs.Auth;

namespace IncidentLog.Interfaces;

public interface IAuthService
{
    Task RegisterAsync(RegisterDto dto);
    Task<bool> LoginAsync(LoginDto dto);
}