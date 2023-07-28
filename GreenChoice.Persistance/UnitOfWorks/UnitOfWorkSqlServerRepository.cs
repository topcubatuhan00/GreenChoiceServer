using GreenChoice.Domain.Repositories.UserRepositories;
using GreenChoice.Domain.UnitOfWork;
using GreenChoice.Persistance.Repositories.AppRepositories.UserRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.UnitOfWorks;

public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
{
    #region Fields
    public IUserCommandRepository userCommandRepository { get; }
    public IUserQueryRepository userQueryRepository { get; }
    #endregion

    #region Ctor
    public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
    {
        #region User
        userCommandRepository = new UserCommandRepository(context, transaction);
        userQueryRepository = new UserQueryRepository(context, transaction);
        #endregion
    }
    #endregion
}
