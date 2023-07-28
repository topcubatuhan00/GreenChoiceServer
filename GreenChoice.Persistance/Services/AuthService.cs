using AutoMapper;
using GreenChoice.Application.Services;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.UnitOfWork;

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
        using(var context = _unitOfWork.Create())
        {
            var result = context.Repositories.userQueryRepository.CheckUserNameAndPassword(userName);
            return result;
        }
    }
    #endregion
}
