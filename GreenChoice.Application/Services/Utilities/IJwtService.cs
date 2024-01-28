using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.AuthModels;

namespace GreenChoice.Application.Services.Utilities;

public partial interface IJwtService
{
    TokenResponseModel CreateToken(User user);
}
