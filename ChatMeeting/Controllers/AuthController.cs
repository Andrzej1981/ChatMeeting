using ChatMeeting.Core.Domain.Dtos;
using ChatMeeting.Core.Domain.Interfaces.Repositories;
using ChatMeeting.Core.Domain.Interfaces.Services;
using ChatMeeting.Core.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatMeeting.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    { 
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPut("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUser)
        {
            try
            {
                await _authService.RegisterUser(registerUser);
                return Ok(new { message = "Użytkownik zarejstrowany." });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, $"Próba rejstracji się nie powiodła. Użytkownik o podanym loginie już istnieje : {registerUser.UserName}");
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Bład podczas rejstracji dla użytkonika {registerUser.UserName}");
                return StatusCode(500, "Niespodziewany błąd podczas rejstracji");
            }
        }
    }
}
