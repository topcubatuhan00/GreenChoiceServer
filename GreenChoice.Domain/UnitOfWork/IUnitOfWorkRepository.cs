using GreenChoice.Domain.Repositories.UserRepositories;

namespace GreenChoice.Domain.UnitOfWork;

public interface IUnitOfWorkRepository
{
    #region UserRepositories
    IUserCommandRepository userCommandRepository { get; }
    IUserQueryRepository userQueryRepository { get; }
    #endregion
}
