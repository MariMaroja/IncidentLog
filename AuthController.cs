using IncidentLog.DTOs.Auth;
using IncidentLog.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IncidentLog.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(
        IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult>
        Register(RegisterDto dto)
    {
        await _authService
            .RegisterAsync(dto);

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult>
        Login(LoginDto dto)
    {
        var token =
            await _authService
            .LoginAsync(dto);

        if (token == null)
            return Unauthorized();

        return Ok(new
        {
            Token = token
        });
    }
}