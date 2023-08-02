using GreenChoice.Domain.Repositories.CampaignRepositories;
using GreenChoice.Domain.Repositories.UserRepositories;
using GreenChoice.Domain.UnitOfWork;
using GreenChoice.Persistance.Repositories.AppRepositories.CampaignRepositories;
using GreenChoice.Persistance.Repositories.AppRepositories.UserRepositories;
using Microsoft.Data.SqlClient;

namespace GreenChoice.Persistance.UnitOfWorks;

public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
{
    #region Fields
    public IUserCommandRepository userCommandRepository { get; }
    public IUserQueryRepository userQueryRepository { get; }

    public ICampaignCommandRepository campaignCommandRepository { get; }

    public ICampaignQueryRepository campaignQueryRepository { get; }
    #endregion

    #region Ctor
    public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
    {
        #region User
        userCommandRepository = new UserCommandRepository(context, transaction);
        userQueryRepository = new UserQueryRepository(context, transaction);
        #endregion

        #region Campaign
        campaignCommandRepository = new CampaignCommandRepository(context, transaction);
        campaignQueryRepository = new CampaignQueryRepository(context, transaction);
        #endregion
    }
    #endregion
}
