using GreenChoice.Application.Services;
using GreenChoice.Application.Services.Utilities;
using GreenChoice.Domain.Models.AuthModels;
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

    #region Login
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

    #region Register
    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromForm] UserRegisterModel userRegisterModel)
    {
        string fileName = await UploadImage(userRegisterModel.Image);
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterModel.PasswordHash);

        userRegisterModel.PasswordHash = passwordHash;
        userRegisterModel.Photo = fileName;

        var user = await _authService.CheckDatabaseForUser(userRegisterModel.UserName);
        if (!user) throw new Exception("Username already used.");

        await _authService.Register(userRegisterModel);
        return Ok("Successfully registered.");

    }
    #endregion

    #endregion

    #region Helpers
    [NonAction]
    public async Task<string> UploadImage(IFormFile image)
    {
        string fileFormat = image.FileName.Substring(image.FileName.LastIndexOf(".")).ToLower();
        var fileName = Guid.NewGuid().ToString() + fileFormat;
        var path = "./Content/Images/" + fileName;
        using (var stream = System.IO.File.Create(path))
        {
            await image.CopyToAsync(stream);
        }
        return fileName;
    }
    #endregion
}
