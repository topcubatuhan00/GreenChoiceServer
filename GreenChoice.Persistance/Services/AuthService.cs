using AutoMapper;
using BCrypt.Net;
using GreenChoice.Application.Services;
using GreenChoice.Application.Services.Utilities;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.AuthModels;
using GreenChoice.Domain.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace GreenChoice.Persistance.Services;

public partial class AuthService : IAuthService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public AuthService(IMapper mapper, IUnitOfWork unitOfWork, IJwtService jwtService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }
    #endregion

    #region Methods
    public Task<User> CheckByUser(string userName)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = context.Repositories.userQueryRepository.CheckUserNameAndPassword(userName);
            return result;
        }
    }

    public async Task<bool> UserIsExist(string userName)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.userQueryRepository.CheckDatabaseForUserName(userName);
            if (!result) return true;
        }
        return false;
    }

    public async Task<string> Login(UserLoginModel userLoginModel)
    {
        var user = await CheckByUser(userLoginModel.Username);
        if (user == null) throw new Exception("User not found");

        var passwordVerify = VerifyPassword(userLoginModel.Password, user.PasswordHash);
        if(!passwordVerify) throw new Exception("Worng Password");

        return _jwtService.CreateToken(user);
    }

    public async Task Register(UserRegisterModel userRegisterModel)
    {
        var generateImageName = GenerateImageName(userRegisterModel);

        generateImageName.Photo = await UploadImage(userRegisterModel.Image);
        generateImageName.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterModel.PasswordHash);

        if(!await UserIsExist(userRegisterModel.UserName)) throw new Exception("Username already used.");

        using (var context = _unitOfWork.Create())
        {
            var user = _mapper.Map<User>(generateImageName);
            await context.Repositories.userCommandRepository.AddAsync(user);
            context.SaveChanges();
        }
    }
    #endregion

    #region Helpers
    private UserRegisterModel GenerateImageName(UserRegisterModel model)
    {
        var fileName = model.Image.FileName;
        var ext = fileName.Substring(fileName.LastIndexOf('.')).ToLower();
        List<string> AllowFileExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png" };
        var imgSize = model.Image.Length;
        decimal decimalMbimgSize = Convert.ToDecimal(imgSize * 0.000001);

        if (!AllowFileExtensions.Contains(ext))
            throw new Exception("Invalid image type.");
        if (decimalMbimgSize > 1)
            throw new Exception("Invalid image size (max 1mb).");

        return model;
    }
    
    private bool VerifyPassword(string Password, string PasswordHash)
    {
        if (!BCrypt.Net.BCrypt.Verify(Password, PasswordHash)) return false;
        return true;
    }

    public async Task<string> UploadImage(IFormFile image)
    {
        string fileFormat = image.FileName.Substring(image.FileName.LastIndexOf(".")).ToLower();
        var fileName = Guid.NewGuid().ToString() + fileFormat;
        var path = "../GreenChoice.WebApi/Content/Images/" + fileName;
        using (var stream = System.IO.File.Create(path))
        {
            await image.CopyToAsync(stream);
        }
        return fileName;
    }

    #endregion
}
