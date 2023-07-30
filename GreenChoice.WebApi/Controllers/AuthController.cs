using GreenChoice.Application.Services;
using GreenChoice.Domain.Models.AuthModels;
using GreenChoice.WebApi.CustomControllerBase;
using Microsoft.AspNetCore.Mvc;

namespace GreenChoice.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : CustomBaseController
{
    #region Fields
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;
    #endregion

    #region Ctor
    public AuthController
    (
        IAuthService authService,
        IConfiguration configuration
    )
    {
        _authService = authService;
        _configuration = configuration;
    }
    #endregion

    #region Methods

    #region Login

    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] UserLoginModel model)
    {
        var token = await _authService.Login(model);
        return Ok(token);
    }

    #endregion

    #region Register

    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromForm] UserRegisterModel userRegisterModel)
    {
        await _authService.Register(userRegisterModel);
        return Ok("Successfully registered.");

    }

    #endregion

    #endregion
}
