using AutoMapper;
using GreenChoice.Application.Services;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.AuthModels;
using GreenChoice.Domain.UnitOfWork;
using System.Linq;

namespace GreenChoice.Persistance.Services;

public partial class AuthService : IAuthService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public AuthService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
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

    public async Task<bool> CheckDatabaseForUser(string userName)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.userQueryRepository.CheckDatabaseForUserName(userName);
            if (!result) return true;
        }
        return false;
    }

    public async Task Register(UserRegisterModel userModel)
    {
        var checkImage = CheckImage(userModel);
        using (var context = _unitOfWork.Create())
        {
            var user = _mapper.Map<User>(checkImage);
            await context.Repositories.userCommandRepository.AddAsync(user);
            context.SaveChanges();
        }
    }
    #endregion

    #region Helpers
    private UserRegisterModel CheckImage(UserRegisterModel model)
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
    #endregion
}
