using GreenChoice.Domain.Entities;

namespace GreenChoice.Application.Services.Utilities;

public partial interface IJwtService
{
    string CreateToken(User user);
}
