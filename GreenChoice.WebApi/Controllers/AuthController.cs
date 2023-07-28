using GreenChoice.Application.Services;
using GreenChoice.Application.Services.Utilities;
using GreenChoice.Domain.Models.Login;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : CustomBaseController
{
    #region Fields
    private readonly IJwtService _jwtService;
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;
    #endregion

    #region Ctor
    public AuthController
    (
        IJwtService jwtService, 
        IAuthService authService, 
        IConfiguration configuration
    )
    {
        _jwtService = jwtService;
        _authService = authService;
        _configuration = configuration;
    }
    #endregion

    #region Methods
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] UserLoginModel model)
    {
        var user = await _authService.CheckByUser(model.Username);
        if (user == null) return BadRequest("User Not Found");

        if (!BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash)) return BadRequest("Wrong Password");

        string token = _jwtService.CreateToken(user);
        return Ok(token);
    }
    #endregion
}
